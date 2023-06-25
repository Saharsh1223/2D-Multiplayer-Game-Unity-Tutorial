using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
	[Header("References")]
	public PhotonView pv;
	public Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask groundMask;
	public SpriteRenderer sr;
	public Animator anim;

	[Header("Settings")]
	public float speed = 8f;
	public float jumpForce = 16f;

	[Header("Debugging")]
	public bool isGrounded;
	public bool isFacingRight = true;

	private float horizontalInput;

	private KeyCode jumpKey = KeyCode.Space;

	private void Update()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundMask);

		if (isFacingRight)
		{
			sr.flipX = false;
		}
		else
		{
			sr.flipX = true;
		}
		
		if (isGrounded && Input.GetKeyDown(jumpKey))
		{
			Jump();
		}
		
		if (Input.GetKeyDown(jumpKey) && rb.velocity.y > 0)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}

		Flip();
		HandleAnimations();
	}
	
	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	}
	
	private void HandleAnimations()
	{
		if (horizontalInput != 0)
		{
			anim.SetBool("isRunning", true);
		}
		else
		{
			anim.SetBool("isRunning", false);
		}
		
		if (!isGrounded)
		{
			anim.SetBool("isFalling", true);
		}
		else
		{
			anim.SetBool("isFalling", false);
		}
	}
	
	private void Flip()
	{
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			isFacingRight = false;
		}

		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			isFacingRight = true;
		}
	}
	
	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
	}
}
