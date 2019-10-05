using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;

public class NvpBirdController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _gravity = new Vector3(0f, -9.81f, 0f);

    private Vector3 _velocity = Vector3.zero;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
    }

    private void Update()
    {
        _velocity += _gravity * Time.deltaTime;
        this.transform.position = this.transform.position + _velocity;
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerJumps).GameEventHandler += OnPlayerJumps;    
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerJumps).GameEventHandler -= OnPlayerJumps;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPlayerJumps(object sender, EventArgs e)
    {
        _velocity = new Vector3(0f, _jumpForce, 0f);        
    }

}
