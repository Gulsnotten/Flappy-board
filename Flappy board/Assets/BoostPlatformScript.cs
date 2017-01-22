using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatformScript : MonoBehaviour
{
    Transform m_transform;
    Rigidbody2D m_ridgidbody;
    public float xForce;
    public float yForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            m_ridgidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            m_ridgidbody.velocity = new Vector2(xForce, yForce);
        }
    }
}
