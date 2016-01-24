using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

	public Node targetNode;
	[SerializeField] private float changeTargetDistance;
	[SerializeField] private LayerMask creatureLayer;
	[SerializeField] private float flickDistance;
	private SteeringAgent agent;
	public bool hault { get; private set;}
	public bool teleported = false;
	private Vector3 flickStartPosition;
	private bool isFlicking = false;
	// Use this for initialization
	void Awake () 
	{
		hault = false;
		agent = GetComponent<SteeringAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		hault = (targetNode)?false:true;
		if(!hault)
		{
			if(IsCloseToNode()) 
			{
				if(targetNode.nextNode)
				{
					ChangeTarget(targetNode.nextNode);
				}
				else if(targetNode.isTeleporter)
				{
					targetNode.Teleport(this);
				}
			}
			if(agent)
			{
				agent.steeringUpdate();
			}
		}
		if (targetNode.prevNode && targetNode.prevNode.canFlick) {
			// Handle native touch events
			foreach (Touch touch in Input.touches) {
				if(isFlicking || TouchesThisCreature(touch.position))
				{
					HandleTouch (touch.fingerId, Camera.main.ScreenToWorldPoint (touch.position), touch.phase);
				}
			}
		
			// Simulate touch events from mouse events
			if (Input.touchCount == 0) {
				if (Input.GetMouseButtonDown (0) && (isFlicking ||TouchesThisCreature(Input.mousePosition))) {
					HandleTouch (10, Camera.main.ScreenToWorldPoint (Input.mousePosition), TouchPhase.Began);
				}
				if (Input.GetMouseButton (0) && (isFlicking ||TouchesThisCreature(Input.mousePosition))) {
					HandleTouch (10, Camera.main.ScreenToWorldPoint (Input.mousePosition), TouchPhase.Moved);
				}
				if (Input.GetMouseButtonUp (0) &&(isFlicking || TouchesThisCreature(Input.mousePosition))) {
					HandleTouch (10, Camera.main.ScreenToWorldPoint (Input.mousePosition), TouchPhase.Ended);
				}
			}
		}
	}
	private bool TouchesThisCreature(Vector3 point)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (point);
		Physics.Raycast (ray, out hit);
		if (hit.collider) {
			if (hit.collider.transform.parent == transform) {
				return true;
			}
		}
		return false;
	}
	private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase) {
		switch (touchPhase) {
		case TouchPhase.Began:
			flickStartPosition = touchPosition;
			isFlicking = true;
			break;
		case TouchPhase.Moved:
			// TODO (maybe do nothing)
			break;
		case TouchPhase.Ended:
//			float distance = Vector3.Distance(flickStartPosition, touchPosition);
//			Debug.LogError (flickStartPosition+",,, "+ touchPosition+ "==="+distance);
//			if(distance >= flickDistance)
			{
				targetNode = targetNode.prevNode.flickTarget;
			}
			isFlicking = true;
			break;
		}
	}

	public void ResetVelocities()
	{
		agent.ResetVelocities ();
	}
	public void ChangeTarget(Node node)
	{
		targetNode = node;
		if (node.transform.parent != transform.parent) 
		{
			transform.parent = node.transform.parent;
		}
	}
	private bool IsCloseToNode()
	{
		if (Vector3.Distance (transform.position, targetNode.transform.position) <= changeTargetDistance) 
		{
			return true;
		} 
		else
		{
			return false;
		}
	}
}
