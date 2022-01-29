using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerAudio : MonoBehaviour
{
	private StudioEventEmitter emitter; 
	
	private void Awake()
	{
        emitter = GetComponent<StudioEventEmitter> ();
		if(emitter == null)
		{
			Debug.LogWarning("EventEmitter is missing on Player.");
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
