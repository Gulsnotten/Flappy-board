using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnderScript : MonoBehaviour {
    public float m_length;
    float m_time;
    bool m_switched;

    private void Start()
    {
        m_switched = false;
    }

    // Update is called once per frame
    void Update () {
        m_time += Time.deltaTime;

        if (m_time > m_length) {
            m_switched = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnDestroy()
    {
        if (!m_switched) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
