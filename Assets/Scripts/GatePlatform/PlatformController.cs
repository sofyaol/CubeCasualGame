using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

    public class PlatformController : MonoBehaviour
    {
        public List<GameObject> platforms = new List<GameObject>();
    
        public static Vector3 spawn = new Vector3(0, 0, 61);
        public GameObject currentPlatform;
        public Color platformColor;

    internal static Vector3[] pathVectors =
    {
        new Vector3(0, -3f, 64f),
        new Vector3(0f, -2f, 62f),
        new Vector3(0f, 0f, 61f)
        };
     
        Random random = new Random();
        int randomValue = 0;

        internal static bool NextPlatform { get; set; }
 
    void Start()
        {
             NextPlatform = false;
             StartCoroutine("SpeedUp");  
         }

    void FixedUpdate()
    {
        if (NextPlatform)
        {
            NextPlatform = false;

            randomValue = random.Next(0, 4);
            currentPlatform = Instantiate(platforms[randomValue], new Vector3(0, -5, 65), new Quaternion(0, 0, 0, 0));

            // заполнение очереди gateCount

            int count = randomValue > 1 ? 2 : 1;
            GameState.gateCountQueue.Enqueue(count);
            
        }
    }


    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(45f);
        Platform.SetSpeed(Platform.GetSpeed() + 0.01f); // 0.02
        StartCoroutine("SpeedUp");
    }
    }
 
