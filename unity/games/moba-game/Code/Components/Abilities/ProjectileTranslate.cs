using System.Collections;
using Code.Components.Entity;
using UnityEngine;

namespace Code.Components.Abilities {
    public class ProjectileTranslate : MonoBehaviour {
        // settings
        [SerializeField] private float speed;
        
        private EntityStats _target;
        private float _lifeTime;
        private int _damage;
        public void Initialize(EntityStats target, int damage) {
            _target = target;
            _damage = damage;
        }
        void Update() {
            if (_target) {
                // rotation
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(_target.transform.position.y - transform.position.y, _target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 180));
                // movement
                Vector3 destination = Vector3.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, destination) <= 0.01f) {
                    _target.GetComponent<EntityStats>().health -= _damage;
                    Destroy(gameObject);
                }
                transform.position = destination;
            } else { 
                Destroy(gameObject);
            }
        }
    }
}