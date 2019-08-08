using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefeat : MonoBehaviour
{
    private Transform playerBase;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<Transform>(); // Initialise playerBase by getting it to transform
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase.childCount == 0) // Looks at amount of bases left
            GameOver.isPlayerDead = true; // Sets GameOver script to true
    }
}
