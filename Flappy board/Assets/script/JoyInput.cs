using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyInput : InputModuleScript
{
    public int m_controllerIndex;
    public KeyCode m_select;
    public KeyCode m_back;

    bool m_left;
    bool m_right;
    bool m_up;
    bool m_down;

    private void Update()
    {
        float x = GetXAxis();
        float y = GetYAxis();
       
        if (x == 0f) {
            m_left = false;
            m_right = false;
        }
        if (y == 0f) {
            m_up = false;
            m_down = false;
        }
    }

    public override float GetUp(bool p_pressed)
    {
        float axis = GetYAxis();

        if (axis > 0f) {
            m_up = true;

            if (p_pressed) {
                if (!m_up) {
                    return axis;
                }
            }
            else {
                return axis;
            }
        }

        return 0f;
    }
    public override float GetLeft(bool p_pressed)
    {
        float axis = GetXAxis();

        if (axis < 0f) {
            m_left = true;

            if (p_pressed) {
                if (!m_left) {
                    return -axis;
                }
            }
            else {
                return -axis;
            }
        }

        return 0f;
    }
    public override float GetDown(bool p_pressed)
    {
        float axis = GetYAxis();

        if (axis < 0f) {
            m_down = true;

            if (p_pressed) {
                if (!m_down) {
                    return -axis;
                }
            }
            else {
                return -axis;
            }
        }

        return 0f;
    }
    public override float GetRight(bool p_pressed)
    {
        float axis = GetXAxis();

        if (axis > 0f) {
            m_right = true;

            if (p_pressed) {
                if (!m_right) {
                    return axis;
                }
            }
            else {
                return axis;
            }
        }

        return 0f;
    }
    public override bool GetSelect(bool p_pressed)
    {
        if (p_pressed) {
            return Input.GetKeyDown(m_select);
        }
        else {
            return Input.GetKey(m_select);
        }
    }
    public override bool GetBack(bool p_pressed)
    {
        if (p_pressed) {
            return Input.GetKeyDown(m_back);
        }
        else {
            return Input.GetKey(m_back);
        }
    }

    float GetXAxis()
    {
        return Input.GetAxis("HorizontalController" + m_controllerIndex.ToString());
    }
    float GetYAxis()
    {
        return Input.GetAxis("VerticalController" + m_controllerIndex.ToString());
    }
}
