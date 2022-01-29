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
            if (input.x == 0) input.x = -_rigidbody.velocity.x * (1f - _frictionCoefficient);
            _rigidbody.AddForce(Vector2.right * input.x * _horizontalSpeed);
        }

        public override void Enter()
        {
            _rigidbody.useGravity = true;
        }
    }
}
