using System;
using Input;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Bird : MonoBehaviour
    {
        public static Bird Instance { get; private set; }

        public event Action OnDie;

        [SerializeField] private float jumpStrength;
        [SerializeField] private float dieStrength;
        [SerializeField] private LayerMask playableLayer;

        private Rigidbody2D _rigidbody;
        private bool _dead;

        private bool IsInsidePlayableArea => Physics2D.OverlapCircle(
            transform.position,
            transform.lossyScale.magnitude,
            playableLayer
        );

        private void Awake()
        {
            Instance = this;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            InputManager.Instance.OnJumpPerformed += OnJumpPerformed;
        }

        private void OnJumpPerformed()
        {
            if (IsInsidePlayableArea)
                Jump();
        }

        private void Jump()
        {
            _rigidbody.velocity = Vector2.up * jumpStrength;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
                Die();
        }

        private void Die()
        {
            if (_dead) return;
            _dead = true;

            float hDirection = Random.value > 0.5f ? 1f : -1f;
            _rigidbody.velocity = new Vector2(hDirection, 1f) * dieStrength;
            OnDie?.Invoke();
        }
    }
}
