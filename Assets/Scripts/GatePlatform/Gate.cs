using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;

public class Gate : MonoBehaviour
{
    public GameObject[] cubesArray = new GameObject[16];
    private Material gateMaterial;

    void Start()
    {
        // запрашиваем у GateController какие кубики нужно уничтожить 

        List<int> destroyedCubes = GateController.GetDestroyedCubesList();

        foreach (int cubeIndex in destroyedCubes)
        {
            Destroy(cubesArray[cubeIndex]);
        }

        // запрашиваем у GateController материал для нашего объекта Gate

        
        gateMaterial = MaterialAppointer.GetGateMaterial();

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material = gateMaterial;
        }
    }
}
