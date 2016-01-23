using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public sealed class SteeringAgent : MonoBehaviour
{
	public float MaxVelocity;
	public float MaxAngularVelocity;
	
	public Vector3 Velocity { get; private set; }
	private SteeringBehavior [] behaviour;
	private Creature creature;
	private Align alignScript;
	private float defaultY;
	void Start()
	{
		ResetVelocities ();
		alignScript = GetComponent<Align> ();
		behaviour = GetComponents<SteeringBehavior> ();
		creature = GetComponent<Creature> ();
		defaultY = transform.position.y;
	}
	
	public void steeringUpdate()
	{
		if (!creature.hault) 
		{
			UpdateVelocities (Time.deltaTime);
			UpdatePosition (Time.deltaTime);
			UpdateRotation (Time.deltaTime);
		}
	}
	
	public void ResetVelocities()
	{
		Velocity = Vector3.zero;
	}
	
	private void UpdateVelocities(float deltaTime)
	{		
		for (int i=0; i<behaviour.Length; ++i) {
			if(behaviour[i].enabled == false)
				continue;
			if(behaviour[i].Acceleration == Vector3.zero){
				Velocity += Vector3.zero;
				continue;
			}
			else
				Velocity += behaviour[i].Acceleration*Time.fixedDeltaTime;
			if(behaviour[i].HaltTranslation){
				Velocity = Vector3.zero;
				return;
			}
			else{
			}
		}
		Velocity = Vector3.ClampMagnitude (Velocity, MaxVelocity);
	}
	
	private void UpdatePosition(float deltaTime)
	{
		transform.position += Velocity * Time.fixedDeltaTime;
		transform.position = new Vector3 (transform.position.x, defaultY, transform.position.z);
	}
	
	private void UpdateRotation(float deltaTime)
	{
		alignScript.interpolatedChangeInOrientation (Velocity);
	}
}