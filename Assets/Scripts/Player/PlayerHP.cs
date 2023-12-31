﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int hpLossRate = 1; // how much HP is lost per second of looking at the target
    [SerializeField] private int startHp=100;
    [SerializeField] public int hp;
    [SerializeField] private float damageTimer;
    [SerializeField] private float damageCooldown;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private MirrorBlur mirrorBlur;
    void Start()
    {
        hp = startHp;
        audioSource = GetComponent<AudioSource>(); // Get the audio source component
        MirrorBlur mirrorBlur = GetComponent<MirrorBlur>();

        // Load the audio clip
        audioSource.clip = audioClip;

    }
    void Update()
    {
        damageTimer -= Time.deltaTime;
        DamageReceiveng();

    }
    private void DamageReceiveng()
    {

        if (mirrorBlur.damageIsRecieving==true)
        {
            if(damageTimer <= 0)
            {
                audioSource.Play();
                hp -= hpLossRate;
                damageTimer = damageCooldown;
            }
           
        }

    }


}
