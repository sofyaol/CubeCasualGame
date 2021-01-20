using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyScript : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("DestroyMyself");
    }

    IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        
    }
    
}
