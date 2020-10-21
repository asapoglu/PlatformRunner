using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spear : MonoBehaviour
{
    public static Spear instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pushSpear();
    }

    void pushSpear()
    {
        if (!GameManeger.isGameOver)
        {
        
        this.transform.GetChild(1).DOLocalMoveX(-5, 3f).OnComplete(() => 
        { this.transform.GetChild(1).DOLocalMoveX(0.0410f, 0f).OnComplete(() => 
        { this.transform.DOShakePosition(1f, new Vector3(0.2f, 0.0f, 0.2f)).OnComplete(pushSpear); }); });

        }
        
    }
}
