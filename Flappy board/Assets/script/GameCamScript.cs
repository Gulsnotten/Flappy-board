using UnityEngine;
using System.Collections;

public class GameCamScript : MonoBehaviour {
    public GameObject[] m_objects;
    public float m_scrollSpeed;

    float m_posX;

	// Use this for initialization
	void Start () {
        m_posX = 0;
	}
	
	// Update is called once per frame
	void Update () {
        m_posX += m_scrollSpeed * Time.deltaTime;
        float maxPos = m_posX;

        foreach (GameObject obj in m_objects) {
            float x = obj.transform.position.x;
            if (x > maxPos) {
                maxPos = x;
            }
        }

        m_posX = maxPos;

        //set cam pos
        Vector3 pos = transform.position;
        pos.x = m_posX;
        transform.position = pos;
	}
}
