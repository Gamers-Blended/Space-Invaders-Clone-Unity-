// Script that moves the bullet

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed; // Goes in opposite direction

        if(bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject); // Remove bullets offscreen for performance
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // Check if enemyBullet is hitting player
        {
            Destroy(other.gameObject); // Removes player
            Destroy(gameObject); // Removes bullet
            GameOver.isPlayerDead = true;
        }    

        else if(other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>(); // Get Base's health from base bullet has collided with
            baseHealth.health -= 1; // Take some health away
            Destroy(gameObject); // Removes bullet
        }
    }
}
