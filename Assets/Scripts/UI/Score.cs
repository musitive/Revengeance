using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static int currentScore = 0;
    public Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string displayText = "Score: " + currentScore.ToString("n0");
        scoreDisplay.text = displayText;
    }

    public static void gainPoints(int points) {
        currentScore += points;
    }
}
