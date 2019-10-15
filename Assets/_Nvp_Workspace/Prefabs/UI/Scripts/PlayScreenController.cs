using System;
using System.Collections;
using System.Collections.Generic;
using nvp.events;
using UnityEngine;
using TMPro;

public class PlayScreenController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private TextMeshProUGUI _scoreText;

    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnScoreChanged).GameEventHandler += OnScoreChanged;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnScoreChanged).GameEventHandler -= OnScoreChanged;
    }

    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnScoreChanged(object sender, EventArgs e)
    {
        var ea = (IntEventArgs)e;
        _scoreText.text = ea.Value.ToString("00");
    }
}
