using UnityEngine;
using System.Collections;

public class EnemyBlob : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    public float speed;
    Animator anim;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;
            if (timeToMoveCounter < 0)
            {
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                moving = false;
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0)
            {
                moving = true;
                anim.SetBool("isWalking", true);
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed, 0);
                anim.SetFloat("X_Direction", moveDirection.x);
                anim.SetFloat("Y_Direction", moveDirection.y);
            }
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /* if (other.gameObject.name == "Player")
         {
             //Destroy(other.gameObject);
             other.gameObject.SetActive(false);
             reloading = true;
             thePlayer = other.gameObject; 
         }*/
    }
}



