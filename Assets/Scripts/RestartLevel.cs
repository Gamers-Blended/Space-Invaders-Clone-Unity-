// script in which player press 'R' to restart level
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Reload the scene and restart level anytime 'R' is pressed

public class RestartLevel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Checking if player presses 'R'
        {
            PlayerScore.playerScore = 0; // Everytime restart level, score goes back to 0
            GameOver.isPlayerDead = false;
            Time.timeScale = 1; // GameOver set to 0 - everything froze

            SceneManager.LoadScene("Scene_001");
        }
    }
}
