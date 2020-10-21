using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAnimation : MonoBehaviour
{
    void Start()
    {
        this.transform.DOScale(new Vector3(0.9119823f, 0.9119823f, 0f), 1.5f).SetLoops(-1, LoopType.Yoyo);
    }
}
