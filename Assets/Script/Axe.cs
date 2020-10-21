using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(!GameManeger.isGameOver)
        this.transform.Rotate(0.0f, 0.0f, -4.5f, Space.Self);
    }
}
