using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCube : MonoBehaviour
{
    // если кубик задел объект Gate, то перезагружаем сцену

    void OnTriggerEnter(Collider name)
    {
        if (name.tag == "Gate")
        {
            Platform.SetSpeed(0.1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
