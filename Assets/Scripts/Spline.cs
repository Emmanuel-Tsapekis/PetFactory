using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spline : MonoBehaviour {

	public int ID;
	private List<Node> nodes = new List<Node>();

	public void Awake()
	{
		string number = transform.name [transform.name.Length - 2].ToString ();
		ID =  int.Parse(number);
		nodes.AddRange(GetComponentsInChildren<Node> ());
		foreach (Node node in nodes) 
		{
			foreach(Node otherNode in nodes)
			{
				if(node.ID == 1)
				{
					node.prevNode = null;
				}
				else if(node.ID == nodes.Count)
				{
					node.nextNode = null;
				}
				if(node == otherNode)
				{
					continue;
				}
				if(otherNode.ID - node.ID == 1)
				{
					node.nextNode = otherNode;
					otherNode.prevNode = node;
				}

			}
		}
	}
}
