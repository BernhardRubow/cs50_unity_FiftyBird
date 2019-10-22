using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;
using nvp.events;

public class NvpBirdController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _gravity = new Vector3(0f, -9.81f, 0f);

    private Vector3 _velocity = Vector3.zero;
    private bool _paused = false;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Update()
    {
        if (_paused) return;

        if (Input.GetMouseButtonUp(0))
        {
            _velocity = new Vector3(0f, _jumpForce, 0f);
        }

        _velocity += _gravity * Time.deltaTime;
        this.transform.position = this.transform.position + _velocity;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ea = new GenericEventArgs(this.transform.position);
        if (collision.tag == "ScoreTrigger")
        {
            NvpEventBus.Events(GameEvents.OnPlayerScores).TriggerEvent(this, ea);
        }

        if (collision.tag == "Pipe")
        {
            NvpEventBus.Events(GameEvents.OnPlayerHitsPipe).TriggerEvent(this, ea);
            NvpEventBus.Events(GameEvents.OnPauseGame).TriggerEvent(this, new GenericEventArgs(true));
        }
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPauseGame).GameEventHandler += OnPauseGame;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPauseGame).GameEventHandler -= OnPauseGame;
    }


    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPauseGame(object sender, EventArgs e)
    {
        var ea = (GenericEventArgs)e;
        _paused = ea.GetValue<bool>();
    }

}
