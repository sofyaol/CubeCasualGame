using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAppointer : MonoBehaviour
{
    
    private static List<Material> gateMaterials = new List<Material>();
    private static List<Material> platformMaterials = new List<Material>();
    internal static int IndexOfActualMaterial { get; set; }

    internal static Material GetGateMaterial()
    {
        return gateMaterials[IndexOfActualMaterial];
    }

    internal static Material GetPlatformMaterial()
    {
        return platformMaterials[IndexOfActualMaterial];
    }


    void Awake()
    {
        IndexOfActualMaterial = 0;

        StartCoroutine("IncrementMaterialIndex");

        Object[] objGateMaterials = Resources.LoadAll("Materials/GateMaterials", typeof(Material));
        Object[] objPlatformMaterials = Resources.LoadAll("Materials/PlatformMaterials", typeof(Material));


        foreach (Object material in objGateMaterials)
        {
            gateMaterials.Add((Material)material);
        }

        foreach (Object material in objPlatformMaterials)
        {
            platformMaterials.Add((Material)material);
        }

    }

    IEnumerator IncrementMaterialIndex()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            IndexOfActualMaterial++;
          
            IndexOfActualMaterial = IndexOfActualMaterial == gateMaterials.Count ?  0 : IndexOfActualMaterial; 
        }
    }
}
