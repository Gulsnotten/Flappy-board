using UnityEngine;
using System.Collections;

public class WaveMovementScript : MonoBehaviour {
    public float m_speed = 10f;
    public float m_amp;
    public float m_freq;
    float m_time;
    Rigidbody2D m_rigidBody;

	// Use this for initialization
	void Start () {
        m_time = Random.Range(0, Mathf.PI * 2);

        m_rigidBody = GetComponent<Rigidbody2D>();
        m_rigidBody.velocity = new Vector2(-m_speed, 0);
    }
	
	// Update is called once per frame
	private void Update () {
        m_time += Time.deltaTime;

        float currentVel = Mathf.Sin(m_time * m_freq) * m_amp * Time.deltaTime;

        Vector2 vel = m_rigidBody.velocity;
        vel.y = currentVel;

        m_rigidBody.velocity = vel;
    }
}
