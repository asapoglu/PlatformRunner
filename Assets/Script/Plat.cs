using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Plat : MonoBehaviour
{
    public static Plat instance;
    public static int counter;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManeger.isGameOver)
        {
            DOTween.Kill(this.transform);
        }
        //transform.DOShakePosition(7f, new Vector3(0.2f, 0, 1.0f), 2, 1f, false, false);
    }

    void OnCollisionEnter(Collision con)
    {
        if (!GameManeger.isGameOver)
        {
        Shake(this.transform.parent.parent);

        }
        else
        {
            
        }
    }
    Transform parentG;
    void Shake(Transform parent)
    {
        parentG = parent;
        for(int i = 0; i<parent.childCount; i++)
        {

            parent.transform.GetChild(i).transform.DOShakePosition(2.5f, new Vector3(0.15f,0,1.0f), 1, 1f, false, false).OnComplete(Fallen/*() => { parent.transform.GetChild(i).transform.DOMoveY(-20f, 1.5f); }*/);

        }
    }
    void Fallen()
    {
        //for (int i = 0; i < parentG.childCount; i++)
        //{
        //    parentG.transform.GetChild(i).transform.DOMoveY(-20f, 1.5f);
        //}
        this.transform.DOMoveY(-20f, 1.5f);
    }

}
