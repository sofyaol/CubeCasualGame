using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Player : MonoBehaviour
{
    // ДОСТАТОЧНОЕ УСЛОВИЕ, ЧТОБЫ ПРОВЕРИТЬ, ЧТО ИГРОК ИЗБАВИЛСЯ ТОЛЬКО ОТ НУЖНЫХ КУБИКОВ - 
    // ПРОВЕРИТЬ, ЧТО КОЛ-ВО НАЖАТИЙ == КОЛ-ВУ ИСЧЕЗНУВШИХ КУБИКОВ

    public GameObject[] cubesArray = new GameObject[16];
    Rigidbody rigidbody;
    public GameObject explosion;
    Ray ray = new Ray();
    RaycastHit hit;
    Vector3 spawn = new Vector3();

    bool isStanding = false;

    Vector2 touchStartPosition;
    // Vector2 endPos;

    float touchTime = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        Debug.Log(transform.position.z);
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = firstTouch.position;
            }

            if (firstTouch.phase == TouchPhase.Moved)
            {
                touchTime += Time.deltaTime;
            }

            else if (firstTouch.phase == TouchPhase.Ended)
            {
                if (touchTime < 1.6f && (firstTouch.position - touchStartPosition).magnitude > 250 && isStanding)
                {
                    rigidbody.AddForce(0, 200f, 0);
                }

                touchTime = 0;
            }

            else
            {
                ray = Camera.main.ScreenPointToRay(firstTouch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "PlayerCube")
                        {
                            spawn = hit.collider.transform.position;
                            explosion.GetComponent<ParticleSystemRenderer>().material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                           
                            Instantiate(explosion, spawn, new Quaternion(0, 0, 0, 0));
                            hit.collider.gameObject.SetActive(false);
                        }
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
                        explosion.GetComponent<ParticleSystemRenderer>().material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                       // explosion.GetComponent<Material>().color = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
                        Instantiate(explosion, spawn, new Quaternion(0, 0, 0, 0));
                        hit.collider.gameObject.SetActive(false);

                    }
                }
            }
        }

        if (Input.GetKeyDown("space") && isStanding)
        {
            rigidbody.AddForce(0, 200f, 0);
        }

#endif

    }

    // Если Player прошел через маркер, то делаем все кубики активными

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

    void OnCollisionExit(Collision name)
    {
        if (name.collider.tag == "Platform")
        {
            isStanding = false;
        }
    }

    void OnCollisionEnter(Collision name)
    {
        if (name.collider.tag == "Platform")
        {
            isStanding = true;
        }
    }
}
