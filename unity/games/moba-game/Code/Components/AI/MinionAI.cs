using System;
using Code.Components.Entity;
using Code.Components.Abilities.Minion;
using Code.Components.Visuals;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Components.AI {
    public class MinionAI : MonoBehaviour {
        // scripts
        private EntityStats _stats;
        private NavMeshAgent _agent;
        
        // abilities
        private Abilities.Abilities _abilities;
        
        // navigation
        private Vector3[] _pathPoints;
        private int _pathPointIndex;
        public void Initiate<T>(Vector3[] pathPoints, bool isRed) where T : Abilities.Abilities {
            // get scripts
            _stats = GetComponent<EntityStats>();
            _agent = GetComponent<NavMeshAgent>();
            
            // get abilities
            _abilities = GetComponent<T>();
            
            // navmesh
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            
            // settings
            _agent.stoppingDistance = _stats.attackRange;
            _agent.speed = _stats.speed;
            _pathPoints = pathPoints;
            _stats.isRed = isRed;
            _pathPointIndex = 0;
            
            // sprites
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            SpriteRegistry registry = GameObject.Find("SpriteRegistry").GetComponent<SpriteRegistry>();
            if (rend.sprite == registry.redCaster) {
                rend.sprite = isRed ? registry.redCaster : registry.blueCaster;
                if(!isRed) { rend.flipX = true; }
            } else if (rend.sprite == registry.redMelee) {
                rend.sprite = isRed ? registry.redMelee : registry.blueMelee;
                if(isRed) { rend.flipX = true; }
            }
        }
        EntityStats GetClosestEnemyInRange() {
            EntityStats[] entities = FindObjectsByType<EntityStats>(FindObjectsSortMode.None);
            float minDistance = _stats.aggroRange;
            EntityStats closest = null;
            
            foreach (EntityStats entity in entities) {
                float distance = Vector3.Distance(transform.position, entity.transform.position);
                if (distance <= minDistance && entity.isRed != _stats.isRed) {
                    minDistance = distance;
                    closest = entity;        
                }
            }
            
            return closest;
        }
        void Update() {
            EntityStats closest = GetClosestEnemyInRange();

            if (closest) {
                // if we find an entity to aggro
                if (Vector3.Distance(transform.position, closest.transform.position) <= _stats.attackRange) {
                    // if it's in attack range, attack it
                    _abilities.InvokeAuto(closest);
                } else {
                    // if it's only in aggro range, cancel the attack and move to it
                    _abilities.InvokeAuto(null);
                    _agent.SetDestination(closest.transform.position);
                }
            } else {
                // if we found no targets, but we already paused advancing, resume advancing in lane
                if (Vector3.Distance(transform.position, _pathPoints[_pathPointIndex]) < _stats.aggroRange && _pathPointIndex < _pathPoints.Length - 1) {
                    _pathPointIndex++;
                }
                _agent.SetDestination(_pathPoints[_pathPointIndex]);
                // cancel any potentially started attack
                _abilities.InvokeAuto(null);
            }
        }
    }
}
