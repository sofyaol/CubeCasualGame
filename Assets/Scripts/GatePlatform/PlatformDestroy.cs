using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DestroyMyself");
    }

    IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);

    }
}
