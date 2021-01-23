using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    internal static float speed = 0.1f;

    internal static void SetSpeed(float speed)
    {
        Platform.speed = speed;
    }

    internal static float GetSpeed()
    {
        return Platform.speed;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
    }
}
