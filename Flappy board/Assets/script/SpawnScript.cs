using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    public float m_interval;
    public GameObject[] m_platforms;
    public float m_spawnX = 10;
    public float m_spawnY = -2;
    public float m_rangeY = 5;

    int m_length;
    float m_lastSpawnX;

	// Use this for initialization
	void Start () {
        m_lastSpawnX = -m_interval;
        m_length = m_platforms.Length;
	}
	
	// Update is called once per frame
	void Update () {
        float campos = Camera.main.transform.position.x;
        if (m_lastSpawnX + m_interval < campos) {
            m_lastSpawnX = campos;

            GameObject plat = m_platforms[Random.Range(0, m_length)];

            Vector3 spawn = new Vector2(m_lastSpawnX + m_spawnX, m_spawnY + Random.Range(-m_rangeY, m_rangeY));
            spawn.z = 0;
            Instantiate(plat, spawn, transform.rotation);
        }
	}
}
