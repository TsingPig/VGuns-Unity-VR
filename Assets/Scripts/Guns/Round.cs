using System;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Round : MonoBehaviour
{

    public GameObject self;
    
    public GameObject explosion;
    
    public float Waittime;

    public Rigidbody Rigidbody;

    public int damage;


    void OnCollisionEnter(Collision other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        
        

        if(target != null) {
            Debug.Log("Hit");
    
            target.Hit(damage);
    
            Instantiate(explosion, self.transform.position, self.transform.rotation);

            
            Destroy(gameObject); // Deletes the round
        }
        

        XRTarget XRTarget = other.gameObject.GetComponent<XRTarget>();
        // Only attempts to inflict damage if the other game object has
        // the 'EnemyAi' component
        if(XRTarget != null) {
            Debug.Log("Hit");
    
            XRTarget.Hit(damage);
            
            Destroy(gameObject); // Deletes the round

        }

        EnemyAi EnemyAi = other.gameObject.GetComponent<EnemyAi>();
        // Only attempts to inflict damage if the other game object has
        // the 'EnemyAi' component
        if(EnemyAi != null) {
            Debug.Log("Hit");
    
            EnemyAi.TakeDamage(damage);
            
            Destroy(gameObject); // Deletes the round

        }
        
      
    }
}