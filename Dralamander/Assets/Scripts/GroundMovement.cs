using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class GroundMovement : BaseMovement
    {
        public override MovementState MType() => MovementState.Ground;

        public override void Move(Vector2 input)
        {
            if (input.x == 0) input.x = -_rigidbody.velocity.x * _frictionCoefficient;
            input.y = 0f;
            _rigidbody.AddForce(input * _horizontalSpeed);
        }

        public override bool CanJump(float jump, Collision wallCol = null, float wallTime = 0.0f) => jump > 0;

        public override void Enter()
        {
            _rigidbody.useGravity = true;
        }
    }
}
