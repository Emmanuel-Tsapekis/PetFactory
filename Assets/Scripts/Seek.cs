using UnityEngine;
using System.Collections;
using System;

public class Seek : SteeringBehavior
{
	Creature player;
	public Node target;    
	void Start()
	{
		player = GetComponent<Creature> ();
		target = player.targetNode;
	}
	
	public override Vector3 Acceleration
	{
		get
		{
			target = player.targetNode;
			return MaxAcceleration * (new Vector3(target.transform.position.x,0.0f,target.transform.position.z)-transform.position).normalized;
		}
	}
	
}