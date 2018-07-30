using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {
    public void SetToDefaultPosition()
    {
        float currentX = transform.position.x;
        transform.position = new Vector2(currentX, 0);
    }

    void Start () {
        Setup();
	}

    protected void Setup()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();

        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        float vertDirection = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(0, vertDirection) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            float y = BallHitPosition(collision.transform.position);

            Vector2 velocity = new Vector2(direction, y);
            velocity = ballSpeed * velocity.normalized;
            ball.Hit(velocity, new Vector2(0, 0));
        }
    }

    private float BallHitPosition(Vector3 ballPosition)
    {
        return (ballPosition.y - transform.position.y) / collider.bounds.size.y;
    }

    public float speed = 30;

    protected int direction = -1;
    protected Ball ball;
    protected Rigidbody2D rb;
    protected new Collider2D collider;
    private float ballSpeed = 30;
}
