using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDScript : MonoBehaviour {
    GameObject m_player;

    public int m_inputIndex;
    public int m_animationIndex;
    public InputModuleScript m_input;
    public AnimatorOverrideController m_animation;

    public GameObject Spawn(Vector3 p_pos)
    {
        GameObject player = Instantiate(m_player, p_pos, transform.rotation);

        player.GetComponent<Animator>().runtimeAnimatorController = m_animation;

        if (m_input.GetType() == typeof(KeyInput)) {
            AddKeyInput(player);
        }

        return player;
    }
    void AddKeyInput(GameObject p_player)
    {
        KeyInput pre = m_input as KeyInput;
        KeyInput input = p_player.AddComponent<KeyInput>();
        input.m_back = pre.m_back;
    }
}
