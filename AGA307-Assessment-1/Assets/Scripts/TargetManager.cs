using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{


    public Transform[] targetSpawnPoints;
    public GameObject[] targetTypes;
    public List<GameObject> targets;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) SpawnTarget();
        
    }

    void SpawnTarget()
    {
        int rndTargetSpawn = Random.Range(0, targetSpawnPoints.Length);
        int rndTargetTypes = Random.Range(0, targetTypes.Length);

        GameObject target = Instantiate(targetTypes[rndTargetTypes], targetSpawnPoints[rndTargetSpawn].position, targetSpawnPoints[rndTargetSpawn].rotation);
        
    }

}
