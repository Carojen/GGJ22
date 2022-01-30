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
        [Range(0.0f, 100.0f)]
        protected float _hAccel = 20.0f;

        [SerializeField]
        [Range(0.0f, 20.0f)]
        protected float _maxVelocity = 20f;

        [SerializeField]
        [Range(-1.0f, 1.0f)]
        protected float _frictionCoefficient = 0.0f;

        [SerializeField]
        [Range(0.0f, 20f)]
        protected float _jumpForce = 1f;

        protected Rigidbody _rigidbody;
        protected Animator _animator;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponentInChildren<Animator>(true);
        }

        public abstract MovementState MType();
        public abstract void Move(Vector2 input);

        public void TryJump(float jump, ref float wallTime, Collision wallCol = null)
        { 
            if (CanJump(jump, ref wallTime, wallCol)) Jump(jump, wallCol);
        }
        public virtual bool CanJump(float jump, ref float wallTime, Collision wallCol = null) => false;
        public virtual void Jump(float jump, Collision wallCol = null)
        {
            GameManager.Instance.PlayEvent(GameManager.Jump, false);
            _rigidbody.AddForce(Vector3.up * jump * _jumpForce, ForceMode.Impulse);
        }

        public void Reset()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        public virtual void ClampVelocity()
        {
            var clampedVelocity = _rigidbody.velocity;
            if (clampedVelocity.x > _maxVelocity) clampedVelocity.x = _maxVelocity;
            if (clampedVelocity.x < -_maxVelocity) clampedVelocity.x = -_maxVelocity;
            if (clampedVelocity.y > _maxVelocity) clampedVelocity.y = _maxVelocity;
            if (clampedVelocity.y < -_maxVelocity) clampedVelocity.y = -_maxVelocity;
        }

        public virtual void UpdateRotation()
        {
            var velocity = _rigidbody.velocity.normalized;
            var direction = Vector3.zero;
            if (velocity.x > 0f) direction.y = 0f;
            else direction.y = 180f;
            direction.z = velocity.y * 90f;
            
            transform.rotation = Quaternion.Euler(direction);
        }

        public abstract void Enter();

        public override string ToString() => $"{MType()}: {_rigidbody.velocity} ";
    }
}
