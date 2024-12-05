using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0){
            MakePlayerWalk();
        }
        if (Input.GetAxis("Jump") > 0){
            MakePlayerJump();
        }
    }

    void MakePlayerWalk(){
        rb2d.linearVelocity = new Vector2(5, rb2d.linearVelocityY);
        anim.Play("player_walk");
    }

    void MakePlayerJump(){
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, 10);
    }
}
