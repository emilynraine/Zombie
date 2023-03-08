﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this has been modified from the original loadingbar class in this pack
public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    public Image imageComp;
    public float speed = 0.0f;
   

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            
        }
        /*else
        {
            imageComp.fillAmount = 0.0f;
            
        }*/
    }
}
