using System.Collections;
using Code.Components.Entity;
using Code.Components.Visuals;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace Code.Components.Abilities.Minion {
    public class MeleeAbilities : Abilities {
        private Visuals.Animator _animator;
        private SpriteRegistry _reg;
        [SerializeField] private float animationInterval;
        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Visuals.Animator>();
            _reg = GameObject.Find("SpriteRegistry").GetComponent<SpriteRegistry>();
        }
        protected override void ExecuteAuto(EntityStats target) {
            target.health -= stats.damage;
            _animator.Play(stats.isRed ? _reg.redMeleeAnim : _reg.blueMeleeAnim, animationInterval);
        }
        protected override void StopAuto() {
            _animator.Stop();
        }
    }
}