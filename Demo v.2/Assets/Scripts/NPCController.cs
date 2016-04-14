using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidBody;
    private bool isMoving = false;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    Animator anim;
    private float randomDirection;

	void Start () 
    {
	    myRigidBody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;
            if (timeToMoveCounter < 0)
            {
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                isMoving = false;
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0)
            {
                isMoving = true;
                anim.SetBool("isWalking", true);
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed, 0);
                anim.SetFloat("X_Direction", moveDirection.x);
                anim.SetFloat("Y_Direction", moveDirection.y);
            }
        }
    }      
}
