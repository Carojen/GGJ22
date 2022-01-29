using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{    
    public abstract class BaseMovement : MonoBehaviour
    {
        public abstract MovementState MType();
        public abstract void Move(Vector2 input);
        protected Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
