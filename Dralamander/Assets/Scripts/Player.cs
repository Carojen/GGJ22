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
        private Animator _animator;

        private BaseMovement _currentMovement;
        private HashSet<Collision> _currentValidGround = new HashSet<Collision>();
        private int _waterCount = 0;

        private Collision _currentWallCollision;
        private float _wallHitTime;

        private Vector2 _moveInput = Vector2.zero;
        private float _jumpInput = 0f;
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
            _animator = GetComponentInChildren<Animator>(true);
            Init();
        }

        private void Init()
        {
            GameManager.Instance.Wetness = false;
            _animator.Play("Base Layer.Idle");
            Movement = _airMovement;
            _waterCount = 0;
            Movement.Reset();
        }

        private void FixedUpdate()
        {
            _moveInput.x = Input.GetAxis("Horizontal");
            _moveInput.y = Input.GetAxis("Vertical");
            _jumpInput = Input.GetAxis("Jump");
            Movement.Move(_moveInput);
            Movement.TryJump(_jumpInput, ref _wallHitTime, _currentWallCollision);
            Movement.ClampVelocity();
            Movement.UpdateRotation();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Ground")
            {
                var direction = collision.GetContact(0).normal;
                if (direction.y > 0 && Mathf.Abs(direction.x) < direction.y) //Valid ground if collision force is directed mostly up
                {
                    _currentValidGround.Add(collision);
                    if (Movement.MType() != MovementState.Water) Movement = _groundMovement;
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
                if (Movement.MType() == MovementState.Ground) { Movement = _airMovement; _animator.Play("Base Layer.Swim"); }                
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "WaterLine":
                    _waterCount++;
                    Movement = _waterMovement;
                    GameManager.Instance.PlayEvent(GameManager.SplashDown, false);
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
                    if (_waterCount == 0)
                    {
                        _wallHitTime = Time.time;
                        Movement = _airMovement;
                        GameManager.Instance.PlayEvent(GameManager.SplashUp, false);
                    }
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