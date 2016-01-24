using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	[SerializeField]
	private Node node;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
	void OnCollisionEnter(Collision other){
		Destroy(other.gameObject);
	}
}
