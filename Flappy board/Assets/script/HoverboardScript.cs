using UnityEngine;
using System.Collections;

public class HoverboardScript : MonoBehaviour {
    public float m_amp = 1f;
    public float m_freq = 2f;

    bool m_touchingGround;
    float m_time;

    Vector2 m_startPos;

	// Use this for initialization
	void Start () {
        m_touchingGround = false;
        m_time = 0;
        m_startPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        m_time += Time.deltaTime;

        transform.localPosition = m_startPos + new Vector2(0, Mathf.Sin(m_time * m_freq) * m_amp);
	}

    public void OnTouchGround()
    {
        m_touchingGround = true;
    }
    public void OnGroundExit()
    {
        m_touchingGround = false;
    }
}
