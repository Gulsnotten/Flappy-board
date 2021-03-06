﻿using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
    public float m_jumpHeight = 10f;
    public float walkSpeed;
    public float m_maxSpeed = 2f;
    public float m_rotationSpeed = 1f;
    public float m_boost = 10f;
    public float m_boostY = 5f;
    public float m_volume = 0.7f;

    PlayerSoundScript m_sounds;
    Rigidbody2D m_rigidBody;
    InputModuleScript m_input;

    bool canJump;
    bool canBoost;
    bool releasedJump;
    Vector2 normal;
    public ParticleSystem m_jumpParticle;
    public ParticleSystem m_doubleJumpParticle;

    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_sounds = GetComponent<PlayerSoundScript>();
        m_input = GetComponent<InputModuleScript>();

        canJump = false;
        canBoost = false;
        releasedJump = false;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 vel = m_rigidBody.velocity;

        if (!m_input.GetSelect(false)) {
            releasedJump = true;
        }

	    if (canJump) {
            if (m_input.GetSelect(false) && releasedJump) {
                releasedJump = false;

                Vector2 jump = normal * m_jumpHeight;

                m_rigidBody.AddForce(jump);

                m_sounds.PlayJump();

                Instantiate(m_jumpParticle, transform.position, transform.rotation);
            }
        }
        else {
            if (m_input.GetSelect(true) && canBoost && releasedJump) {
                m_sounds.PlayDoubleJump();

                canBoost = false;

                float rot = m_rigidBody.rotation;
                float rad = rot / (180 / Mathf.PI);

                Vector2 normalized = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

                Vector2 newvel = m_rigidBody.velocity;// normalized * m_boost;
                newvel.y = m_boostY;

                m_rigidBody.velocity = newvel;

                Instantiate(m_doubleJumpParticle, transform.position, transform.rotation);
            }
        }

        if (m_input.GetLeft(false) > 0) {
            if (vel.x > -m_maxSpeed)
                m_rigidBody.AddForce(new Vector2(m_input.GetLeft(false) * -walkSpeed, 0));
        }
        if (m_input.GetRight(false) > 0) {
            if (vel.x < m_maxSpeed)
                m_rigidBody.AddForce(new Vector2(m_input.GetRight(false) * walkSpeed, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D p_other)
    {
        foreach (ContactPoint2D contact in p_other.contacts) {
            if (contact.normal.y > 0) {
                canBoost = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D p_other)
    {
        canJump = false;

        foreach (ContactPoint2D contact in p_other.contacts) {
            if (1 > 0) {
                canJump = true;
                normal = contact.normal;

                float normal_angle = Mathf.Atan2(normal.y, normal.x) * 180 / Mathf.PI;

                m_rigidBody.rotation = normal_angle - 90;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D p_other)
    {
        canJump = false;
    }
}
