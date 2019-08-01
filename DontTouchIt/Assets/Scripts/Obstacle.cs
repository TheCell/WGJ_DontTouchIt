using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && Time.timeSinceLevelLoad > 3f)
        {
            Debug.Log("player collided");
            Scorekeeper.GameOver();
            SceneManager.LoadScene(0);
        }
    }
}
