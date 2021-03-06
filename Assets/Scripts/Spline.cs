﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spline : MonoBehaviour {

	public int ID;
	private List<Node> nodes = new List<Node>();
	public Node firstNode;
	public Node lastNode;
	[SerializeField] private List<Node> nextSplineStarts;
	[SerializeField] private int nextSplineIndex;

	public void Awake()
	{
		string number = transform.name.Replace("Spline (","").Replace(")","");
		ID =  int.Parse(number);
		nodes.AddRange(GetComponentsInChildren<Node> ());
		foreach (Node node in nodes) 
		{
			foreach(Node otherNode in nodes)
			{
				if(node.ID == 1)
				{
					firstNode = node;
				}
				else if(node.ID == nodes.Count)
				{
					lastNode = node;
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
