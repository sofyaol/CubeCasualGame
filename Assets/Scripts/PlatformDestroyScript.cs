using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyScript : MonoBehaviour
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
