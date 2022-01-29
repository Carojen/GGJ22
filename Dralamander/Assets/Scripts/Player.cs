using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public enum MovementState
    {
        Ground,
        Water
    }
    public class Player : MonoBehaviour
    {
        private Vector3 _startPosition;
        private GroundMovement _groundMovement;
        private WaterMovement _waterMovement;
        public BaseMovement Movement { get; private set; }
        private void Start()
        {
            _startPosition = transform.position;
            _groundMovement = GetComponent<GroundMovement>();
            _waterMovement = GetComponent<WaterMovement>();
            Init();
        }

        private void Init()
        {
            Movement = _groundMovement;
            Movement.Reset();
        }

        private void Update()
        {
            Vector2 input = Vector2.zero;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            Movement.Move(input);    
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "WaterLine")
            {
                Movement = _waterMovement;
                Movement.Enter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "OutOfBounds")
            {
                Respawn();
                return;
            }
            if(other.tag == "WaterLine")
            {
                Movement = _groundMovement;
                Movement.Enter();
            }
        }

        private void Respawn()
        {
            transform.position = _startPosition;
            Init();
        }
    }
}