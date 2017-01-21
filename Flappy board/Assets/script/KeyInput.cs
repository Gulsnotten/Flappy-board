using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : InputModuleScript {
    public KeyCode m_up;
    public KeyCode m_down;
    public KeyCode m_left;
    public KeyCode m_right;
    public KeyCode m_select;
    public KeyCode m_back;

    public override float GetUp(bool p_pressed)
    {
        return GetAxis(m_up, p_pressed);
    }
    public override float GetDown(bool p_pressed)
    {
        return GetAxis(m_down, p_pressed);

    }
    public override float GetLeft(bool p_pressed)
    {
        return GetAxis(m_left, p_pressed);
    }
    public override float GetRight(bool p_pressed)
    {
        return GetAxis(m_right, p_pressed);
    }
    public override bool GetSelect(bool p_pressed)
    {
        return GetButton(m_select, p_pressed);
    }
    public override bool GetBack(bool p_pressed)
    {
        return GetButton(m_back, p_pressed);
    }

    bool GetButton(KeyCode p_key, bool p_pressed)
    {
        if (p_pressed) {
            return Input.GetKeyDown(p_key);
        }
        else {
            return Input.GetKey(p_key);
        }
    }
    float GetAxis(KeyCode p_key, bool p_pressed)
    {
        if (GetButton(p_key, p_pressed)) {
            return 1f;
        }
        return 0;
    }
}
