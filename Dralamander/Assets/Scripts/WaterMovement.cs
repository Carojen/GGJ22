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
            _rigidbody.AddForce(input);
        }

        public override void Enter()
        {
            _rigidbody.useGravity = false;
        }
    }
}