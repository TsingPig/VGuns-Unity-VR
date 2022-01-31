
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
   
    public float health;
    
    public TextMeshPro livesText;

    public AudioManager AudioManager;

    public bool dead;

    private void Awake()
    {
        dead = false;
    }

    private void Update()
    {
       livesText.text = "Health: " + health;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        AudioManager.Play("EnemyDie");
        Destroy(gameObject);
    }


}
