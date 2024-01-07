using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOverTime : MonoBehaviour
{
    [Tooltip("The direction, x and y, that the object moves")]
    public Vector2 direction = new Vector2(0f, -1f);

    public Vector2 dir;
    private float _magnitude;

    void Awake()
    {
        dir = direction.normalized;
        _magnitude = direction.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;

        Vector2 distanceToMove = dir * (_magnitude * Time.deltaTime);

        newPosition += distanceToMove;

        transform.position = newPosition;
    }
}
