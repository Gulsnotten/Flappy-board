using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    public float m_interval;
    public GameObject[] m_platforms;
    public float m_spawnX = 10;
    public float m_spawnY = -2;
    public float m_rangeY = 5;
    private int m_count = 0;
    private int m_harderMode = 0;

    float m_lastSpawnX;

	// Use this for initialization
	void Start () {
        m_lastSpawnX = -m_interval;
	}
	
	// Update is called once per frame
	void Update () {
        float campos = Camera.main.transform.position.x;
        if (m_lastSpawnX + m_interval < campos) {
            m_lastSpawnX = campos;
            if (m_harderMode < 4)
            {
                    m_harderMode++;   
            }
            GameObject plat = m_platforms[Random.Range(0, m_harderMode)];
            Vector3 spawn = new Vector2(m_lastSpawnX + m_spawnX, m_spawnY + Random.Range(-m_rangeY, m_rangeY));
            spawn.z = 0;
            Instantiate(plat, spawn, transform.rotation);
        }
	}
}
