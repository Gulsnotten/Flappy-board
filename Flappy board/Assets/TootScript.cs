﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TootScript : MonoBehaviour {
    bool tooted;
    public float m_minPitch = -0.2f;
    public float m_maxPitch = 0.2f;

    AudioSource m_source;

    // Use this for initialization
    void Start () {
        m_source = GetComponent<AudioSource>();
        m_source.pitch = 1 + Random.Range(m_minPitch, m_maxPitch);
        tooted = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //m_source.PlayOneShot(m_source.clip, 1f);

        if (!tooted) {
            tooted = true;
            m_source.Play();
        }
    }
}
