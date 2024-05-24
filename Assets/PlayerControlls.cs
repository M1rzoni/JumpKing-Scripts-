using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public float maxJumpForce = 10f;
    public float maxHoldTime = 2f;

    private Rigidbody2D rb;
    private bool isHoldingJump = false;
    private float holdTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHoldingJump = true;
            holdTime = 0f;
        }
        if (Input.GetKey(KeyCode.Space) && isHoldingJump)
        {
            holdTime += Time.deltaTime;
            holdTime = Mathf.Clamp(holdTime, 0f, maxHoldTime);
        }
        if (Input.GetKeyUp(KeyCode.Space) && isHoldingJump)
        {
            isHoldingJump = false;
            float jumpForce = Mathf.Lerp(0f, maxJumpForce, holdTime / maxHoldTime);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
