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
        private HashSet<Collision> _currentValidGround = new HashSet<Collision>();
        private int _waterCount = 0;

        private float _jumpTimer;
        private Collision _currentWallCollision;
        private float _wallHitTime;

        private Vector2 _moveInput = Vector2.zero;
        private float _jumpInput = 0f;

        private float _lastLog = 0;
        private int _logFrequency = 30;
        public BaseMovement Movement
        {
            get => _currentMovement;
            private set { if (value != _currentMovement) { _currentMovement = value; Movement.Enter(); } }
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
            _waterCount = 0;
            Movement.Reset();
            _lastLog = Time.time;
        }

        private void Update()
        {
            _moveInput.x = Input.GetAxis("Horizontal");
            _moveInput.y = Input.GetAxis("Vertical");
            _jumpInput = Input.GetAxis("Jump");
            Movement.Move(_moveInput);
            Movement.TryJump(_jumpInput, _currentWallCollision, _wallHitTime);

            if (Time.time > _lastLog + _logFrequency)
            {
                _lastLog = Time.time;
                Debug.Log($"Input: ({_moveInput.x}, {_moveInput.y}, ({_jumpInput}))  State: {Movement}  waters: {_waterCount} blocks: {_currentValidGround.Count}");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Ground")
            {
                var direction = collision.GetContact(0).normal;
                if (direction.y > 0 && Mathf.Abs(direction.x) < direction.y) //Valid ground if collision force is directed mostly up
                {
                    _currentValidGround.Add(collision);
                    if (Movement.MType() != MovementState.Water)
                        Movement = _groundMovement;
                }
                else if (direction.y < Mathf.Abs(direction.x)) //Wall hit if collision is mostly sidewards
                {
                    _currentWallCollision = collision;
                    _wallHitTime = Time.time;
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.tag == "Ground")
            {
                if (_currentWallCollision == collision)
                {
                    _currentWallCollision = null;
                    _wallHitTime = 0f;
                }
                _currentValidGround.Remove(collision);
                if (Movement.MType() == MovementState.Ground) Movement = _airMovement;                
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "WaterLine":
                    _waterCount++;
                    Movement = _waterMovement;
                    break;
                default:
                    break;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            switch (other.tag)
            {
                case "OutOfBounds":
                    Respawn();
                    break;

                case "WaterLine":
                    _waterCount--;
                    if (_waterCount == 0) Movement = _airMovement;
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