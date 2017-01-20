using UnityEngine;
using System.Collections;

public class HoverboardScript : MonoBehaviour {
    public float m_amp = 1f;
    public float m_freq = 2f;

    bool m_touchingGround;
    float m_time;

	// Use this for initialization
	void Start () {
        m_touchingGround = false;
        m_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        m_time += Time.deltaTime;


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
