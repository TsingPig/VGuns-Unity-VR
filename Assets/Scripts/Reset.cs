using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Reset : MonoBehaviour
{
    public UnityEngine.Vector3 StartLocation;

    private void OnCollisionEnter(Collision coll)
    {
        //If the collision is with the ball
        if (coll.gameObject.tag == "XRRig" || coll.gameObject.tag == "Weapon")
        {
            //set the balls position to the starting location
            coll.transform.position = StartLocation;
        }
    }
}