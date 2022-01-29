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
        private GroundMovement _groundMovement;
        private WaterMovement _waterMovement;
        public BaseMovement Movement { get; private set; }
        private void Start()
        {
            _groundMovement = GetComponent<GroundMovement>();
            _waterMovement = GetComponent<WaterMovement>();
            Movement = _groundMovement;
        }

        private void Update()
        {
            Vector2 input = Vector2.zero;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            Movement.Move(input);    
        }
    }
}