using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour {
	
	public Teleporter otherEnd;
	Node node;
	Spline spline;
	// Use this for initialization
	void Awake () {
		node = GetComponent<Node> ();
		spline = node.transform.parent.GetComponent<Spline> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if(player.
	}
	
	public void teleport(Creature creature){
		if (!creature.teleported) {
			creature.teleported = true;
			creature.targetNode = otherEnd.node;
			creature.transform.parent = spline.transform;
			creature.transform.position = otherEnd.transform.position;
		}
		else{
			creature.teleported = false;
		}
	}
	
	void OnTriggerEnter(Collider col){
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if (creature && !creature.teleported) {
			creature.teleported = true;
			creature.transform.position = otherEnd.transform.position;
		}
	}
	
	void OnTriggerExit(Collider col){
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if (creature && creature.teleported) {
			creature.teleported = false;
		}
	}
}