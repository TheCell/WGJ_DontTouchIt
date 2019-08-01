using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMenuTexts : MonoBehaviour
{
    [SerializeField] TMP_Text currentScore;
    [SerializeField] TMP_Text highScore;

    private void Update()
    {
        highScore.text = "Highscore: " + Scorekeeper.highscore;
        currentScore.text = "Last Run: " + Scorekeeper.currentScore;
    }
}
