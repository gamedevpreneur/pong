using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : Racket {
	void Start () {
        Setup();

        direction = 1;
    }

	void FixedUpdate () {
        float ballY = ball.transform.position.y;
        float racketY = transform.position.y;
        Vector2 dir = new Vector2(0, ballY > racketY ? 1 : -1);

        rb.velocity = Vector2.Lerp(rb.velocity, dir * speed, lerpTweak * Time.deltaTime);
	}

    public float lerpTweak = 2;
}
