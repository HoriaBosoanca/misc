using System.Collections;
using System.Linq;
using Code.Components.Abilities.Minion;
using Code.Components.AI;
using UnityEngine;

namespace Code.Components.GameLoops {
    public class MinionLoop : MonoBehaviour {
        // types
        [System.Serializable] struct MapPoints {
            public Vector3[] mid;
            public Vector3[] top;
            public Vector3[] bot;
        }
        // minion
        [SerializeField] private GameObject casterPrefab;
        [SerializeField] private GameObject meleePrefab;
        // timers
        [SerializeField] private float waveDelay;
        // spawn positions
        [SerializeField] private MapPoints casterSpawn;
        [SerializeField] private MapPoints meleeSpawn;
        // Lane destinations
        [SerializeField] private MapPoints pathPoints;
        void Spawn<T>(GameObject prefab, Vector3[] positions, Vector3[] paths, bool isRed) where T : Abilities.Abilities {
            foreach (Vector3 spawnPos in positions) {
                MinionAI minion = Instantiate(prefab, spawnPos * (isRed ? 1 : -1), Quaternion.identity).GetComponent<MinionAI>();
                minion.Initiate<T>(paths.Select(p => p * (isRed ? 1 : -1)).ToArray(), isRed);
            }
        }
        void Start() {
            StartCoroutine(SpawnMinions());
        }

        IEnumerator SpawnMinions() {
            // casters
            Spawn<CasterAbilities>(casterPrefab, casterSpawn.mid, pathPoints.mid, true);
            Spawn<CasterAbilities>(casterPrefab, casterSpawn.top, pathPoints.top, true);
            Spawn<CasterAbilities>(casterPrefab, casterSpawn.bot, pathPoints.bot, true);
            Spawn<CasterAbilities>(casterPrefab, casterSpawn.mid, pathPoints.mid, false);
            Spawn<CasterAbilities>(casterPrefab, casterSpawn.top, pathPoints.top, false);
            Spawn<CasterAbilities>(casterPrefab, casterSpawn.bot, pathPoints.bot, false);    
            
            // melee
            Spawn<MeleeAbilities>(meleePrefab, meleeSpawn.mid, pathPoints.mid, true);
            Spawn<MeleeAbilities>(meleePrefab, meleeSpawn.top, pathPoints.top, true);
            Spawn<MeleeAbilities>(meleePrefab, meleeSpawn.bot, pathPoints.bot, true);
            Spawn<MeleeAbilities>(meleePrefab, meleeSpawn.mid, pathPoints.mid, false);
            Spawn<MeleeAbilities>(meleePrefab, meleeSpawn.top, pathPoints.top, false);
            Spawn<MeleeAbilities>(meleePrefab, meleeSpawn.bot, pathPoints.bot, false);   
            
            yield return new WaitForSeconds(waveDelay);
            StartCoroutine(SpawnMinions());
        }
    }
}
