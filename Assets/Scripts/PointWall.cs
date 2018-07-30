using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    PLAYER,
    AI,
}

public class PointWall : MonoBehaviour {
	void Start () {
        game = GameObject.Find("Game").GetComponent<Game>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            game.AwardPoint(pointSide);
            game.StartService();
        }
    }

    public Side pointSide;

    private Game game;
}
