using UnityEngine;
using System.Collections;

public class RandomRotScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().rotation = Random.Range(-45, 45);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
