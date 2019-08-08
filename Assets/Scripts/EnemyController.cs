using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;

    public GameObject shot;
    public Text winText;
    public float fireRate = 0.997f;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();

    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder) // For each enemy placed inside enemyHolder
        {
            if(enemy.position.x < -10.5 || enemy.position.x > 10.5) // Both sides of the screen
            {
                speed = -speed; // Reverses direction enemy is moving
                enemyHolder.position += Vector3.down * 0.5f; // Moves enemy move down
                return; // If true, jump out of loop
            }

            if(Random.value > fireRate) // Randomly spawn bullets fired from enemy
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if(enemy.position.y <= -4)
            {
                GameOver.isPlayerDead = true; // When enemy at bases, game over
                Time.timeScale = 0; // Freezes the game
            }
        }

        if(enemyHolder.childCount == 1)
        {
            CancelInvoke(); // Stops initial Invoke
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f); // Invoke again with a quicker speed
        }

        if(enemyHolder.childCount == 0)
        {
            winText.enabled = true; // Onscreen text that player has won
        }
    }
}
