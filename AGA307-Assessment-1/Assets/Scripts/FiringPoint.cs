using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    
    public GameObject hitSparks;
    public float projectileSpeed = 1000f;
    public LineRenderer laser;
    public GameObject gunType;

    UIManager _UI;
    
    public GameObject[] projectileType;

    int fireType;
    public string gunTypeName;


    public bool hitSphere;

    private void Start()
    {
        _UI = FindObjectOfType<UIManager>();
        gunTypeName = "Blue Ball";
        _UI.UpdateGunType(gunTypeName);
    }

    // Update is called once per frame
    void Update()
    {

        //player changing gun projectile
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fireType = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            fireType = 1;
            gunTypeName = "Fireball";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fireType = 2;
            gunTypeName = "Green Orb";
        }

        if (Input.GetButtonDown("Fire1"))
        {
           

            FireRigidProjectile(fireType);
            gunType.GetComponent<Renderer>().material.color = Color.blue;

        }

        if (Input.GetButtonDown("Fire2"))
        {
            FireRayCast();
            gunType.GetComponent<Renderer>().material.color = Color.red;
            gunTypeName = "Laser";
        }

        _UI.UpdateGunType(gunTypeName);
    }

    void FireRigidProjectile(int _type)
    {
        //create a reference to hold our instantatied object
        //GameObject projectileInstance;

        //instantiate our projectile pregab at this object's position and
        //rotation
        GameObject projectileInstance = Instantiate(projectileType[_type], transform.position, transform.rotation);

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
            StopAllCoroutines();
            StartCoroutine(StopLaser());
            GameObject party = Instantiate(hitSparks, hit.point, hit.transform.rotation);
            Destroy(party, 2);
        }

        if (hit.collider.name == "SphereRayCast")
        {
            hitSphere = true;
        }
        else hitSphere = false;

    }

    IEnumerator StopLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        laser.gameObject.SetActive(false);
    }
}

