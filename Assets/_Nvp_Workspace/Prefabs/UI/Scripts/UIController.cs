using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class UIController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Canvas _titleScreen;
    [SerializeField] private Canvas _countDownScreen;
    [SerializeField] private Canvas _playScreen;
    [SerializeField] private Canvas _scoreScreen;
    [SerializeField] private Canvas _gameOverScreen;



    // +++ life cylce +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnUIChanged).GameEventHandler += OnShowGameScreen;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnUIChanged).GameEventHandler -= OnShowGameScreen;
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnShowGameScreen(object sender, EventArgs e)
    {
        var ea = (GenericEventArgs)e;

        _titleScreen.gameObject.SetActive(false);
        _countDownScreen.gameObject.SetActive(false);
        _playScreen.gameObject.SetActive(false);
        _scoreScreen.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);

        switch (ea.GetValue<UiNames>())
        {
            case UiNames.title:
                _titleScreen.gameObject.SetActive(true);
                break;

            case UiNames.countdown:
                _countDownScreen.gameObject.SetActive(true);
                break;

            case UiNames.play:
                _playScreen.gameObject.SetActive(true);
                break;

            case UiNames.score:
                _scoreScreen.gameObject.SetActive(true);
                break;

            case UiNames.gameover:
                _gameOverScreen.gameObject.SetActive(true);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}