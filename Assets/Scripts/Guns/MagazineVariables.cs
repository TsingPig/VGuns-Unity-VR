using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Guns
{

    public class MagazineVariables : MonoBehaviour
    {
        //Import Class
        public Gun gunVariables;
        
        // The Gun
        XRGrabInteractable m_InteractableBase;
    
        //Magazine Colliders
        public Collider Magazine_Collider_Physical = null;

        // How far forward the muzzle is from the centre of the gun
        private float muzzleOffset;
    
        //MagazineVariables
        public MagazineVariables MagVar;
    
        //Trigger Functions
        float m_TriggerHeldTime;
        bool m_TriggerDown;

        //Graphics
        public GameObject muzzleFlash;
        public TextMeshPro text;
    
        //Reference
        public Transform attackPoint;
        public GameObject GunPov;
    
        [Header("Magazine")]
        public GameObject round;
        public int ammunition;

        [Range(0.5f, 10)] public float reloadTime;

        private int remainingAmmunition;

        [Header("Shooting")]
        // How many shots the gun can make per second
        [Range(0.25f, 25)] public float fireRate;

        // The number of rounds fired each shot
        public int roundsPerShot;

        [Range(0.5f, 100)] public float roundSpeed;

        // The maximum angle that the bullet's direction can vary,
        // in both the horizontal and vertical axes
        [Range(0, 45)] public float maxRoundVariation;

        // The next time that the gun is able to shoot at
        private float nextShootTime = 0;
        
        public void ChangeStats()
        {
            //gunVariables.Magazine_Collider_Physical = Magazine_Collider_Physical;
            gunVariables.muzzleFlash = muzzleFlash;
            gunVariables.round = round;
            gunVariables.ammunition = ammunition;
            gunVariables.reloadTime = reloadTime;
            gunVariables.fireRate = fireRate;
            gunVariables.roundsPerShot = roundsPerShot;
            gunVariables.roundSpeed = roundSpeed;
            gunVariables.maxRoundVariation = maxRoundVariation;
        }

        public void RemoveMag()
        {
            //gunVariables.Magazine_Collider_Physical = null;
            gunVariables.muzzleFlash = null;
            gunVariables.round = null;
            gunVariables.ammunition = 0;
            gunVariables.reloadTime = 0;
            gunVariables.fireRate = 0;
            gunVariables.roundsPerShot = 0;
            gunVariables.roundSpeed = 0;
            gunVariables.maxRoundVariation = 0;
        }

        public void ChangeMagVar()
        {
            //gunVariables.MagVar = MagVar;
        }

    }
}
