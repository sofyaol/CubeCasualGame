using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GateCubesScript : MonoBehaviour
{
    public GameObject[] cubesArray = new GameObject[16];
    static Random random = new Random();

    // 2-8 

    void Awake()
    {
        foreach (GameObject cube in cubesArray)
        {
            int value = random.Next(0, 11);
            Debug.Log(value);
            if (value < 9)
            {
                Destroy(cube);
            }
        }        
    }

    
    void Update()
    {
        
    }
}
