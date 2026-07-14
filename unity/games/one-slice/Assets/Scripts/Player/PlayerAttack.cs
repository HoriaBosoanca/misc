using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        // shows whether it's still attacking
        public bool attacking;
        
        [SerializeField] private float attackDuration;
        [SerializeField] private float attackCooldown;
        [SerializeField] private GameObject slice;

        // shows whether it's on attack cooldown
        private bool _attacked;

        private void Update()
        {
            if (_attacked) return;

            if (Input.GetKey(KeyCode.Space))
            {
                attacking = true;
                _attacked = true;
                StartCoroutine(AttackCooldown());
                Instantiate(slice, transform);
            }
        }

        private IEnumerator AttackCooldown()
        {
            yield return new WaitForSeconds(attackDuration);
            attacking = false;
            yield return new WaitForSeconds(attackCooldown);
            _attacked = false;
        }
    }
}