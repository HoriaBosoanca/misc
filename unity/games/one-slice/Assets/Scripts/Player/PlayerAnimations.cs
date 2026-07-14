using UnityEngine;

namespace Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Sprite[] spritesAttack;
        [SerializeField] private Sprite[] spritesJump;
        [SerializeField] private Sprite[] spritesRun;
        [SerializeField] private Sprite spriteIdle;
        
        private SpriteRenderer _sr;
        private PlayerMovement _pm;
        private PlayerAttack _pa;
        private Animate _an;
        
        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _pm = GetComponent<PlayerMovement>();
            _pa = GetComponent<PlayerAttack>();
            _an = GetComponent<Animate>();
        }
    
        private void Update()
        {
            foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.flipX = _pm.movingLeft;
            }
    
            if (_pa.attacking)
            {
                _an.UpdateState("attack", spritesAttack, false);
                return;
            }
            if (_pm.jumping)
            {
                _an.UpdateState("jump", spritesJump, false);
                return;
            }
            if (_pm.moving)
            {
                _an.UpdateState("run", spritesRun, true);
                return;
            }
            _an.UpdateState("idle", new[] {spriteIdle}, true);
        }
    }
}
