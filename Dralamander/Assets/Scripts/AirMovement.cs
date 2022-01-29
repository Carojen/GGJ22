using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class AirMovement : BaseMovement
    {
        public override MovementState MType() => MovementState.Air;

        [SerializeField]
        [Range(0f, 1f)]
        private float _jumpWindow;
        public override void Enter()
        {
            _rigidbody.useGravity = true;
        }

        public override bool CanJump(float jump, ref float wallTime, Collision wallCol = null)
        {
            if ((jump > 0 && wallTime > 0f && wallTime + _jumpWindow > Time.time))
            {
                wallTime = 0f;
                return true;
            }
            return false;
        }

        public override void Jump(float jump, Collision wallCol)
        {
            var impulse = Vector3.up * _jumpForce;
            if (wallCol != null) // Walljump negates falling
            {
                var newVelocity = _rigidbody.velocity;
                newVelocity.y = 0;
                _rigidbody.velocity = newVelocity;
                impulse.x = wallCol.impulse.x;
                impulse.y *= 2f;
            }
            else // Waterline boost
            {
                impulse.x = _rigidbody.velocity.normalized.x;
            }

            _rigidbody.AddForce(impulse, ForceMode.Impulse);            
        }

        public override void Move(Vector2 input)
        {
            if (input.x == 0) input.x = -_rigidbody.velocity.x * _frictionCoefficient;
            else if (input.x < 0) input.x += _rigidbody.velocity.x * _frictionCoefficient;
            else input.x -= _rigidbody.velocity.x * _frictionCoefficient;
            input.y = 0;
            _rigidbody.AddForce(input * _horizontalSpeed);
        }
    }
}