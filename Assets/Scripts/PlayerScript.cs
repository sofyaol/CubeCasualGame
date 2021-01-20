using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // ДОСТАТОЧНОЕ УСЛОВИЕ, ЧТОБЫ ПРОВЕРИТЬ, ЧТО ИГРОК ИЗБАВИЛСЯ ТОЛЬКО ОТ НУЖНЫХ КУБИКОВ - 
    // ПРОВЕРИТЬ, ЧТО КОЛ-ВО НАЖАТИЙ == КОЛ-ВУ ИСЧЕЗНУВШИХ КУБИКОВ

    public GameObject[] cubesArray = new GameObject[16];
    Rigidbody rigidbody;
    public GameObject explosion;
    Ray ray = new Ray();
    RaycastHit hit;
    Vector3 spawn = new Vector3();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    if (hit.collider.tag == "PlayerCube")
                    {
                        spawn = hit.collider.transform.position;
                        Debug.Log(spawn);
                        Instantiate(explosion, spawn, new Quaternion(0, 0, 0, 0));
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "PlayerCube")
                    {
                        spawn = hit.collider.transform.position;
                        Debug.Log(spawn);
                        Instantiate(explosion, spawn, new Quaternion(0, 0, 0, 0));
                        hit.collider.gameObject.SetActive(false);

                    }
                }
            }
        }

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space!");
            rigidbody.AddForce(0, 150f, 100f);
        }

#endif

    }

    void OnTriggerEnter(Collider name)
    {
        if (name.tag == "Marker")
        {
            foreach (GameObject cube in cubesArray)
            {
                cube.SetActive(true);
            }
        }
    }
}
