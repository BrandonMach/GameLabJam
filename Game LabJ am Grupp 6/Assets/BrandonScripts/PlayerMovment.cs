using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerContoller))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update

    
    private float horizontalinput;
    private float movementSpeed = 8f;
    private float jumpingPower = 16f;  
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
        FlipSprite();
    }
    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontalinput * movementSpeed, playerRb.velocity.y);
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
