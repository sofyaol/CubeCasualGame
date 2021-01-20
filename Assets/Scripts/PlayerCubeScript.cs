using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCubeScript : MonoBehaviour
{

    void OnTriggerEnter(Collider name)
    {
        if (name.tag == "Gate")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
