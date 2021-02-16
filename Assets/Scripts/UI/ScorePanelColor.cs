using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelColor : MonoBehaviour
{
    public Image image;
    Color newColor;

    const float colorSpeed = 0.00003f;

    float startColorR;
    float startColorG;

    float maxColorR = 0.6f;
    float minColorG = 0.2f;

    bool changeG = true;
    bool makeLess = true;

    void Start()
    {
        newColor = image.color;
        startColorR = newColor.r;
        startColorG = newColor.g;
    }
    void Update()
    {
        if (changeG)
        {
            newColor.g = makeLess == true ? newColor.g - colorSpeed : newColor.g + colorSpeed;

            image.color = newColor;

            if (newColor.g <= minColorG)
            {
                changeG = false;
                makeLess = false;
            }
            else if (newColor.g >= startColorG)
            {
                changeG = false;
                makeLess = true;
            }
        }

        if (!changeG)
        {
            newColor.r = makeLess == true ? newColor.r - colorSpeed : newColor.r = newColor.r + colorSpeed;

            image.color = newColor;

            if (newColor.r >= maxColorR)
            {
                changeG = true;
                makeLess = false;
            }
            else if (newColor.r <= startColorR)
            {
                changeG = true;
                makeLess = true;
            }
        }
    }
}
