using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace GGJ22
{
    public class GameManager : MonoBehaviour
    {
        private Player _player;

        private bool _wetness = false;
        public bool Wetness
        {
            get => _wetness;
            set { if (_wetness != value) RuntimeManager.StudioSystem.setParameterByName("Waterness", Wetness ? 1f : 0f); _wetness = value; }
        }

        public static GameManager Instance
        {
            get; private set;
        }

        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) _player.Respawn();
        }

        public void PlayEvent(EventReference audioEvent, bool wetness)
        {
            Wetness = wetness;
            RuntimeManager.PlayOneShot(audioEvent);
        }

        [SerializeField]
        private EventReference irriteradEvent;
        public static EventReference Annoyed => Instance.irriteradEvent;
        
        [SerializeField]
        private EventReference krockEvent;
        public static EventReference Collision => Instance.krockEvent;
        
        [SerializeField]
        private EventReference movementEvent;
        public static EventReference Movement => Instance.movementEvent;
                
        [SerializeField]
        private EventReference splashUpEvent;
        public static EventReference SplashUp => Instance.splashUpEvent;
        
        [SerializeField]
        private EventReference splashDownEvent;
        public static EventReference SplashDown => Instance.splashDownEvent;
        
        [SerializeField]
        private EventReference jumpEvent;
        public static EventReference Jump => Instance.jumpEvent;
        
        [SerializeField]
        private EventReference breakingDamEvent;
        public static EventReference BreakingDam => Instance.breakingDamEvent;
        
        [SerializeField]
        private EventReference bubbelEvent;
        public static EventReference Bubble => Instance.bubbelEvent;
        
        [SerializeField]
        private EventReference disappearingWaterEvent;
        public static EventReference RecedingWater => Instance.disappearingWaterEvent;
        
        [SerializeField]
        private EventReference moistEvent;
        public static EventReference Moist => Instance.moistEvent;
        
        [SerializeField]
        private EventReference breakEvent;
        public static EventReference Break => Instance.breakEvent;
        
        [SerializeField]
        private EventReference pickUpEvent;
        public static EventReference PickUp => Instance.pickUpEvent;        
    }
}