using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
    Rigidbody2D m_rigidBody;
    public float m_jumpHeight = 10f;
    public float walkSpeed;
    public float m_maxSpeed = 2f;
    public float m_rotationSpeed = 1f;
    public float m_boost = 10f;
    public float m_boostY = 5f;

    bool canJump;
    bool canBoost;
    Vector2 normal;

    public bool isInputController;
    public int ControllerNumber;

    public KeyCode m_left = KeyCode.LeftArrow;
    public KeyCode m_right = KeyCode.RightArrow;
    public KeyCode m_up = KeyCode.UpArrow;
    public KeyCode m_down = KeyCode.DownArrow;

    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody2D>();

        canJump = false;
        canBoost = false;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 vel = m_rigidBody.velocity;

	    if (canJump) {
            if (Input.GetKey(m_up)) {
                Vector2 jump = normal * m_jumpHeight;
                m_rigidBody.AddForce(jump);
            }
        }
        else {
            if (Input.GetKeyDown(m_up) && canBoost) {
                canBoost = false;

                float rot = m_rigidBody.rotation;
                float rad = rot / (180 / Mathf.PI);

                Vector2 normalized = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

                Vector2 newvel = m_rigidBody.velocity;// normalized * m_boost;
                newvel.y = m_boostY;

                m_rigidBody.velocity = newvel;
                //m_rigidBody.AddForce(normalized * m_boost);
            }

            //if (Input.GetKey(m_left)) {
            //    m_rigidBody.AddTorque(m_rotationSpeed);
            //}
            //if (Input.GetKey(m_right)) {
            //    m_rigidBody.AddTorque(-m_rotationSpeed);
            //}
        }

        if (isInputController == true) {
            string xAxis = "HorizontalController" + ControllerNumber.ToString();


            //m_rigidBody.AddForce(new Vector2(-walkSpeed * Input.GetAxis(xAxis), 0));

            if (Input.GetAxis(xAxis) < 0.0f) {
                if (vel.x > -m_maxSpeed)
                    m_rigidBody.AddForce(new Vector2(walkSpeed * Input.GetAxis(xAxis), 0));
            }

            if (Input.GetAxis(xAxis) > 0.0f) {
                if (vel.x < m_maxSpeed)
                    m_rigidBody.AddForce(new Vector2(walkSpeed * Input.GetAxis(xAxis), 0));
            }
        }
        else 
        {
            if (Input.GetKey(m_left)) {
                if (vel.x > -m_maxSpeed)
                    m_rigidBody.AddForce(new Vector2(-walkSpeed, 0));
            }
            if (Input.GetKey(m_right)) {
                if (vel.x < m_maxSpeed)
                    m_rigidBody.AddForce(new Vector2(walkSpeed, 0));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canBoost = true;
    }

    private void OnCollisionStay2D(Collision2D p_other)
    {
        canJump = false;

        foreach (ContactPoint2D contact in p_other.contacts) {
            if (contact.normal.y > 0) {
                canJump = true;
                normal = contact.normal;

                float normal_angle = Mathf.Atan2(normal.y, normal.x) * 180 / Mathf.PI;

                m_rigidBody.rotation = normal_angle - 90;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
