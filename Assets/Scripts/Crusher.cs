using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crusher : MonoBehaviour {

    [SerializeField]
    private GameObject blood;
    [SerializeField]
    private float yUp;
    [SerializeField]
    private float yDown;
    [SerializeField]
    private float speedDown;
    [SerializeField]
    private float speedUp;

    private float velocity;

    private bool crushing = true;

    private List<int> fingersTouching = new List<int>();
    void Start()
    {
        velocity = speedDown;
    }

	void Update()
	{
        if (transform.position.y >= yUp)
        {
            if (crushing)
            {
                velocity = speedDown;
            }
            else
            {
                velocity = 0;
            }
        }
        else if (transform.position.y <= yDown)
        {
            velocity = speedUp;
        }
        transform.position += new Vector3(0, velocity, 0);
        if (fingersTouching.Count > 0 &&  FingersLifted())
        {
            OnTouched(100, TouchPhase.Ended);
        }
    }

    private bool FingersLifted()
    {
        int fingersLifted = 0;
        List<int> fingersToRemoveFromList = new List<int>();
        foreach (int finger in fingersTouching)
        {
            if (finger == 100)
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, 100f, TouchManager.Instance.layer.value);
                if (!hit.collider || hit.collider.transform != transform || Input.GetMouseButtonUp(0))
                {
                    ++fingersLifted;
                    fingersToRemoveFromList.Add(finger);
                }
            }
            else
            {
                Touch touch = Input.GetTouch(finger);
                Vector3 point = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Physics.Raycast(ray, out hit, 100f, TouchManager.Instance.layer.value);
                if(!hit.collider || hit.collider.transform != transform || touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    ++fingersLifted;
                    fingersToRemoveFromList.Add(finger);
                }
            }
        }
        if (fingersLifted == fingersTouching.Count)
        {
            fingersTouching = new List<int>();
            return true;
        }
        foreach(int finger in fingersToRemoveFromList)
        {
            fingersTouching.Remove(finger);
        }
        return false;
    }

    public void OnTouched(int touchFingerId, TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                crushing = false;
                fingersTouching.Add(touchFingerId);
                break;
            case TouchPhase.Moved:
                break;
            case TouchPhase.Ended:
                crushing = true;
                break;
        }
    }
    
	void OnTriggerEnter(Collider other)
    {
		Creature creature = other.GetComponent<Creature>();
		if (creature) {
			blood.SetActive(true);
			Destroy (creature.gameObject);
		}
	}

    void OnTriggerExit(Collider other)
    {


    }
    void OnCollisionEnter(Collision other)
    {
        //needs to exist for collision for reasons beyond me
    }
}
