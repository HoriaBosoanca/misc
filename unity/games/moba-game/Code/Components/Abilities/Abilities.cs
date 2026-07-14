using System.Collections;
using Code.Components.Entity;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Components.Abilities {
    public class Abilities : MonoBehaviour {
        // to be customized
        protected virtual void ExecuteAuto(EntityStats target) { }
        protected virtual void StopAuto() { }
        
        // scripts
        public EntityStats stats;
        
        // cooldowns
        private float _autoWindupTime;
        private float _autoCooldownTime;
        
        // flags
        bool _autoWindupStarted;
        bool _autoOnCooldown;
        protected virtual void Awake() {
            stats = GetComponent<EntityStats>();
            _autoWindupTime = stats.autoWindupTime;
            _autoCooldownTime = stats.autoCooldownTime;
            _autoWindupStarted = false;
            _autoOnCooldown = false;
        }
        public void InvokeAuto(EntityStats target) {
            StartCoroutine(Auto(target));
        }
        private IEnumerator Auto(EntityStats target) {
            if (!target) {
                if (_autoWindupStarted) {
                    _autoWindupStarted = false;
                    StopAuto();
                }
                yield break;
            }
            if(_autoOnCooldown || _autoWindupStarted) yield break;
            _autoWindupStarted = true;
            yield return new WaitForSeconds(_autoWindupTime);
            _autoWindupStarted = false;
            if(!target) yield break;
            _autoOnCooldown = true;
            ExecuteAuto(target);
            yield return new WaitForSeconds(_autoCooldownTime);
            _autoOnCooldown = false;
        }
    }
}