using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class Player : MonoBehaviour
    {
        private Vector3 _startPosition;
        private GroundMovement _groundMovement;
        private WaterMovement _waterMovement;
        private AirMovement _airMovement;

        private BaseMovement _currentMovement;

        private float _logTimer = 0.0f;
        public BaseMovement Movement
        {
            get => _currentMovement;
            private set
            {
                if (value != _currentMovement) { _currentMovement = value; Movement.Enter(); Debug.Log($"Enter state {_currentMovement }"); }

            }
        }
        private void Start()
        {
            _startPosition = transform.position;
            _groundMovement = GetComponent<GroundMovement>();
            _waterMovement = GetComponent<WaterMovement>();
            _airMovement = GetComponent<AirMovement>();
            Init();
        }

        private void Init()
        {
            Movement = _airMovement;
            Movement.Reset();
            _logTimer = 0f;
        }

        private void Update()
        {
            _logTimer++;
            Vector2 input = Vector2.zero;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            Movement.Move(input);

            if(_logTimer > 1000)
            {
                _logTimer = 0;
                Debug.Log($"Input: ({input.x}, {input.y}  Velocity: {Movement}");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Ground" && Movement.MType() != MovementState.Water) Movement = _groundMovement;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "WaterLine":
                    Movement = _waterMovement;
                    break;
                case "Ground":
                        if(Movement.MType() != MovementState.Water) Movement = _groundMovement;
                    break;
                default:
                    break;
            }

        }

        private void OnTriggerExit(Collider other)
        {
            switch(other.tag)
            {
                case "OutOfBounds": 
                    Respawn(); 
                    break;

                case "WaterLine":
                    Movement = _airMovement;
                    break;
                default:
                    break;

            }
        }

        public void Respawn()
        {
            transform.position = _startPosition;
            Init();
        }
    }
}