using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public sealed class Platform : MonoBehaviour
{
    private static float speed = 0.1f;
    public bool isStart = false;

    internal static void SetSpeed(float speed)
    {
        Platform.speed = speed;
    }

    internal static float GetSpeed()
    {
        return Platform.speed;
    }

    void Start()
    {
        Material platformMaterial = MaterialAppointer.GetPlatformMaterial();
        gameObject.GetComponentInChildren<MeshRenderer>().material = platformMaterial;

        if (!isStart)
        {
            transform.DOPath(PlatformController.pathVectors, 0.25f, PathType.Linear).OnComplete(Complete);
        }
    }

    void Complete()
    {
        isStart = true;
    }

    void FixedUpdate()
    {
        if(isStart)
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
    }
}
