using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arrow : MonoBehaviour
{
    public static Arrow instance;
    Vector2 lEnd = new Vector3 (90, -50, 0);
    Vector2 rEnd = new Vector3 (90, 50, 0);
    public float angle;
    public static bool launchActive;
    void Awake()
    {
        instance = this;
        angle = 0f;
    }
    void Start()
    {
        goRightLeft();
    }

    void Update()
    {
        
    }

    public void goRightLeft()
    {
        if (!launchActive)
        {
            
            this.transform.DORotate(rEnd, 0.70f).OnComplete(() => { this.transform.DORotate(lEnd, 0.70f).OnComplete(goRightLeft);});
        }
    }
    public void arrowStart()
    {
        this.transform.eulerAngles = new Vector3(90, 0, 0);
        this.transform.GetChild(0).GetChild(0).DOScaleY(0f, 0.05f);
        this.gameObject.SetActive(true);
        goRightLeft();
    }
}
