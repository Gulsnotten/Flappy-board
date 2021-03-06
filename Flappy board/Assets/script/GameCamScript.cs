﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameCamScript : MonoBehaviour {
    public GameObject[] m_objects;
    public GameObject m_ender;
    public float m_scrollSpeed;
    public float m_offset = -2;
    public bool m_followOn = true;

    float m_posX;
    bool m_done;

    AudioSource m_source;

	// Use this for initialization
	void Start () {
        m_posX = 0;
        m_done = false;
        m_source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_followOn == true)
        {
            SetCamPos();
        }
        CheckIfDone();
	}
    void SetCamPos()
    {
        m_posX += m_scrollSpeed * Time.deltaTime;
        float maxPos = m_posX;

        foreach (GameObject obj in m_objects) {
            if (obj != null) {
                float x = obj.transform.position.x + m_offset;
                if (x > maxPos) {
                    maxPos = x;
                }
            }
        }

        m_posX = maxPos;

        //set cam pos
        Vector3 pos = transform.position;
        pos.x = m_posX;
        transform.position = pos;
    }

    void CheckIfDone()
    {
        int length = 0;
        GameObject winner = new GameObject();

        foreach (GameObject obj in m_objects) {
            if (obj != null) {
                length++;
                winner = obj;
            }
        }

        if (length == 1 && !m_done) {
            winner.GetComponent<PlayerSoundScript>().PlayWinSound();

            m_done = true;
            GameObject ender = Instantiate(m_ender, winner.transform.position, winner.transform.rotation);

            foreach (ParticleSystem ps in winner.GetComponentsInChildren<ParticleSystem>())
            {
                ps.Play();
            }
        }
    }
}
