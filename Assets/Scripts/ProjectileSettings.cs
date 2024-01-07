using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSettings : MonoBehaviour
{
    [Tooltip("How many seconds between shots")]
    public float firingSpeed = 1f;
    public AudioClip fireSound;

    public EnemyDetector enemyDetector;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        if (fireSound != null && AudioManager.Instance != null)
            AudioManager.Instance.PlaySound(fireSound);
    }

    void Update()
    {
        if (target) AimTowardTarget();

        if (!target && enemyDetector && enemyDetector.target)
            target = enemyDetector.target;
    }


    void AimTowardTarget() {
        var move_over_time = GetComponent<MoveOverTime>();
        var towards_enemy = target.transform.position - transform.position;
        move_over_time.dir = towards_enemy.normalized;
    }

}
