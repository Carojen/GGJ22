using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class CameraSideScroll : MonoBehaviour
    {
        private Player _player;
        private void Start()
        {
            _player = FindObjectOfType<GGJ22.Player>();
        }
        void Update()
        {
            Vector3 newPosition = transform.position;
            newPosition.x = _player.transform.position.x;
            newPosition.y = _player.transform.position.y;
            transform.position = newPosition;
        }
    }
}