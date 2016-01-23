using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

	public Node targetNode;
	[SerializeField] private float changeTargetDistance;
	private SteeringAgent agent;
	public bool hault { get; private set;}
	public bool teleported = false;
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
				else
				{
					hault = true;
				}
			}
			if(agent)
			{
				agent.steeringUpdate();
			}
		}
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
