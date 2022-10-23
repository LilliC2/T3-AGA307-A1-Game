using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Update()
    {
        Destroy(this.gameObject,5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //check if collided with tag target
        if(collision.collider.CompareTag("Target"))
        {

            //change target colour
            collision.collider.GetComponent<Renderer>().material.color = Color.red;

            //destroy projectile
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            collision.collider.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
