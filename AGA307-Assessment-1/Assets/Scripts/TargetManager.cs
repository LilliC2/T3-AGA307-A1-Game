using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class TargetManager : Singleton<TargetManager>
{


    public Transform[] targetSpawnPoints;
    public GameObject[] targetTypes;
    public List<GameObject> targets;

    int scoreBonus = 10;
    float fireBallDamage;
    float greenOrbDamage;
    float blueProjectileDamage;
    float laserDamage;
    float returnDamage;

    //public Difficulty difficulty;

    UIManager _UI;
    GameManager _GM;
    public enum TargetShape
    {
        Cylinder, Square, Triangle, Prism
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _UI = FindObjectOfType<UIManager>();
        _GM = FindObjectOfType<GameManager>();

        SetUp();

        targets.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        print(targets.Count);
        _UI.UpdateTargetCount(targets.Count);
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
        targets.Add(target);

        _UI.UpdateTargetCount(targets.Count);
    }

    void SetUp()
    {
        switch (_GM.difficulty)
        {
            case Difficulty.Easy:
                fireBallDamage = 40;
                greenOrbDamage = 24;
                blueProjectileDamage = 56;
                laserDamage = 48;

                break;
            case Difficulty.Medium:
                fireBallDamage = 20;
                greenOrbDamage = 12;
                blueProjectileDamage = 28;
                laserDamage = 24;
                break;
            case Difficulty.Hard:
                fireBallDamage = 10;
                greenOrbDamage = 6;
                blueProjectileDamage = 14;
                laserDamage = 12;
                break;
        }
    }

    public float TargetHit(string _projectileType)
    {
        switch(_projectileType)
        {
            case "FireballOrange(Clone)":
                returnDamage = fireBallDamage;
                break;
            case "GreenOrb(Clone)":
                returnDamage = greenOrbDamage;
                break;
            case "Projectile(Clone)":
                returnDamage = blueProjectileDamage;
                break;
            case "Laser":
                returnDamage = laserDamage;
                print("HIT BY LASER");
                break;
        }

        print("damage that should be taken: " + returnDamage);

        return returnDamage;
    }

    public void DesotryTarget(GameObject _target)
    {
        if (targets.Count == 0)
            return;

        targets.Remove(_target);
        Destroy(_target);

        _GM.ScoreCalcuation(scoreBonus);
        _GM.AddToTimer();

        _UI.UpdateTargetCount(targets.Count);
        

    }

    public Transform GetRandomSpointPoint()
    {
        //return sppawnpoint between 0 and length of array
        return targetSpawnPoints[Random.Range(0, targetSpawnPoints.Length)];
    }


}
