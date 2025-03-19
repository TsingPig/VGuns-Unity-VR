using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    
                foreach (GameObject enemy in enemies){
                    enemy.SetActive(false);
                }
                
                ray_Right.SetActive(true);
                ray_Left.SetActive(true);

                LocomotionSystem.SetActive(false);

                TeleportManagerLeft.SetActive(false);
                TeleportManagerRight.SetActive(false);
                
                deathScreen.SetActive(true);
                
                StartCoroutine(Wait());
                
                //SceneManager.LoadScene(0);
            }
            else
            {
                if (!deathScreen.activeSelf)
                {
                                     
                    enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    
                    foreach (GameObject enemy in enemies){
                        enemy.SetActive(false);
                    }


                    ray_Right.SetActive(true);
                    ray_Left.SetActive(true);

                    LocomotionSystem.SetActive(false);

                    TeleportManagerLeft.SetActive(false);
                    TeleportManagerRight.SetActive(false);
                
                    deathScreen.SetActive(true);
                    
                    StartCoroutine(Wait());

                    //SceneManager.LoadScene(0);
                }

            }

        }
    }


    IEnumerator Wait()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5); 
    }


    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage) {
        health -= damage;
    }
    
}