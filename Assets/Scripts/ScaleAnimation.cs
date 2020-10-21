using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _finalScale;
    [SerializeField] private float _duration;

    void Start()
    {
        transform.DOScale(_finalScale, _duration).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

}
