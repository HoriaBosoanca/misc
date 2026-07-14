using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool movingLeft;
        public bool moving;
        public bool jumping;

        [SerializeField] private float speed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float jumpHeight;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            jumping = false;
        }

        private void FixedUpdate()
        {
            // get input
            moving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
            if (Input.GetKey(KeyCode.A))
            {
                _rb.AddForce(speed * Vector2.left);
                movingLeft = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rb.AddForce(speed * Vector2.right);
                movingLeft = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (!jumping)
                {
                    _rb.AddForce(jumpHeight * Vector2.up);
                    jumping = true;
                }
            }

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            jumping = false;
        }
    }
}