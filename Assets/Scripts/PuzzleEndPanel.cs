using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleEndPanel : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Text[] _levelTexts;

    public event Action OnClick;

    private bool _clicked = false;

    public void SetLevel(int level)
    {
        for (int i = 0; i < _levelTexts.Length; i++)
        {
            _levelTexts[i].text = "Level " + level.ToString();
        }
    }

    public void OnTap()
    {
        if(_clicked)
        {
            return;
        }
        _clicked = true;
        OnClick?.Invoke();
    }

    public void Show(bool win)
    {
        _winPanel.SetActive(win);
        _losePanel.SetActive(!win);
        gameObject.SetActive(true);
    }
}
