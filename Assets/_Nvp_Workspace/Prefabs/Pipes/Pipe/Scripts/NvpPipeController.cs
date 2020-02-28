using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class NvpPipeController : MonoBehaviour, IPoolItem
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _topPipe;
    [SerializeField] private Transform _bottomPipe;

    private System.Action<GameObject> _returnToPoolAction;
    private Transform _t;
    private bool _paused;
    

    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        _t = this.transform;
    }

    private void Update()
    {
        if (_paused) return;

        _t.Translate(Vector3.left * _moveSpeed * Time.deltaTime, Space.World);

        if (_t.position.x < -1000f)
        {
            _returnToPoolAction(this.gameObject);
        }
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPauseGame).GameEventHandler += OnPause;
        NvpEventBus.Events(GameEvents.OnResetPipes).GameEventHandler += OnResetPipes;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPauseGame).GameEventHandler -= OnPause;
        NvpEventBus.Events(GameEvents.OnResetPipes).GameEventHandler -= OnResetPipes;
    }


    // +++ IPoolItem implementation +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SetReturnAction(Action<GameObject> returnToPoolAction)
    {
        _paused = false;
        if (_returnToPoolAction == null) _returnToPoolAction = returnToPoolAction;
    }




    // +++ eventhandler +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPause(object sender, EventArgs e)
    {
        var ea = (GenericEventArgs)e;
        _paused = ea.GetValue<bool>();
    }

    private void OnResetPipes(object sender, EventArgs e)
    {
        _returnToPoolAction(this.gameObject);
    }




    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void ReturnToPool()
    {
        _returnToPoolAction(this.gameObject);
    }

    public void SetGap(float gap)
    {
        _topPipe.transform.localPosition = new Vector3(0f, gap / 2f, 0f);
        _bottomPipe.transform.localPosition = new Vector3(0f, -gap / 2f, 0f);
    }
}
