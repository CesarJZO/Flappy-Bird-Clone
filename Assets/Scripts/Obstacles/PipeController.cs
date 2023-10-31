using System;
using Player;
using UnityEngine;

namespace Obstacles
{
    public sealed class PipeController : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float speed;

        private readonly Vector3 _direction = Vector3.left;

        private void Start()
        {
            Bird.Instance.OnDie += OnBirdDie;
        }

        private void OnDestroy()
        {
            Bird.Instance.OnDie -= OnBirdDie;
        }

        private void Update()
        {
            transform.Translate(_direction * (speed * Time.deltaTime));
        }

        private void OnBirdDie()
        {
            enabled = false;
        }
    }
}
