using System;
using UnityEngine;
/*
 * This class functions to destroy bombs when it hits the ground or player
 */
public class BombDestroy : MonoBehaviour
{
    //Makes delegate and delegate event
    public delegate void SampleDel();
    public static event SampleDel sampleEvent;
    // Lambda statement implementation. The Action is merely used to facilitate implementation.
    private Action _explode = () =>
    {
        AudioManager.PlayBomb();
    };

    //when bomb collides with player or ground bomb gets destoryed
    //and a event happens when it hits player
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.tag == "Player")
        {
            if (sampleEvent != null) sampleEvent();
            _explode();
            Destroy(gameObject);
        }
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
