using UnityEngine;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine;
using System.Collections;
using Guns;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour {
    public enum ShootState {
        Ready,
        Shooting,
        Reloading
    }
    
    // The Gun
    XRGrabInteractable m_InteractableBase;
    
    //Gun Colliders
    //public Collider Gun_Collider_Physical = null;
    
    //Magazine Colliders
    //public Collider Magazine_Collider_Physical = null;

    // How far forward the muzzle is from the centre of the gun
    private float muzzleOffset;
    
    //MagazineVariables
    //public MagazineVariables MagVar;
    
    //Trigger Functions
    float m_TriggerHeldTime;
    bool m_TriggerDown;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshPro text;
    
    //Reference
    public GameObject GunPov;

    public AudioManager AudioManager;
        
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

    private ShootState shootState = ShootState.Ready;

    // The next time that the gun is able to shoot at
    private float nextShootTime = 0;

    void Start() {
        //muzzleOffset = attackPoint.GetComponent<Renderer>().bounds.extents.z;
        remainingAmmunition = ammunition;

        AudioManager = FindObjectOfType<AudioManager>();
    }

    void Update() {
        switch(shootState) {
            case ShootState.Shooting:
                // If the gun is ready to shoot again...
                if(Time.time > nextShootTime) {
                    shootState = ShootState.Ready;
                }
                break;
            case ShootState.Reloading:
                // If the gun has finished reloading...
                if(Time.time > nextShootTime) {
                    remainingAmmunition = ammunition;
                    shootState = ShootState.Ready;
                }
                break;
        }
        
        //m_Animator = GetComponent<Animator>(); //(For Animations Down the line)
        m_InteractableBase = GetComponent<XRGrabInteractable>();
        m_InteractableBase.selectExited.AddListener(DroppedGun);
        m_InteractableBase.activated.AddListener(TriggerPulled);
        m_InteractableBase.deactivated.AddListener(TriggerReleased);
        
        //Show leftover bullets
        text.SetText(remainingAmmunition + " / " + ammunition);
        
        //update if holding trigger
        //if (m_TriggerDown)
        //{
        //    m_TriggerHeldTime += Time.deltaTime;
        //    if (m_TriggerHeldTime >= k_HeldThreshold)
        //    {
        //        if (!muzzleFlash.isPlaying)
        //         {
        //             muzzleFlash.Play();    
        //          }
        //      }
        //  }
    }
    
    /// Attempts to fire the gun
    public void Shoot() {
        // Checks that the gun is ready to shoot
        if(shootState == ShootState.Ready) {
            for(int i = 0; i < roundsPerShot; i++) {
                
                AudioManager.Play("Gun Fire");
                // Instantiates the round at the muzzle position
                GameObject spawnedRound = Instantiate(round, GunPov.transform.position, GunPov.transform.rotation);
                //GameObject muzzleflash = Instantiate(muzzleFlash, GunPov.transform.position, GunPov.transform.rotation);

                // Add a random variation to the round's direction
                spawnedRound.transform.Rotate(new Vector3(
                    Random.Range(-1f, 1f) * maxRoundVariation,
                    Random.Range(-1f, 1f) * maxRoundVariation,
                    0
                ));

                Rigidbody rb = spawnedRound.GetComponent<Rigidbody>();
                rb.velocity = spawnedRound.transform.forward * roundSpeed;
            }

            remainingAmmunition--;
            if(remainingAmmunition > 0) {
                nextShootTime = Time.time + (1 / fireRate);
                shootState = ShootState.Shooting;
            } else {
                Reload();
            }
        }
    }

    /// Attempts to reload the gun
    public void Reload() {
        // Checks that the gun is ready to be reloaded
        if(shootState == ShootState.Ready) {
            nextShootTime = Time.time + reloadTime;
            shootState = ShootState.Reloading;
            text.SetText("Reloading");
            AudioManager.Play("Reload");
        }
    }
    
    //Animating Trigger
    public void TriggerReleased(DeactivateEventArgs args)
    {
        //m_Animator.SetTrigger(k_AnimTriggerUp);
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
    }
    
    
    //Animating Trigger
    public void TriggerPulled(ActivateEventArgs args)
    { 
        //m_Animator.SetTrigger(k_AnimTriggerDown);
        m_TriggerDown = true;
    }
    
    
    // In case the gun is dropped while in use.
    public void DroppedGun(SelectExitEventArgs args)
    {
        //m_Animator.SetTrigger(k_AnimTriggerUp);
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
    }

    
    //     void OnTriggerEnter(Collider magazine)
    //    {
    //        if (magazine.gameObject.CompareTag("Magazine"))
    //        {
    //             magazine.gameObject.GetComponent<MagazineVariables>().ChangeMagVar();
    //         }
    //     }

    
    //Events that happen when the magazine is inserted
    public void MagazineInsert()
    {
        
        
        //Magvar
        //MagVar.ChangeStats();
            
        //reload gun
        //Reload();
        
        //Message
        //Debug.Log("Magazine Has Been Inserted");
        
        
        //Enable Colliders for Magazine
        //Gun_Collider_Physical.enabled = false;
        
        //Disable Magazine Colliders
        //Magazine_Collider_Physical.enabled = false;
        
        //Reload();
            
    }
    
    
    //Events that happen when the magazine is inserted
    public void MagazineExit()
    {
        //Magvar other
        //MagVar.RemoveMag();
            
        //Wait For Colliders to appear again
        //Thread.Sleep(100);

        //Enable Colliders for Magazine
        //Gun_Collider_Physical.enabled = true;
        
        //Enable Colliders for Magazine
       // Magazine_Collider_Physical.enabled = true;

        //Message
        //Debug.Log("Magazine Has Been Removed"); 
    }
    

}
