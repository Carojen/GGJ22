using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace GGJ22
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;
		public StudioEventEmitter ambienceEmitter;
		public StudioEventEmitter playerEmitter;
		public bool waterness = false;
		
		void Awake()
		{
			ambienceEmitter = GameObject.FindGameObjectWithTag ("AmbientSound").GetComponent<StudioEventEmitter> ();
		}

        private void Start()
        {
            _player = FindObjectOfType<Player>();
			playerEmitter = _player.GetComponent<StudioEventEmitter> ();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) _player.Respawn();
        }
	
		public void SetIsWater()
		{
			if (waterness == false)
			{
				waterness = true;
				ambienceEmitter.SetParameter ("Waterness", 1.0f);
				playerEmitter.SetParameter ("Waterness", 1.0f);
			}
		}
		
		public void SetIsDry()
		{
			if (waterness == true)
			{
				waterness = false;
				ambienceEmitter.SetParameter ("Waterness", 0.0f);
				playerEmitter.SetParameter ("Waterness", 0.0f);
			}
		}
		
	}
}

