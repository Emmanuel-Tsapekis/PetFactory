using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField] private Transform buttonToMove;
	[SerializeField] private float yValueUp;
	[SerializeField] private float yValueDown;

	public bool isPressed = false;
	void Update()
	{
		// Handle native touch events
		foreach (Touch touch in Input.touches)
		{
			if (TouchesThisUIItem(touch.position))
			{
				HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);
			}
		}
		
		// Simulate touch events from mouse events
		if (Input.touchCount == 0)
		{
			if (Input.GetMouseButtonDown(0) && (TouchesThisUIItem(Input.mousePosition)))
			{
				HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Began);
			}
			if (Input.GetMouseButton(0) && (TouchesThisUIItem(Input.mousePosition)))
			{
				HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Moved);
			}
			if (Input.GetMouseButtonUp(0) && (TouchesThisUIItem(Input.mousePosition)))
			{
				HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Ended);
			}
		}
	}
	private bool TouchesThisUIItem(Vector3 point)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(point);
		Physics.Raycast(ray, out hit);
		if (hit.collider)
		{
			if (hit.collider.transform == transform)
			{
				isPressed = true;//if we want to redragand press
				if(buttonToMove)
				{
					buttonToMove.position = new Vector3(buttonToMove.position.x, yValueDown, buttonToMove.position.z);
				}
				return true;
			}
		}
		isPressed = false;
		if (buttonToMove)
		{
			buttonToMove.position = new Vector3(buttonToMove.position.x, yValueDown, buttonToMove.position.z);
		}
		return false;
	}
	private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
	{
		switch (touchPhase)
		{
		case TouchPhase.Began:
//			isPressed = true;//not ifwe want to redrag and press
			break;
		case TouchPhase.Moved:
			break;
		case TouchPhase.Ended:
//			isPressed = false;
			break;
		}
	}
}
