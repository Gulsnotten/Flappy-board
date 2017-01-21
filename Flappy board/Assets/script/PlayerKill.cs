using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour {
    public GameObject m_explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void OnDestroy()
    {
        Vector3 campos = Camera.main.transform.position;

        Vector3 dif = campos - transform.position;

        float angle = Mathf.Atan2(dif.y, dif.x) * 180 / Mathf.PI;
        angle -= 90;

        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(m_explosion, transform.position, rot);
    }
}
