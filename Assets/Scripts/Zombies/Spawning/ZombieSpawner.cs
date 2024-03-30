using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Unity.Mathematics;
using Sirenix.OdinInspector;

namespace PVZ.Zombies
{
    public class ZombieSpawner : SerializedMonoBehaviour
    {
        [SerializeField] 
        private List<Wave> waves;

        [Space(20f)]

        [SerializeField] 
        private float startDelay = 1f;

        [Space(20f)]

        [SerializeField] 
        private bool doRandomDelay = false;

        [Space(5f)]

        [ShowIf(nameof(doRandomDelay), true)]
        [SerializeField]
        private float maxDelay = 1f;

        private void Start()
        {
            StartSpawning();
        }

        private void StartSpawning()
        {
            for (int i = 0; i < waves.Count; i++)
            {
                LaunchSpawner(i);
            }
        }

        private void LaunchSpawner(int index)
        {
            float delay = math.abs(startDelay);

            if (doRandomDelay)
                delay = Random.Range(math.abs(startDelay), math.abs(maxDelay));

            StartCoroutine(SpawnWave(index, delay));
        }

        private IEnumerator SpawnWave(int waveIndex, float startDelay = 0f)
        {
            var wave = waves[waveIndex];

            if (WaveIsInvalid(wave))
                yield break;

            yield return new WaitForSeconds(startDelay);

            var waveQueue = new Queue<WaveSegment>(wave.WaveSettings.Wave);

            while (waveQueue.TryDequeue(out WaveSegment waveSegment))
            {
                if (waveSegment.ZombieToSpawn != null)
                    CreateZombie(waveSegment, wave);

                float delayTime = waveSegment.DoRandomTime ? Random.Range(waveSegment.DelayAfterSpawn, waveSegment.MaxRandomTime) : waveSegment.DelayAfterSpawn;

                yield return new WaitForSeconds(delayTime);
            }

            yield break;
        }

        private void CreateZombie(WaveSegment waveSegment, Wave wave)
        {
            var direction = quaternion.Euler(new float3(0, (wave.FinishPoint.position - wave.SpawnPoint.position).y, 0));

            var spawnPos = wave.SpawnPoint.position;
            spawnPos.z += Random.Range(-0.3f, 0.3f);

            var zombie = Instantiate(waveSegment.ZombieToSpawn, spawnPos, direction);

            var movement = zombie.GetComponent<ZombieMovement>();

            movement.FinishPosition = wave.FinishPoint.position;
        }

        private bool WaveIsInvalid(Wave wave)
        {
            if (wave.SpawnPoint == null)
                return true;

            if (wave.FinishPoint == null)
                return true;

            if (wave.WaveSettings.Wave.Count == 0)
                return true;

            return false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            DrawPoints();
        }

        private void DrawPoints()
        {
            if(waves == null)
                return;

            if (waves.Count == 0)
                return;

            foreach (var wave in waves)
            {
                if (wave.SpawnPoint == null)
                    continue;

                Gizmos.color = Color.red;

                Gizmos.DrawCube(wave.SpawnPoint.position, Vector3.one * 0.75f);

                if (wave.FinishPoint == null)
                    continue;

                Gizmos.color = Color.black;

                Gizmos.DrawLine(wave.SpawnPoint.position, wave.FinishPoint.position);

                Gizmos.color = Color.green;

                Gizmos.DrawCube(wave.FinishPoint.position, Vector3.one * 0.75f);
            }
        }
#endif
    }
}