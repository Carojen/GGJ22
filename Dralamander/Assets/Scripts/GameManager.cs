using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace GGJ22
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;
	//	public StudioEventEmitter ambienceEmitter;
		[SerializeField, HideInInspector] bool waterness = false;
		
		public static GameManager Instance
        {
			get; private set;
        }

		void Awake()
		{
			Instance = this;
	//		ambienceEmitter = GameObject.FindGameObjectWithTag ("AmbientSound").GetComponent<StudioEventEmitter> ();
		}

        private void Start()
        {
            _player = FindObjectOfType<Player>();
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
	//			ambienceEmitter.SetParameter ("Waterness", 1.0f);
				FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Waterness", 1.0f);
			}
		}
		
		public void SetIsDry()
		{
			if (waterness == true)
			{
				waterness = false;
	//			ambienceEmitter.SetParameter ("Waterness", 0.0f);
				FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Waterness", 0.0f);
			}
		}
		

	
	public EventReference irriteradEvent;

    public EventReference krockEvent;

    public EventReference movementEvent;
	
    public EventReference splashUpEvent;

    public EventReference splashDownEvent;
	
    public EventReference jumpEvent;

    public EventReference breakingDamEvent;
	
    public EventReference bubbelEvent;

    public EventReference disappearingWaterEvent;
	
    public EventReference moistEvent;

    public EventReference breakEvent;

    public EventReference pickUpEvent;
		

	public void AudioIrriterad()
	{
//	 emitter.SetEvent(irriteradEvent);
//	 emitter.Play();
		FMODUnity.RuntimeManager.PlayOneShot(irriteradEvent);
	}
	public void AudioKrock()
{
//        emitter.SetEvent(krockEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(krockEvent);
}
	public void AudioMovement()
	{
//        emitter.SetEvent(movementEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(movementEvent);
	}
		public void AudioJump()
	{
 //       emitter.SetEvent(jumpEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(jumpEvent);
	}
		public void AudioSplashUp()
	{
 //       emitter.SetEvent(splashUpEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(splashUpEvent);
	}
		public void AudioSplashDown()
	{
 //       emitter.SetEvent(splashDownEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(splashDownEvent);
	}
		public void AudioBreakingDam()
	{
 //       emitter.SetEvent(breakingDamEvent);
//        emitter.Play();
		FMODUnity.RuntimeManager.PlayOneShot(breakingDamEvent);
	}
		public void AudioBubbel()
	{
 //       emitter.SetEvent(bubbelEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(bubbelEvent);
	}
		public void AudioDisappearingWater()
	{
//        emitter.SetEvent(disappearingWaterEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(disappearingWaterEvent);
	}
		public void AudioMoist()
	{
 //       emitter.SetEvent(moistEvent);
//        emitter.Play();
		FMODUnity.RuntimeManager.PlayOneShot(moistEvent);
	}
		public void AudioBreak()
	{
 //       emitter.SetEvent(breakEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(breakEvent);
	}
		public void AudioPickUp()
	{
 //       emitter.SetEvent(pickUpEvent);
 //       emitter.Play();
 		FMODUnity.RuntimeManager.PlayOneShot(pickUpEvent);
	}
	}
}

