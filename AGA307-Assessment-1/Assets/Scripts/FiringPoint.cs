using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject hitSparks;
    public float projectileSpeed = 1000f;
    public LineRenderer laser;
    public GameObject gunType;

    public bool hitSphere;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireRigidProjectile();
            gunType.GetComponent<Renderer>().material.color = Color.blue;

        }

        if (Input.GetButtonDown("Fire2"))
        {
            FireRayCast();
            gunType.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    void FireRigidProjectile()
    {
        //create a reference to hold our instantatied object
        //GameObject projectileInstance;

        //instantiate our projectile pregab at this object's position and
        //rotation
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);

        //get the rigidbody attached to the projectile and add force to it
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }

    void FireRayCast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.collider.name + " which was " + hit.distance + "units away");

            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, hit.point);
            GameObject party = Instantiate(hitSparks, hit.point, hit.transform.rotation);
            Destroy(party, 2);
        }

        if (hit.collider.name == "SphereRayCast")
        {
            hitSphere = true;
        }
        else hitSphere = false;
    }


}

