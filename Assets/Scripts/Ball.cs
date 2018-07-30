using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public void Hit(Vector2 velocity, Vector2 acceleration)
    {
        rb.velocity = velocity;
        this.acceleration = acceleration;
    }

    public void Service(Side side)
    {
        transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(side == Side.PLAYER ? 1 : -1, 0) * defaultSpeed;
    }

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Service(Side.PLAYER);
	}

    void FixedUpdate()
    {
        rb.AddForce(rb.mass * acceleration * Time.deltaTime);
    }

    public Vector2 direction;
    public Vector2 acceleration = new Vector2(0, 0);
    public float defaultSpeed = 30;

    private Rigidbody2D rb;
}
