using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Accessing UI from here to edit text for PlayerScore

public class PlayerScore : MonoBehaviour
{
    public static float playerScore = 0; // Static so can update score from other scripts
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() // Gets update and changes score anytime player gets any points
    {
        scoreText.text = "Score: " + playerScore; // Constantly checking current score and updating score onscreen to match it
    }
}
