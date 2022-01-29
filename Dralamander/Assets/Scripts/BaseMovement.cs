using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public enum MovementState
    {
        Ground,
        Water,
        Air,
    }
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        protected float _frictionCoefficient = 0.0f;
        protected Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public abstract MovementState MType();
        public abstract void Move(Vector2 input);

        public void Reset()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        public abstract void Enter();
    }
}
