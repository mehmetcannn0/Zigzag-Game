using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorController : MonoBehaviour
{

    [SerializeField] private Material groundMaterial;
    [SerializeField] private Color[] colors;
    private int colorIndex = 0;
   
    [SerializeField] private float lerpValue = 0;
    [SerializeField] float time;
    private float currentTime;

    private void Update()
    {
        SetColorChangeTime();
        SetGroundMaterialColorChange(); 
    }
    private void SetColorChangeTime()
    {
        if (currentTime <= 0)
        {
            CheckColorIndexValue();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void CheckColorIndexValue()
    {
        colorIndex++;
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }


    }
    private void SetGroundMaterialColorChange()
    {
        groundMaterial.color = Color.Lerp(groundMaterial.color, colors[colorIndex], lerpValue * Time.deltaTime);
    }
    private void OnDestroy()
    {
        groundMaterial.color = colors[1];
    }
}
