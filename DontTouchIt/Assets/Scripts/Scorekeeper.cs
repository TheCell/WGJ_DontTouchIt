using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    // it's a gamejam so hey. let's just do this static
    public static int highscore;
    public static int currentScore;
    
    public static void GameOver()
    {
        if (currentScore > highscore)
        {
            highscore = currentScore;
        }
    }

    public void NewGame()
    {
        currentScore = 0;
    }
}
