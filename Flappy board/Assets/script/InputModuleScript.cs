using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputModuleScript : MonoBehaviour {
    public abstract float GetUp(bool p_pressed);
    public abstract float GetDown(bool p_pressed);
    public abstract float GetLeft(bool p_pressed);
    public abstract float GetRight(bool p_pressed);
    public abstract bool GetSelect(bool p_pressed);
    public abstract bool GetBack(bool p_pressed);
}
