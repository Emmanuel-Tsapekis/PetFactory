using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public Node prevNode;
	public Node nextNode;
	private int identifier =0;
	public int ID 
	{
		get {
			if (identifier == 0) {
				string number = transform.name [transform.name.Length - 2].ToString ();
				ID = int.Parse (number);
			}
			return identifier;
		}
		set
		{
			identifier = value;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if(creature) 
		{
			creature.targetNode = this;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if(creature) 
		{
			creature.targetNode = this;
		}
	}
}