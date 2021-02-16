using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMarkerController : MonoBehaviour
{
    void OnTriggerExit(Collider name)
    {
        if (name.tag == "Platform")
        {
            PlatformController.NextPlatform = true;
        }
    }
}
