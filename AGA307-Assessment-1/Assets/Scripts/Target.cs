using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;
using static TargetManager;

public class Target : MonoBehaviour
{
    public float myHealth = 100;
    public float size;

    TargetManager _TM;
    GameManager _GM;
    //public Difficulty difficulty;
    public Vector3 baseSize;
    public TargetShape targetShape;

    public GameObject player;
    Vector3 playerPos;
    string currentDifficulty;

    public Transform moveToPos;    //need for random patrol
    Transform startPos;     //need for loop patrol
    Transform endPos;       //need for loop patrol
    float mySpeed;

    private void Start()
    {
        _TM = FindObjectOfType<TargetManager>();
        _GM = FindObjectOfType<GameManager>();
        player = GameObject.Find("FP Player");


        currentDifficulty = _GM.difficulty.ToString();
        SetUp();
        SetUpAI();
        StartCoroutine(Move());
        baseSize = this.transform.localScale;

    }

    private void Awake()
    {
        baseSize = this.transform.localScale;
    }

    public void SetUp()
    {
        //print(difficulty);

        switch(_GM.difficulty)
        {
            case Difficulty.Easy:
                size = 2;
                mySpeed = 1;
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case Difficulty.Medium:
                size = 1;
                mySpeed = 3;
                this.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case Difficulty.Hard:
                size = 0.5f;
                mySpeed = 5;
                this.GetComponent<Renderer>().material.color = Color.green;
                break;
        }




        this.transform.localScale = baseSize * size;

        //switch(targetShape)
        //{
        //    case TargetShape.Prism:
        //        transform.Rotate(90, 0, 0);
        //        break;
        //    case TargetShape.Cylinder:
        //        transform.Rotate(90, 0, 0);
        //        break;
        //}
    }

    void SetUpAI()
    {
        startPos = transform;
        endPos = _TM.GetRandomSpointPoint();
        moveToPos = endPos;
    }

    IEnumerator Move()
    {
        moveToPos = _TM.GetRandomSpointPoint();

        while (Vector3.Distance(transform.position, moveToPos.position) > 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * mySpeed);
            Vector3 targetDirection = (moveToPos.position - transform.position).normalized;
            //var rotation = Quaternion.LookRotation(targetDirection);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * mySpeed);


            //transform.rotation = Quaternion.LookRotation(newDirection);
            yield return null;
        }
        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Projectile"))
        {
            float damage = _TM.TargetHit(collision.collider.name);
            myHealth -= damage;
            print(myHealth);
        }

        if (myHealth <= 0)
        {
            _TM.DesotryTarget(gameObject);
        }
    }

    private void Update()
    {

        playerPos = player.transform.localPosition;
        this.transform.LookAt(playerPos);

        if(currentDifficulty != _GM.difficulty.ToString())
        {
            SetUp();
            currentDifficulty = _GM.difficulty.ToString();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            float[] sizeArray = { 0.5f, 1, 2 };

            int r = Random.Range(0,2);

            size = sizeArray[r];
            print(size);
            this.transform.localScale = baseSize * size;
            switch(size)
            {
                case 0.5f:
                    this.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 1:
                    this.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 2:
                    this.GetComponent<Renderer>().material.color = Color.red;
                    break;

            }    

        }

    }
}
