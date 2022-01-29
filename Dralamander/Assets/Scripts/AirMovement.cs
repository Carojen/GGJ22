using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class AirMovement : BaseMovement
    {
        public override MovementState MType() => MovementState.Air;
        public override void Enter()
        {
            _rigidbody.useGravity = true;            
        }

        public override void Move(Vector2 input)
        {
            
        }
    }
}