using System.Collections;
using UnityEngine;

namespace Spider
{
    public class SpiderAttack : MonoBehaviour
    {
        // the meaning of 'attack' here is whether the spider is currently doing an attack  
        public bool attacking;

        [SerializeField] private float attackDuration;
        [SerializeField] private float attackCooldown;
        
        private bool _attacked;
        private SpiderMovement _sm;

        private void Awake()
        {
            _sm = GetComponent<SpiderMovement>();
        }
        
        private void Update()
        {
            if (_attacked || !_sm.attacking) return;
            
            // TODO: add an initial timeframe (a windup) in which the attack can be cancelled (by checking SpiderMovement.attacking again) if the player runs away 
            
            attacking = true;
            _attacked = true;
            StartCoroutine(AttackCooldown());
            // do an attack
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