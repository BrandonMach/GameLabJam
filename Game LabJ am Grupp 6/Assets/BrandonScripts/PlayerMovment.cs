using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update

    
    private float horizontalinput;
    private float movementSpeed = 4f;
    public float jumpingPower = 2f;  
    private bool isFaceingRight = false;

    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private void OnValidate()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpingPower);
        }

        FlipSprite();
    }
    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontalinput * movementSpeed, playerRb.velocity.y);
    }

    private bool IsGrounded()
    {
        //Ground hit detection
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipSprite()
    {
        if (isFaceingRight && horizontalinput < 0 || !isFaceingRight && horizontalinput > 0)
        {
            isFaceingRight = !isFaceingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

}
