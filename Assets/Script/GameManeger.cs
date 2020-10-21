using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isGameWin;
    public static bool buttonBreak;
    public ParticleSystem win;
    public static GameManeger instance;
    public GameObject nextLevelPanel;
    public GameObject tapToPlayPanel;
    public GameObject replayPanel;

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;

    }

    void Start()
    {
        buttonBreak = true;
        isGameOver = false;
        isGameWin = false;
    }

    void Update()
    {
        if (buttonBreak)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Anima._animator.SetBool("Stop", false);
                Arrow.instance.transform.DOKill();
                Arrow.instance.transform.GetChild(0).GetChild(0).DOScaleY(1.08f, 0.3f).SetLoops(-1, LoopType.Yoyo);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Arrow.instance.transform.GetChild(0).GetChild(0).DOKill();
                Arrow.instance.gameObject.SetActive(false);
                float param = Arrow.instance.transform.GetChild(0).GetChild(0).transform.localScale.y;
                float angle = Arrow.instance.transform.localEulerAngles.y;
                Vector3 distance = Arrow.instance.transform.GetChild(1).transform.position - Arrow.instance.transform.position;
                buttonBreak = false;
                Debug.Log(param);
                if(param< 0.25f)
                {
                    param = 0.25f;
                }
                Anima.instance.walk(distance, param, angle);

            }
        }

    }
    public void gameOver()
    {
        isGameOver = true;
        replayPanel.SetActive(true);

    }    
    public void nextLevel()
    {
        
        nextLevelPanel.SetActive(true);

    }
    public void Replay()
    {
        replayPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
