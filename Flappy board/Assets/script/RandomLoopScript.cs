using UnityEngine;
using System.Collections;

public class RandomLoopScript : MonoBehaviour {
    public AudioClip[] m_loops;
    AudioClip m_current;

	// Use this for initialization
	void Start () {
        m_current = m_loops[Random.Range(0, m_loops.Length)];
        AudioSource source = GetComponent<AudioSource>();
        source.loop = true;
        source.clip = m_current;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
