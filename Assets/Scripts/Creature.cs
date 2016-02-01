using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

	public Node targetNode;
	public Node jumpNode;
	[SerializeField] private float changeTargetDistance;
	[SerializeField] private LayerMask creatureLayer;
	[SerializeField] private float flickDistance;
	private SteeringAgent agent;
	public bool hault { get; private set;}
	public bool teleported = false;
	public bool isCute;
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
					targetNode.TeleportEnter(this);
				}
			}
			if(agent)
			{
				agent.steeringUpdate();
			}
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
		if (node.ISLASTNODE) {
			GameManager.Instance.ScorePoint(this,node.ISCUTE);
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
