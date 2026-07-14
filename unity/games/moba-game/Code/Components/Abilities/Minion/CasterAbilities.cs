using System.Collections;
using Code.Components.Entity;
using Code.Components.Visuals;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Components.Abilities.Minion {
    public class CasterAbilities : Abilities {
        // settings
        [SerializeField] private GameObject casterOrb;
        
        // actual attack logic
        protected override void ExecuteAuto(EntityStats target) {
            GameObject orb = casterOrb;
            SpriteRegistry registry = GameObject.Find("SpriteRegistry").GetComponent<SpriteRegistry>();
            orb.GetComponent<SpriteRenderer>().sprite = GetComponent<EntityStats>().isRed ? registry.redCasterOrb : registry.blueCasterOrb;
            
            orb = Instantiate(casterOrb, transform.position, Quaternion.identity);
            orb.GetComponent<ProjectileTranslate>().Initialize(target, stats.damage);
        }
    }
}