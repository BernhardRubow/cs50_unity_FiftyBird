using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class NvpAudioEventPlayer : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private NvpAudioEvent _audioEvent;
    [SerializeField] private AudioSource _audioSource;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler += OnPlayerScores;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnPlayerScores).GameEventHandler -= OnPlayerScores;
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPlayerScores(object sender, System.EventArgs e)
    {
        var ea = (Vector3EventArgs)e;
        this.transform.position = ea.Value;
        _audioEvent.Play(_audioSource);
    }

}
