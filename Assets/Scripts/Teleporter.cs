using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour {
	
	public Teleporter otherEnd;
	Node node;
	// Use this for initialization
	void Awake () {
		node = GetComponent<Node> ();
	}
		
	public void teleport(Creature creature){
		if (!creature.teleported) {
			creature.teleported = true;
			creature.ChangeTarget(otherEnd.node);
			creature.transform.position = otherEnd.transform.position;
		}
		else{
			creature.teleported = false;
		}
	}
	
	void OnTriggerEnter(Collider col){
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if (creature && !creature.teleported) {
			if(otherEnd)
			{
				teleport (creature);
			}
		}
	}
	
	void OnTriggerExit(Collider col){
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if (creature && creature.teleported) {
			creature.teleported = false;
		}
	}
}