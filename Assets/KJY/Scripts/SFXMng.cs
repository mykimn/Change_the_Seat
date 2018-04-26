using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum AudioEnum
{
    Success,
}
public class SFXMng : MonoBehaviour
{
    public static SFXMng instance;
    public AudioSource audio;
    public AudioClip[] clips;
    //public Slider SFXSlider;
    private void Start()
    {
        if (instance == null)
            instance = this;
        audio = GetComponent<AudioSource>();

    }

    public void SFXPlay(int num)
    {
        audio.PlayOneShot(clips[num]);
    }
}