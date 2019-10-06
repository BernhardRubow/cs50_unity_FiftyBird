using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class Nvp_BackgroundScroller : MonoBehaviour
{ 
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Renderer _backgroundPlaneRenderer;
    [SerializeField] private Renderer _groundPlaneRenderer;
    [SerializeField] private float _scrollSpeedBackground;
    [SerializeField] private float _scrollSpeedGround;

    private Vector3 _offsetBackground;
    private Vector3 _offsetGround;

    private bool _paused;


    // Start is called before the first frame update
    void Start()
    {
        _offsetBackground = Vector2.zero;
        _offsetGround = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (_paused) return;

        _offsetBackground.x = Time.time * _scrollSpeedBackground;
        _backgroundPlaneRenderer.material.SetTextureOffset("_MainTex", _offsetBackground);

        _offsetGround.x = Time.time * _scrollSpeedGround;
        _groundPlaneRenderer.material.SetTextureOffset("_MainTex", _offsetGround);
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerHitsPipe).GameEventHandler += OnPlayerHitsPipe;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerHitsPipe).GameEventHandler -= OnPlayerHitsPipe;
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPlayerHitsPipe(object sender, EventArgs e)
    {
        _paused = true;
    }
}
