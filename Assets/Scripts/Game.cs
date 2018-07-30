using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public void AwardPoint(Side side)
    {
        points[side]++;

        Text scored = side == Side.PLAYER ? playerScore : aiScore;
        scored.text = "" + points[side];
    }

    public void StartService()
    {
        playerRacket.SetToDefaultPosition();
        aiRacket.SetToDefaultPosition();

        int sumPoints = points[Side.AI] + points[Side.PLAYER];

        if (sumPoints <= 20)
        {
            sumPoints /= 2;
        }

        ball.Service(sumPoints % 2 == 0 ? Side.PLAYER : Side.AI);
    }

    public void SetupGame()
    {
        points[Side.AI] = 0;
        points[Side.PLAYER] = 0;
    }

    public int GetPoint(Side side)
    {
        return points[side];
    }

    void Start () {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        playerRacket = GameObject.Find("PlayerRacket").GetComponent<Racket>();
        aiRacket = GameObject.Find("AIRacket").GetComponent<AIRacket>();
        aiScore = GameObject.Find("AIScore").GetComponent<Text>();
        playerScore = GameObject.Find("PlayerScore").GetComponent<Text>();

        SetupGame();
    }

    private Ball ball;
    private Racket playerRacket;
    private AIRacket aiRacket;
    private Text aiScore;
    private Text playerScore;
    private Dictionary<Side, int> points = new Dictionary<Side, int>();
}
