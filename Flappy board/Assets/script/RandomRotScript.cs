using UnityEngine;
using System.Collections;

public class RandomRotScript : MonoBehaviour {
    public float m_minAngle = 0;
    public float m_maxAngle = 0;
    public float m_minTorque = 0;
    public float m_maxTorque = 0;

    // Use this for initialization
    void Start () {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.rotation = Random.Range(m_minAngle, m_maxAngle);
        body.angularVelocity = Random.Range(m_minTorque, m_maxTorque);
	}
}
