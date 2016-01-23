using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spline : MonoBehaviour {

	public int ID;
	private List<Node> nodes = new List<Node>();

	public void Awake()
	{
		ID = (int) transform.name [transform.name.Length - 2];
	}
}
