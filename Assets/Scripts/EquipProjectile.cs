using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipProjectile : MonoBehaviour
{
    public GameObject projectileToEquip;

    public AudioClip pickupSound;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.GetComponent<PlayerController>() )
        {
            collision.gameObject.GetComponent<PlayerController>().projectilePrefab = projectileToEquip;

            AudioSource audioSource = GetComponent<AudioSource>();

            if (pickupSound != null && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySound(pickupSound);
            }

            Destroy(gameObject);
        }
    }

    private void DestorySelf()
    {
        Destroy(gameObject);
    }
}
