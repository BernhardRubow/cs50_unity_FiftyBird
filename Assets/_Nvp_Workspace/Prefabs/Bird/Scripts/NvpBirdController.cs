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




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _velocity = new Vector3(0f, _jumpForce, 0f);
        }

        _velocity += _gravity * Time.deltaTime;
        this.transform.position = this.transform.position + _velocity;
    }
      

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ScoreTrigger")
        {
            var ea = new Vector3EventArgs { Value = this.transform.position };
            NvpEventBus.Events(GameEvents.OnPlayerScores).TriggerEvent(this, ea);
        }
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
   

}
