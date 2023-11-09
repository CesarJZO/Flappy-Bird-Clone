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

        public event Action OnJump;
        public event Action OnDie;

        [SerializeField] private float jumpStrength;
        [SerializeField] private float dieStrength;
        [SerializeField] private LayerMask playableLayer;

        private Rigidbody2D _rigidbody;
        private bool _dead;

        public bool Dead => _dead;

        private bool IsInsidePlayableArea => Physics2D.OverlapCircle(
            transform.position,
            transform.lossyScale.magnitude,
            playableLayer
        );

        private void Awake()
        {
            if (Instance)
                Destroy(gameObject);
            else
                Instance = this;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            InputManager.Instance.OnJumpPerformed += OnJumpPerformed;
        }

        private void OnDestroy()
        {
            InputManager.Instance.OnJumpPerformed -= OnJumpPerformed;
        }

        private void OnJumpPerformed()
        {
            if (_dead) return;

            if (IsInsidePlayableArea)
                Jump();
        }

        private void Jump()
        {
            _rigidbody.velocity = Vector2.up * jumpStrength;

            OnJump?.Invoke();
        }

        private void OnCollisionEnter2D()
        {
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, transform.lossyScale.magnitude);
        }
    }
}
