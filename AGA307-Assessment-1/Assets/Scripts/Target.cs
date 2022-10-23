using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float targetHealth = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile"))
        {
            targetHealth -= 2;
        }
    }

    private void Update()
    {
        if(targetHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
