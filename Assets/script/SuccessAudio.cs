using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessAudio : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip Success;

    // Use this for initialization
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.Success;
        this.audio.loop = false;

    }

    // Update is called once per frame
    void Update()
    {
        this.audio.Play();
    }
}
