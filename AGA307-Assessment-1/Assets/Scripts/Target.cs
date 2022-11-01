using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using static TargetManager;

public class Target : MonoBehaviour
{
    public float targetHealth = 20;
    public float size;

    TargetManager _TM;
    GameManager _GM;
    public Difficulty difficulty;
    public Vector3 baseSize;

    private void Start()
    {
        _TM = FindObjectOfType<TargetManager>();
        _GM = FindObjectOfType<GameManager>();
        SetUp();
    }

    

    void SetUp()
    {
        print(difficulty);

        switch(difficulty)
        {
            case Difficulty.Easy:
                size = 2;
                break;
            case Difficulty.Medium:
                size = 1;
                break;
            case Difficulty.Hard:
                size = 0.5f;
                break;
        }

        baseSize = this.transform.localScale;


        this.transform.localScale = baseSize * size;
    }


   void SetUpAI()
    {
        //startPos = transform;
        //endPos = _EM.GetRandomSpointPoint();
        //moveToPos = endPos;
    }


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
