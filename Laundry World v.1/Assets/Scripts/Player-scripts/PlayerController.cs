using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidBody;
    Animator anim;
    public AudioSource walkSound;

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalSpeedModifier;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    private static bool playerExists;
    public bool canMove;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!canMove)
        {
            return; //ifall spelaren inte ska få lov att röra sig, uppdateras inte det nedan
        }

        if (!attacking)
        {
            Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
            if (movementVector != Vector2.zero)
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("inputX", movementVector.x);
                anim.SetFloat("inputY", movementVector.y);
            }
            else
            {
                walkSound.Play();
                anim.SetBool("isWalking", false);
            }

            rigidBody.MovePosition(rigidBody.position + movementVector * Time.deltaTime);

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalSpeedModifier;
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rigidBody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0) 
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
    }
}
