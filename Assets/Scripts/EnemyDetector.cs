using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public GameObject target;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (target) return;

        GameObject obj = collider.gameObject;
        // Check if the thing that touched us has a damagable
        Damagable damagable = obj.GetComponent<Damagable>();

        //If it does, and it's not friendly
        if(damagable != null && damagable.faction == 0) // NOTE hardcoded to faction 0 for now
        {
            Debug.Log("detected new enemy: " + obj);
            target = obj;
        }
    }
}
