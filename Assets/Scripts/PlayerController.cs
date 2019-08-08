using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform player;
    public float speed;
    public float maxBound, minBound; //stops player from moving off-screen

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform> (); //finds player's transform component
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // a/d/left/right

        if (player.position.x < minBound && h < 0)
            h = 0; //if player is at far left side of screen & h < 0 (trying to move left) -> stops movement
        else if (player.position.x > maxBound && h > 0) // h > 0 -> pressing key to move
            h = 0; //reset to 0

        //moves player
        player.position += Vector3.right * h * speed;
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire) // Pressing Fire1 button
        {
            nextFire = Time.time + fireRate; // Take current time, add on to rate of fire, figure out when is the next time allowed to shoot
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // Creates the bullet in the position & rotation to set
        }
    }
}
