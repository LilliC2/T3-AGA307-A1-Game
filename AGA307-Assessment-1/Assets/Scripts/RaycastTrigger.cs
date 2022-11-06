using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RaycastTrigger : MonoBehaviour
{
    public GameObject sphere;
    public int cycle;

    public bool raycastTrue;

    FiringPoint _FP;
    public GameObject FiringPoint;

    private void Start()
    {
        FiringPoint = GameObject.Find("FiringPoint");
        _FP = FiringPoint.GetComponent<FiringPoint>();
    }

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_FP.hitSphere == true && Input.GetKeyDown(KeyCode.E)) cycle++;

            print(cycle);

            switch(cycle)
            {
                case 0:
                    sphere.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 1:
                    sphere.GetComponent<Renderer>().material.color = Color.green;
                    sphere.transform.localScale += Vector3.one * 0.01f;

                    break;
                case 2:
                    sphere.GetComponent<Renderer>().material.color = Color.blue;
                    sphere.transform.localScale -= Vector3.one * 0.01f;
                    break;
                case >=3:
                    cycle = 0;
                    break;
            }

            

        }
    }

}
