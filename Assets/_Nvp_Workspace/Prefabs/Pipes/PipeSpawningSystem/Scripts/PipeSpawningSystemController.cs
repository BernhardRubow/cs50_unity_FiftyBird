using nvp.events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawningSystemController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _spawningInterval;
    [SerializeField] private float _spawningTimer;
    [SerializeField] private Transform _pipeSpawnPoint;

    private IHeightGenerator _spawnPositionCalculator;
    private IGapSizeGenerator _gapSizeGenerator;
    private float _lastHeight;
    private bool _paused;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        // TODO: implement Factory
        _spawnPositionCalculator = new RandomHeightGenerator();
        _spawnPositionCalculator.SetStartPosition(_pipeSpawnPoint.position);

        _gapSizeGenerator = new RandomGapSizeGenerator();
        _gapSizeGenerator.SetInitialGap(5f);

    }

    private void Update()
    {
        if (_paused) return;
        CheckPipeSpawnCondition();
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPauseGame).GameEventHandler += OnPause;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPauseGame).GameEventHandler -= OnPause;
    }



    
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private void OnPause(object sender, EventArgs e)
    {
        var ea = (PauseEventArgs)e;
        _paused = ea.Value;
    }




    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void CheckPipeSpawnCondition()
    {
        _spawningTimer += Time.deltaTime;
        if (_spawningTimer > _spawningInterval)
        {
            _spawningTimer = 0;

            var pipe = NvpPipePool.GetPooledItem();
            var nextSpawnLocation = _spawnPositionCalculator.GetNextSpawnPosition();
            var nextGapSize = _gapSizeGenerator.GetNextGap();

            pipe.transform.position = nextSpawnLocation;
            pipe.GetComponent<NvpPipeController>().SetGap(nextGapSize);
            pipe.gameObject.SetActive(true);
        }
    }

    
}
