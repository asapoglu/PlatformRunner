using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Saw : MonoBehaviour
{

    void Start()
    {
        move();
    }

    void Update()
    {
        this.transform.Rotate(0.0f, -4.5f, 0.0f, Space.Self);
    }

    void move()
    {
        this.transform.DOLocalMoveX(-4, 2f).SetLoops(-1, LoopType.Yoyo).SetRelative(true);
    }

}
