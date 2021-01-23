using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GateCubes : MonoBehaviour
{
    public GameObject[] cubesArray = new GameObject[16];
    static Random random = new Random();

    // 2-8 

    void Awake()
    {
        foreach (GameObject cube in cubesArray)
        {
            int value = random.Next(0, 11);

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
