using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour {

	public Node targetNode;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void ChangeTarget(Node node)
	{
		targetNode = node;
	}
}
