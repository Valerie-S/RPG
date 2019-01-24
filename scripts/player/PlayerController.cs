using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D PlayerBody;
    private Animator PlayerAnim;
    private bool isMoving;
    private Vector2 lastMove;

    public float moveSpeed;

	// Use this for initialization
	void Start () {
        PlayerBody = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        isMoving = false;
        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            isMoving = true;
            lastMove.x = Input.GetAxisRaw("Horizontal");
            PlayerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed,PlayerBody.velocity.y);
        }
        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            PlayerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), PlayerBody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            isMoving = true;
            lastMove.y = Input.GetAxisRaw("Vertical");
            PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            PlayerBody.velocity = new Vector2(PlayerBody.velocity.x, Input.GetAxisRaw("Vertical"));
        }
        PlayerAnim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        PlayerAnim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        PlayerAnim.SetFloat("lastMoveX", lastMove.x);
        PlayerAnim.SetFloat("lastMoveY", lastMove.y);
        PlayerAnim.SetBool("isMoving", isMoving);
 
    }
}
