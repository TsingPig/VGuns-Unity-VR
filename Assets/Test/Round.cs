using System;
using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Round : MonoBehaviour
{

    public GameObject self;

    public GameObject explosion;

    public Rigidbody Rigidbody;

    public int damage;


    void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();

        if (target != null)
        {
            Debug.Log("Hit");

            target.Hit(damage);

            Instantiate(explosion, self.transform.position, self.transform.rotation);

            Destroy(gameObject); // Deletes the round
        }
        else
        {
            StartCoroutine(Wait());
        }

        XRTarget XRTarget = other.gameObject.GetComponent<XRTarget>();
        // Only attempts to inflict damage if the other game object has
        // the 'EnemyAi' component
        if (XRTarget != null)
        {
            Debug.Log("Hit");

            XRTarget.Hit(damage);

            Destroy(gameObject); // Deletes the round

        }

        else
        {
            StartCoroutine(Wait());
        }

        EnemyAi EnemyHealth = other.gameObject.GetComponent<EnemyAi>();
        // Only attempts to inflict damage if the other game object has
        // the 'EnemyAi' component
        if (EnemyHealth != null)
        {
            Debug.Log("Hit");

            EnemyHealth.TakeDamage(damage);

            Destroy(gameObject); // Deletes the round

        }
        else
        {
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait() //  <-  its a standalone method
    {
        Debug.Log("Hello");
        //wait 3 seconds
        yield return new WaitForSeconds(5);
        Debug.Log("Goodbye");
        Destroy(gameObject); // Deletes the round
    }
}