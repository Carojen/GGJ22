using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) _player.Respawn();
        }
    }
}