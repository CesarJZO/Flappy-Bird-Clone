using System;
using System.Collections;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public sealed class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private float spawnRate;
        [SerializeField] private float heightOffset;

        private bool _birdDead;

        private void Start()
        {
            Bird.Instance.OnDie += OnBirdDie;
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            while (!_birdDead)
            {
                SpawnPipe();
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private void OnDestroy()
        {
            Bird.Instance.OnDie -= OnBirdDie;
        }

        private void SpawnPipe()
        {
            float randomOffset = Random.Range(-heightOffset, heightOffset);
            Vector3 origin = transform.position;
            Vector3 verticalOffset = Vector3.up * randomOffset;
            Instantiate(pipePrefab, origin + verticalOffset, Quaternion.identity);
        }

        private void OnBirdDie()
        {
            _birdDead = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, new Vector3(1f, heightOffset * 2f));
        }
    }
}
