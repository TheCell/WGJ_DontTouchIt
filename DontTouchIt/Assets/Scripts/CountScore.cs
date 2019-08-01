using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoredisplay;

    private void Update()
    {
        Scorekeeper.currentScore = (int) Mathf.Round(Time.timeSinceLevelLoad);
        scoredisplay.text = "Score: " + Scorekeeper.currentScore;
    }
}
