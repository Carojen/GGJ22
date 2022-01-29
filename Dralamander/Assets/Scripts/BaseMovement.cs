using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{    
    public abstract class BaseMovement : MonoBehaviour
    {        
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
