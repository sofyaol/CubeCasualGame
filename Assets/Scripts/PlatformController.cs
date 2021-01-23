using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

    public class PlatformController : MonoBehaviour
    {
        public List<GameObject> platforms = new List<GameObject>();
        public float[] timeIntervals = new float[4];

        float currentTimeInterval = 0.4f;
        public Vector3 spawn;
        public GameObject currentPlatform;

        Random random = new Random();
        int randomValue = 0;
        
      
        void Start()
        {
        // добавление следующего объекта происходит в зависимости от того, какой был предыдущий объект
        // предыдущий объект (относительно его длины) устанавливает значение времени,
        // после которого должна заспавниться новая платформа
        
            StartCoroutine("NextPlatformCoroutine");
        StartCoroutine("SpeedUp");
         }

    IEnumerator NextPlatformCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentTimeInterval);

            randomValue = random.Next(0, 4);
            currentPlatform = Instantiate(platforms[randomValue], spawn, new Quaternion(0,0,0,0));
            currentTimeInterval = timeIntervals[randomValue];
        } 
    }


    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(80f);
        Platform.SetSpeed(Platform.GetSpeed() + 0.02f);
        StartCoroutine("SpeedUp");
    }
    }

