using Code.Components.Entity;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Components {
    public class HealthSlider : MonoBehaviour {
        [SerializeField] private Slider slider;
        private EntityStats _stats;
        void Awake() {
            _stats = GetComponentInParent<EntityStats>();
        }
        void Update() {
            slider.value = (float) _stats.health / (float) _stats.maxHealth;
        }
    }
}