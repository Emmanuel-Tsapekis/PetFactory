using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {
	
	public List<Node> neighbours;
	public Node prevNode;
	public Node nextNode;

	public int cluster;
	// Use this for initialization
	void Awake () {
		if(neighbours == null)
			neighbours = new List<Node> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}