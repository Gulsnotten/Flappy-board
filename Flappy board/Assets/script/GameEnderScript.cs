using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnderScript : MonoBehaviour {
    public float m_length;
    float m_time;
    bool m_switched;
    public bool m_IsRumble = true;
    public string[] m_RumbleLevels;

    private void Start()
    {
        m_switched = false;
    }

    // Update is called once per frame
    void Update () {
        m_time += Time.deltaTime;

        if (m_time > m_length) {
            if (m_IsRumble == true)
            {
                int rand = Random.Range(0, m_RumbleLevels.Length+1);
                SceneManager.LoadScene(m_RumbleLevels[rand]);
            }
            else
            {
                m_switched = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
