using Code.Components.Entity;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Components.AI {
    public class PlayerInput : MonoBehaviour {
        private NavMeshAgent _playerAgent;
        private void Awake() {
            _playerAgent = GetComponent<NavMeshAgent>();
            _playerAgent.updateRotation = false;
            _playerAgent.updateUpAxis = false;
    
            EntityStats stats = GetComponent<EntityStats>();
            _playerAgent.speed = stats.speed;
        }
        private void Update() {
            if(Input.GetMouseButtonDown(1)) {
                Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _playerAgent.SetDestination(clickPos);
            }
        }
    }
}
