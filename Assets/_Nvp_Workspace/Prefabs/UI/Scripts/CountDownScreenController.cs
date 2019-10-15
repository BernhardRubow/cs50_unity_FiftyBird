using System;
using System.Collections;
using System.Collections.Generic;
using nvp.events;
using UnityEngine;
using TMPro;


public class CountDownScreenController : MonoBehaviour
{
    // +++ Fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private TextMeshProUGUI _countdownDisplayText;


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnCountDownValueChanged).GameEventHandler += OnCountDownValueChanged;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnCountDownValueChanged).GameEventHandler -= OnCountDownValueChanged;
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnCountDownValueChanged(object sender, EventArgs e)
    {
        var ea = (IntEventArgs) e;
        _countdownDisplayText.text = $"- {ea.Value} -";
    }
}
