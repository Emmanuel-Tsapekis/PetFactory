using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	[SerializeField]
	private Node node;
	public Creature jumpingCreature;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other) {
		Creature creature = other.GetComponent<Creature>();
		if (creature) {
			creature.jumpNode = null;
		}
	}
	void OnTriggerEnter(Collider other) {
		Creature creature = other.GetComponent<Creature>();
		if (creature) {
			jumpingCreature =creature;
			creature.jumpNode = node;
		}
	}
	void OnCollisionEnter(Collision other){
		Destroy(other.gameObject);
	}
}
