using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	//basic node
	public Node prevNode;
	public Node nextNode;

	//teleportation
	public bool isTeleporter;
	public Node teleportDestination;
	[SerializeField] private List<Button> buttons;

	//flick logic
	public bool canFlick;
	public Node flickTarget;

	private int identifier = 0;
	public int ID 
	{
		get 
		{
			if (identifier == 0) {
                string number = transform.name.Replace("Node (", "").Replace(")", "");
                ID = int.Parse (number);
			}
			return identifier;
		}
		set
		{
			identifier = value;
		}
	}
	public void Update()
	{

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