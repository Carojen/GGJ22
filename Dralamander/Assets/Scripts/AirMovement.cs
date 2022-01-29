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

        public override bool CanJump(float jump, Collision wallCol, float wallTime) =>
            (jump > 0 && wallCol != null && wallTime + _jumpWindow > Time.time);

        public override void Jump(float jump, Collision wallCol)
        {
            var impulse = wallCol.impulse.normalized;
            impulse.y = _jumpForce;
            _rigidbody.AddForce(impulse, ForceMode.Impulse);
        }

        public override void Move(Vector2 input) 
        {
            if (input.x == 0) input.x = -_rigidbody.velocity.x * _frictionCoefficient;
            else if(input.x < 0) input.x += _rigidbody.velocity.x * _frictionCoefficient;
            else input.x -= _rigidbody.velocity.x * _frictionCoefficient;
            input.y = 0;
            _rigidbody.AddForce(input * _horizontalSpeed);
        }
    }
}