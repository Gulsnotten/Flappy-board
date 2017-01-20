using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
    Rigidbody2D m_rigidBody;
    public float m_jumpHeight = 10f;
    public float walkSpeed;

    bool canJump;

	// Use this for initialization
	void Start () {
        m_rigidBody = GetComponent<Rigidbody2D>();

        canJump = false;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 vel = m_rigidBody.velocity;

	    if (canJump && Input.GetKey(KeyCode.UpArrow)) {
            vel.y = m_jumpHeight;
            m_rigidBody.AddForce(new Vector2(0, m_jumpHeight));
            m_rigidBody.velocity = vel;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            m_rigidBody.AddForce(new Vector2(-walkSpeed, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            m_rigidBody.AddForce(new Vector2(walkSpeed, 0));
        }
    }

    private void OnCollisionStay2D(Collision2D p_other)
    {
        canJump = false;

        foreach (ContactPoint2D contact in p_other.contacts) {
            if (contact.normal.y > 0) {
                canJump = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
