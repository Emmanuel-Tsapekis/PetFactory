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
	[SerializeField] private List<Button> buttonsToTeleport;
	private bool isWaitingToTeleport = false;
	private bool isInTeleporter = false;
	private Creature creatureWaiting;
	[SerializeField] private GameObject firewall;
	//flick logic
	public bool canFlick;
	public Node flickTarget;

	public bool ISLASTNODE;
	public bool ISCUTE;

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
		if (isWaitingToTeleport && isInTeleporter) {
			firewall.SetActive (true);
		} 
		else if(isInTeleporter && AllButtonsPressed() ) {
			isWaitingToTeleport = false;
			firewall.SetActive (false);
			Teleport (creatureWaiting);
		}
	}

	public void TeleportEnter(Creature creature){
		isInTeleporter = true;
		if (AllButtonsPressed()) {
			isWaitingToTeleport = false;
			Teleport(creature);
		}
		else {
			creatureWaiting = creature;
			isWaitingToTeleport = true;
		}
	}
 	private bool AllButtonsPressed(){
		if (buttonsToTeleport.Count == 0) {
			return true;
		}
		foreach (Button button in buttonsToTeleport) {
			if(!button.isPressed){
				return false;
			}
		}
		return true;
	}
	private void Teleport(Creature creature)
	{
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
		isInTeleporter = false;
	}
}