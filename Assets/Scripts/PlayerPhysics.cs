using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using DG.Tweening;

public sealed class PlayerPhysics : MonoBehaviour
{ 
    // player's variables

    private static GameObject[] cubesArray = new GameObject[16];
    private static Transform cubes;
    private new Rigidbody rigidbody;
    private bool isStanding = false;
   
    // explosion variables

    private static GameObject explosion;
    private Vector3 explosionSpawn = new Vector3();

    // touch variables

    private Ray ray = new Ray();
    private RaycastHit hit;
    private Vector2 touchStartPosition;
    private float touchTime = 0;

    private Touch touch;


    void Start()
    {   
        rigidbody = GetComponent<Rigidbody>();

        explosion = (GameObject)Resources.Load("CubeExplosion");

        cubes = transform.GetChild(0);
        
        for(int i = 0; i < 16; i++)
        {
            cubesArray[i] = cubes.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
     
        if (Input.touchCount > 0 && !GameState.Pause && !PlayerDeath.IsDead)
        {
            Touch firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = firstTouch.position;
                touch = Input.GetTouch(0);
            }

            else if (firstTouch.phase == TouchPhase.Moved)
            {
                touchTime += Time.deltaTime;
            }

            else if (firstTouch.phase == TouchPhase.Ended)
            {
                if (touchTime < 1.6f && (firstTouch.position - touchStartPosition).magnitude > 250 && (touchStartPosition.x != 0  && touchStartPosition.y != 0) && isStanding)
                {
                    cubes.DOScaleY(0.9f, 0.4f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
                    rigidbody.AddForce(0, 200f, 0);
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
                                explosionSpawn = hit.collider.transform.position;
                                explosion.GetComponent<ParticleSystemRenderer>().material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;

                                Instantiate(explosion, explosionSpawn, new Quaternion(0, 0, 0, 0));
                                hit.collider.gameObject.SetActive(false);
                                Player.DestroyedCount++;
 
                                SoundManager.DestroySoundPlay();
                            }
                        }
                    }
                }

                touchTime = 0;
                touchStartPosition = new Vector2(0, 0);
            }
        }

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0) && !GameState.Pause && !PlayerDeath.IsDead)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "PlayerCube")
                    {
                        explosionSpawn = hit.collider.transform.position;
                        explosion.GetComponent<ParticleSystemRenderer>().material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                        Instantiate(explosion, explosionSpawn, new Quaternion(0, 0, 0, 0));
                        hit.collider.gameObject.SetActive(false);
                        Player.DestroyedCount++;

                        SoundManager.DestroySoundPlay();
                    }
                }
            }
        }

        if (Input.GetKeyDown("space") && isStanding && !GameState.Pause && !PlayerDeath.IsDead)
        {
            cubes.DOScaleY(0.9f, 0.4f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            rigidbody.AddForce(0, 200f, 0); // 200
        }

#endif

    }

    // Если Player прошел через маркер, то делаем все кубики активными

    void OnTriggerEnter(Collider name)
    {
            if (name.tag == "Marker")
            {
                SoundManager.RestoreSoundPlay();

                foreach (GameObject cube in cubesArray)
                {
                if (!cube.activeSelf)
                {
                    cube.transform.DORewind();
                    cube.transform.DOPunchScale(new Vector3(-0.05f, -0.05f, -0.05f), 0.5f, 3);
                    cube.SetActive(true);
                }
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

    internal static void DeathExplosion()
    {
        foreach (GameObject cube in cubesArray)
        {
            if (cube.activeSelf)
            {
               Vector3 explosionSpawn = cube.transform.position;
                explosion.GetComponent<ParticleSystemRenderer>().material = cube.GetComponent<MeshRenderer>().material;
               Instantiate(explosion, explosionSpawn, new Quaternion(0, 0, 0, 0));
                cube.SetActive(false);
            }
        }
        
    }
}
