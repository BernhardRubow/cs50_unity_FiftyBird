using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawningSystemController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _spawningInterval;
    [SerializeField] private float _spawningTimer;
    [SerializeField] private Transform _pipeSpawnPoint;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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

            pipe.transform.position = _pipeSpawnPoint.position;
            pipe.gameObject.SetActive(true);

        }
    }
}
