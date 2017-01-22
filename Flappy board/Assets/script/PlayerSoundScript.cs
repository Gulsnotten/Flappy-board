using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundScript : MonoBehaviour {
    public AudioClip[] m_boost;
    public AudioClip[] m_bump;
    public AudioClip[] m_die;
    public AudioClip[] m_jump;
    public AudioClip[] m_doubleJump;
    public AudioClip[] m_win;
    public float m_volume = 1f;

    AudioSource m_source;

    // Use this for initialization
    void Start () {
        m_source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D p_other)
    {
        if (p_other.gameObject.tag == "player") {
            m_source.PlayOneShot(GetRandom(m_bump), m_volume);
        }
    }

    public void PlayJump()
    {
        m_source.PlayOneShot(GetRandom(m_jump), m_volume);
    }
    public void PlayDoubleJump()
    {
        m_source.PlayOneShot(GetRandom(m_doubleJump), m_volume);
    }

    public AudioClip GetDeathSound()
    {
        AudioClip clip = GetRandom(m_die);
        return clip;
    }

    public AudioClip PlayWinSound()
    {
        AudioClip clip = GetRandom(m_win);
        m_source.PlayOneShot(clip, m_volume);
        return clip;
    }

    AudioClip GetRandom(AudioClip[] p_arr)
    {
        return p_arr[Random.Range(0, p_arr.Length)];
    }
}
