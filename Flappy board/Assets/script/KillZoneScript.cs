using UnityEngine;
using System.Collections;

public class KillZoneScript : MonoBehaviour {
    public GameObject m_explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerExit2D(Collider2D p_other)
    {
        if (p_other.gameObject.tag == "player") {
            Vector3 campos = Camera.main.transform.position;

            Vector3 dif = campos - p_other.gameObject.transform.position;

            float angle = Mathf.Atan2(dif.y, dif.x) * 180 / Mathf.PI;
            angle -= 90;

            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);

            Instantiate(m_explosion, p_other.gameObject.transform.position, rot);
        }

        Destroy(p_other.gameObject);
    }
}
