using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Spike : MonoBehaviour
{
    public static Spike instance;
    void Start()
    {
        instance = this;
        this.transform.DOLocalMoveY(-0.10f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        
    }

    void inSpike()
    {
        this.transform.DOLocalMoveY(0.3f, 1f).OnComplete(outSpike);
    }
    void outSpike()
    {
        this.transform.DOLocalMoveY(0.8f, 1f).OnComplete(inSpike);
    }
}
