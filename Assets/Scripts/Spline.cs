using UnityEngine;
using System.Collections;

public class Spline : MonoBehaviour {

	public int ID;

	public void Awake()
	{
		ID = (int) transform.name [transform.name.Length - 2];
	}
}
