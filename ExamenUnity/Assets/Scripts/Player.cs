using Unity.Mathematics;
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
        if (Input.GetAxis("Horizontal") != 0){
            MovePlayer(Input.GetAxis("Horizontal"));
        }
        else{
            rb2d.linearVelocity = new Vector2(0, 0);
            anim.Play("player_idle");
        }
    }

    void MovePlayer(float movementDirection){
        if (movementDirection > 0){
            rb2d.linearVelocity = new Vector2(5, 0);
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        }
        else{
            rb2d.linearVelocity = new Vector2(-5, 0);
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        }
        anim.Play("player_walk");
    }
}
