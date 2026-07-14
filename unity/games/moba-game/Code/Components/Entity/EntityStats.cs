using UnityEngine;

namespace Code.Components.Entity {
    public class EntityStats : MonoBehaviour {
        public bool isRed;
        public int maxHealth;
        public int health;
        public int damage;
        public float speed;
        public float attackRange;
        public float aggroRange;
        public float autoWindupTime;
        public float autoCooldownTime;
        private void Update() {
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
