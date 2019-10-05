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
        CheckPipeSpawnCondition();
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
            pipe.GetComponent<NvpPripeController>().SetGap(nextGapSize);
            pipe.gameObject.SetActive(true);
        }
    }

    
}
