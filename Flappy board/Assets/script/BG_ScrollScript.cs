using UnityEngine;
using System.Collections;

public class BG_ScrollScript : MonoBehaviour {
    private Vector3 startPosition;
    public float m_scrollSpeed;
    public float m_tileSize;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float campos = Camera.main.transform.position.x;

        float newPosition = Mathf.Repeat(Time.time * m_scrollSpeed, m_tileSize) - campos;
        transform.position = startPosition + (Vector3.left * newPosition);
    }
}
