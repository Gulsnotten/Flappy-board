using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    public float m_interval;
    public GameObject[] m_platforms;
    public float m_spawnX = 10;
    public float m_rangeY = 5;

    int m_length;
    float m_time;

	// Use this for initialization
	void Start () {
        m_time = 0;
        m_length = m_platforms.Length;
	}
	
	// Update is called once per frame
	void Update () {
        m_time += Time.deltaTime;

        if (m_time > m_interval) {
            m_time = 0;

            GameObject plat = m_platforms[Random.Range(0, m_length - 1)];

            Vector3 spawn = new Vector2(m_spawnX, Random.Range(-m_rangeY, m_rangeY));
            spawn.z = 0;
            Instantiate(plat, spawn, transform.rotation);
        }
	}
}
