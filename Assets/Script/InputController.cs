
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //Rigidbody drink;
    //public Transform arrow;
    //[SerializeField] Transform arrowSpeedBar;
    //RaycastHit hit, rayHit;
    //LineRenderer lineRendererBtCoin;
    public static InputController Instance;
    bool isIncrease;
    public float angleInDegrees;

    enum PlayState
    {
        None,
        FindRotation,
        DetermineSpeed,
        Run
    }
    PlayState playState;

    //Quaternion vector;
    //public bool isFirstControl;
    //[HideInInspector] public bool isLaunch;
    //[HideInInspector] public Transform selectedDrink;
    //float lastTime;
    //float endRatio;
    
    //public LayerMask borderLayer;
    //Vector3 targetPos;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isIncrease = true;
        playState = PlayState.None;
        angleInDegrees = 315f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playState == PlayState.None || playState == PlayState.FindRotation)
            {
                playState = PlayState.DetermineSpeed;
                Debug.Log("SA");

            }
            else if (playState == PlayState.DetermineSpeed)
            {
                playState = PlayState.Run;
                Debug.Log("SA1");

            }
            else if (playState == PlayState.Run)
            {
                playState = PlayState.FindRotation;
                Debug.Log("SA2");

            }
            isIncrease = true;
        }
    }
    //void FixedUpdate()
    //{
    //    if (!isLaunch)
    //    {
    //        if (playState == PlayState.None || playState == PlayState.FindRotation)
    //        {
    //            if (Time.time + 0.1f > lastTime)
    //            {
    //                if (isIncrease)
    //                {
    //                    angleInDegrees += .75f;
    //                    if (angleInDegrees >= 415)
    //                    {
    //                        isIncrease = false;
    //                    }
    //                }
    //                else
    //                {
    //                    angleInDegrees -= .75f;
    //                    if (angleInDegrees <= 315)
    //                    {
    //                        isIncrease = true;
    //                    }
    //                }
    //                lastTime = Time.time;
    //            }

    //            if (selectedDrink != null)
    //            {
    //                if (angleInDegrees < 0)
    //                {
    //                    angleInDegrees += 360;
    //                }
    //                arrow.localEulerAngles = new Vector3(90, 0, -angleInDegrees);
    //            }

    //        }
    //        else if (playState == PlayState.DetermineSpeed)
    //        {
    //            if (isIncrease)
    //            {
    //                endRatio += Time.fixedDeltaTime;
    //                if (endRatio >= 1)
    //                {
    //                    isIncrease = false;
    //                }
    //            }
    //            else
    //            {
    //                endRatio -= Time.fixedDeltaTime;
    //                if (endRatio <= 0)
    //                {
    //                    isIncrease = true;
    //                }
    //            }
    //            arrowSpeedBar.DOScaleY(endRatio * 1.6f, .1f);
    //        }
    //        else if (playState == PlayState.Run)
    //        {
    //            //Barman.Instance.SetPushAnim();
    //            isLaunch = true;
    //        }
    //    }
    //}

    //public void PushTheDrink()
    //{
    //    //aim.line.Clear();
    //    arrow.gameObject.SetActive(false);
    //    // targetLine.line.Clear();
    //    drink = selectedDrink.GetComponent<Rigidbody>();
    //    drink.AddForce((targetPos - selectedDrink.position).normalized * 999f * endRatio);
    //    playState = PlayState.FindRotation;
    //    endRatio = 0;
    //    arrowSpeedBar.DOScaleY(0, 0.1f);
    //}
}
