using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float strongJump;
    private Rigidbody2D playerRigidbody2D;
    private Animator animator;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetBool("isJumping", true);
            playerRigidbody2D.AddForce(new Vector2(0, strongJump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("isJumping", false);
        }
        if (collision.gameObject.tag == "obstacles")
        {
            gameManager.gameOver = true;
        }
    }
}
