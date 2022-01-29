using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class WaterMovement : BaseMovement
    {
        public override MovementState MType() => MovementState.Water;

        public override void Move(Vector2 input)
        {
            if (input.x == 0) input.x = -_rigidbody.velocity.x * _frictionCoefficient;
            if (input.y == 0) input.y = -_rigidbody.velocity.y * _frictionCoefficient;

            _rigidbody.AddForce(input * _horizontalSpeed);
        }

        public override void Enter()
        {
            _rigidbody.useGravity = false;
            _rigidbody.velocity = _rigidbody.velocity / 4;
        }
    }
}