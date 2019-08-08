using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public float speed; // Controls speed of the bullet

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate() // Ensures bullet moves every step ahead of time instead of every frame (may change)
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            Destroy(gameObject); // Clears bullets off-screen; reduces number of bullets for performance 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject); // Clears Enemy
            Destroy(gameObject); // Clears Bullet
            PlayerScore.playerScore += 10;
        }
        else if (other.tag == "Base")
            Destroy(gameObject); // Clears Bullet
    }
}
