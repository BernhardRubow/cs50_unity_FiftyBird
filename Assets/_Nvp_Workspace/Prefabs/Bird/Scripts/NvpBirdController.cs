using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;

public class NvpBirdController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerJumps).GameEventHandler += OnPlayerJumps;    
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerJumps).GameEventHandler -= OnPlayerJumps;
    }

       


    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPlayerJumps(object sender, EventArgs e)
    {
        Debug.Log("OnPlayerJumps received");
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

}
