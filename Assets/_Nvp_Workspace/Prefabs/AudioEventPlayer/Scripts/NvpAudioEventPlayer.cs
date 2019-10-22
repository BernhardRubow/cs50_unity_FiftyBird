using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class NvpAudioEventPlayer : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private NvpAudioEvent _audioEvent;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameEvents _subscribedAudioEvent;
    [SerializeField] private bool _playOnlyOnTime;

    private bool _played;


    


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        NvpEventBus.Events(_subscribedAudioEvent).GameEventHandler += OnPlayerScores;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(_subscribedAudioEvent).GameEventHandler -= OnPlayerScores;
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnPlayerScores(object sender, System.EventArgs e)
    {
        if (_playOnlyOnTime && _played) return;

        var ea = (GenericEventArgs)e;
        this.transform.position = ea.GetValue<Vector3>();
        _audioEvent.Play(_audioSource);
        _played = true;
    }

}
