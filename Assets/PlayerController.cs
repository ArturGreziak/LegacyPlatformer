using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float heroSpeed;
    public float jumpForce;
    Animator anim;
    bool dirToRight = true;
    Rigidbody2D rbdBody;
    void Start()
    {
        anim = GetComponent<Animator>();
        rbdBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rbdBody.velocity = new Vector2(horizontalMove * heroSpeed, rbdBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbdBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("Jump");
        }

        anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (horizontalMove < 0 && dirToRight)
        {
            Flip();
        }
        if (horizontalMove > 0 && !dirToRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 heroScaale = gameObject.transform.localScale;
        heroScaale.x *= -1;
        gameObject.transform.localScale = heroScaale;
    }
}
