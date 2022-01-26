using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class XRTarget : MonoBehaviour {
    
    public float health;
    
    public TextMeshPro livesText;
    
    public GameObject deathScreen;

    public GameObject LocomotionSystem;

    public GameObject ray_Right;
    public GameObject ray_Left;
        
    public GameObject TeleportManagerLeft;
    public GameObject TeleportManagerRight;

    public GameObject[] enemies;


    void Update()
    {
        livesText.text = "Health: " + health;
        
        if(health <= 0) {
            if (deathScreen.activeSelf)
            {

                ray_Right.SetActive(true);
                ray_Left.SetActive(true);

                LocomotionSystem.SetActive(false);

                TeleportManagerLeft.SetActive(false);
                TeleportManagerRight.SetActive(false);
                
                deathScreen.SetActive(true);
            }
            else
            {
                if (!deathScreen.activeSelf)
                {
                    Wait();

                    ray_Right.SetActive(true);
                    ray_Left.SetActive(true);

                    LocomotionSystem.SetActive(false);

                    TeleportManagerLeft.SetActive(false);
                    TeleportManagerRight.SetActive(false);
                
                    deathScreen.SetActive(true);
                }

            }

        }
    }
    
    IEnumerable<WaitForSeconds> Wait()
    {
        yield return new WaitForSeconds(1.0f); // waits before continuing in seconds
        // code to do after the wait
    }



    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage) {
        health -= damage;
    }
}