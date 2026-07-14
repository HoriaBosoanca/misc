using UnityEngine;

namespace Spider
{
    public class SpiderAnimations : MonoBehaviour
    {
        [SerializeField] private Sprite[] spritesAttack;
        [SerializeField] private Sprite[] spritesRun;
        [SerializeField] private Sprite[] spritesIdle;
        
        private SpiderMovement _sm;
        private SpiderAttack _sa;
        private Animate _an; 
        
        private void Awake()
        {
            _sm = GetComponent<SpiderMovement>();
            _sa = GetComponent<SpiderAttack>();
            _an = GetComponent<Animate>();
        }
        
        private void Update()
        {
            foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.flipX = _sm.movingLeft;
            }

            if (_sa.attacking)
            {
                _an.UpdateState("attack", spritesAttack, true);
                return;
            }
            if (_sm.attacking)
            {
                _an.UpdateState("on-cooldown", new[] { spritesIdle[0] }, true);
                return;
            }
            if (_sm.moving)
            {
                _an.UpdateState("run", spritesRun, true);
                return;
            }
            _an.UpdateState("idle", spritesIdle, true);
        }
    }
}

