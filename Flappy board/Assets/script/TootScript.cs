using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TootScript : MonoBehaviour {
    bool tooted;
    public float m_minPitch = -0.2f;
    public float m_maxPitch = 0.2f;
    public AudioClip[] m_angry;

    AudioSource m_source;
    const float tootVol = 0.3f;

    // Use this for initialization
    void Start () {
        m_source = GetComponent<AudioSource>();
        tooted = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_source.pitch = 1f;
        m_source.PlayOneShot(m_angry[Random.Range(0, m_angry.Length)], 0.7f);
        
        Animator ani = GetComponentInChildren<Animator>();
        ani.ResetTrigger("rustle");
        ani.SetTrigger("rustle");

        if (!tooted && Random.Range(0,2) == 0) {
            tooted = true;
            m_source.pitch = 1 + Random.Range(m_minPitch, m_maxPitch);
            m_source.PlayOneShot(m_source.clip, tootVol);
        }
    }
}
