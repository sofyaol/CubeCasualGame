using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;


    public class GateController : MonoBehaviour
    {
        static private Random random = new Random();

        internal static List<int> GetDestroyedCubesList()
        {
            List<int> destroyedCubes = new List<int>();

        while (destroyedCubes.Count == 0)
        {       
            for (int i = 0; i < 16; i++)
            {
                int value = random.Next(0, 11);

                if (value < 9)
                {
                    destroyedCubes.Add(i);
                }
            }

            if (destroyedCubes.Count == 16 || destroyedCubes.Count < 3) destroyedCubes.Clear();
        }

            GameState.cubesCountQueue.Enqueue(16 - destroyedCubes.Count);

            return destroyedCubes;
        }

        void Awake()
        {
            GameState.gateCountQueue.Enqueue(2);
            Debug.Log("Scene Load! 2 gates: " + GameState.gateCountQueue.Peek());

        }

    }

