using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public Node prevNode;
	public Node nextNode;
	public bool isTeleporter;
	public Node teleportDestination;
	private int identifier = 0;
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

	public void Teleport(Creature creature){
		if (!creature.teleported && teleportDestination) {
			creature.ResetVelocities();
			creature.teleported = true;
			Node newTarget = teleportDestination.nextNode;
			creature.ChangeTarget(newTarget);
			creature.transform.LookAt(newTarget.transform.position);
			creature.transform.position = teleportDestination.transform.position;
		}
		else{
			creature.teleported = false;
		}
	}
}