using UnityEngine;
using System.Collections;

public class KillEffectScript : MonoBehaviour {
    Animation m_animation;

	// Use this for initialization
	void Start () {
        m_animation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        


        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(gameObject);
        }
	}
}
