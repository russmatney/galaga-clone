using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Which prefab to spoon on fire")]
    public GameObject projectilePrefab;

    [Tooltip("Which position to spawn the projectiles from")]
    public Transform spawnPoint;

    [Tooltip("How fast the player moves back and forth")]
    public float moveSpeed = 3f;

    //A timestamp of the moment we last fired
    private float lastTimeFired;

    public void Awake()
    {
        lastTimeFired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) )
        {
            Vector2 newPosition = transform.position;
            newPosition.x -= moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) )
        {
            Vector2 newPosition = transform.position;
            newPosition.x += moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if( Input.GetKey(KeyCode.Space) )
        {
            Fire();
        }
    }

    public void Fire()
    {
        ProjectileSettings projectileSettings = projectilePrefab.GetComponent<ProjectileSettings>();

        if (projectileSettings == null)
        {
            Debug.LogWarning("The equipped projectile is missing settings.");
        }
        else if (Time.time - lastTimeFired > projectileSettings.firingSpeed)
        {
            lastTimeFired = Time.time;
            GameObject spawnedPrefab = Instantiate(projectilePrefab, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        }
    }
}
