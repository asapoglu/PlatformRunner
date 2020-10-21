using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Anima : MonoBehaviour
{
    public static Animator _animator;
    public static Anima instance;
    public ParticleSystem puf;
    public ParticleSystem blood1;
    public ParticleSystem blood2;
    public ParticleSystem fire;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DOTween.Init();
        _animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (this.transform.position.y < 0.24f)
        {
            GameManeger.instance.gameOver();
        }
    }

    public void walk(Vector3 distance, float param, float angle)
    {
        float dist = param * 7.6f;
        float runParam = (1.0f / 7.6f) * dist;
        float walkParam = (1.0f / 6.2f) * dist;
        _animator.SetFloat("RunParam", runParam);
        _animator.SetFloat("WalkParam", walkParam);
        if (param > 0.54f)
        {
            
            _animator.Play("Running");
            this.transform.eulerAngles = new Vector3 (0,angle,0);
            this.transform.DOMove(distance.normalized * dist, 12f).SetRelative(true).OnComplete(animationStop).SetSpeedBased();
        }
        else
        {
            _animator.Play("Walking");
            this.transform.eulerAngles = new Vector3(0, angle, 0);
            this.transform.DOMove(distance.normalized * dist, 6f).SetRelative(true).OnComplete(animationStop).SetSpeedBased();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (false)
        {

        }
         else if (col.transform.CompareTag("Axe"))
        {

            this.blood1.Play();
            _animator.Play("Knock");
            DOTween.Kill(this);
            GameManeger.instance.gameOver();
        }
        else if (col.transform.CompareTag("DeathSpike"))
        {
            col.transform.DOKill();
            this.blood1.Play();
            this.blood2.Play();
            _animator.Play("Pain");
            DOTween.Kill(this);
            GameManeger.instance.gameOver();
        }        
        else if (col.transform.CompareTag("Spear"))
        {
            this.blood1.Play();
            _animator.Play("Pain");
            DOTween.Kill(this);
            GameManeger.instance.gameOver();
        }       

    }

    void OnCollisionEnter(Collision con)
    {
        if (!GameManeger.isGameWin)
        {
            if (con.transform.CompareTag("Finish"))
            {
                GameManeger.isGameWin = true;
                DOTween.KillAll();
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                _animator.SetBool("Stop", false);
                _animator.Play("Walking");
                GameManeger.instance.win.Play();
                this.transform.DOMove(new Vector3(0, 1, 51.91f), 1f).OnComplete(animationStop);
            }
        }

    }

    void animationStop()
    {
        if (!GameManeger.isGameWin)
        {
        _animator.SetBool("Stop", true); 
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        Arrow.instance.arrowStart();
        GameManeger.buttonBreak = true;

        }
        else{
            _animator.SetBool("Stop", true);
            
            GameManeger.instance.nextLevel();
        }


    }
}
