using System;
using UnityEngine;

namespace Spider
{
    public class SpiderMovement : MonoBehaviour
    {
        public bool movingLeft;
        public bool moving;
        // the meaning of attacking here is whether the spider is in attack range
        public bool attacking;
        
        [SerializeField] private float aggroRange;
        [SerializeField] private float attackRange;
        [SerializeField] private float speed;
        [SerializeField] private float maxSpeed;
        
        private Rigidbody2D _rb;
        private SpiderAttack _sa;
        private GameObject _player;
        
        private void Awake()
        {
            _player = GameObject.Find("Player");
            _sa = GetComponent<SpiderAttack>();
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            if (!_player) return;

            var dist = transform.position.x - _player.transform.position.x;
            if (Math.Abs(dist) > aggroRange)
            {
                moving = false;
                attacking = false;
                return;
            }
            
            movingLeft = dist > 0;

            if (Math.Abs(dist) < attackRange)
            {
                moving = false;
                attacking = true;
                return;
            }
            
            moving = true;
            attacking = false;
            _rb.AddForce(speed * Math.Sign(dist) * Vector2.left);
                
            // cap speed on x-axis
            if (_rb.linearVelocityX > maxSpeed)
            {
                _rb.linearVelocityX = maxSpeed;
            }
            if (_rb.linearVelocityX < -maxSpeed)
            {
                _rb.linearVelocityX = -maxSpeed;
            }
        }
    }
}