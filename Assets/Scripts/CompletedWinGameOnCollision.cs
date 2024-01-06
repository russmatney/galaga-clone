using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedWinGameOnCollision : MonoBehaviour
{
    // `OnCollisionEnter2D` is a special function that is called when a physics collision happens.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object we collided with has the `PlayerController` component, AND we have a UIController loaded...
        if (collision.gameObject.GetComponent<PlayerController>() != null && UIController.Instance != null)
        {
            // ... then tell the UIController to show the win screen.
            UIController.Instance.ShowWinScreen();
        }
    }
}
