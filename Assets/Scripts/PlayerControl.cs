using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;

    bool isWalking;

    Rigidbody2D playerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        //PlayerStop();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = Vector2.right * speed;
            playerSR.flipX = false;
            isWalking = true;
            
            playerAnim.SetFloat("X", 1);
            playerAnim.SetFloat("Y", 0);
            playerAnim.SetBool("IsWalking", isWalking);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = Vector2.left * speed;
            playerSR.flipX = true;
            isWalking = true;
            
            playerAnim.SetFloat("X", -1);
            playerAnim.SetFloat("Y", 0);
            playerAnim.SetBool("IsWalking", isWalking);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            playerRB.velocity = Vector2.up * speed;
            isWalking = true;
            
            playerAnim.SetFloat("X", 0);
            playerAnim.SetFloat("Y", 1);
            playerAnim.SetBool("IsWalking", isWalking);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = Vector2.down * speed;
            isWalking = true;
            
            playerAnim.SetFloat("X", 0);
            playerAnim.SetFloat("Y", -1);
            playerAnim.SetBool("IsWalking", isWalking);
        }
        else
        {
            playerRB.velocity = Vector2.zero;
            isWalking = false;
            playerAnim.SetBool("IsWalking", isWalking);
            playerAnim.SetFloat("X", 0);
            playerAnim.SetFloat("Y", 0);
            playerSR.flipX = false;
        }
    }

    /*void PlayerStop()
    {
        if(Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = Vector2.zero;
        }
        if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = Vector2.zero;
        }
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = Vector2.zero;
        }
        if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = Vector2.zero;
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            playerRB.velocity = Vector2.zero;
        }
    }*/


}
