using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioManager AudioManager;

    void Awake()
    {
        AudioManager = FindObjectOfType<AudioManager>();
        PlayMusic();
    }

    private void PlayMusic()
    {
        AudioManager.Play("Fight Music");
    }
}
