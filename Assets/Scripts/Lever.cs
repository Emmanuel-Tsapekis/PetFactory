using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{

    [SerializeField]
    private Node fromNode;
    [SerializeField]
    private Node leftNode;
    [SerializeField]
    private Node rightNode;
    [SerializeField]
    private float leftRotation;
    [SerializeField]
    private float rightRotation;
    private bool wasTouched;
    [SerializeField]
    private bool isLeft;
    [SerializeField]
    private Transform rotationPivot;

    [SerializeField]
    private AudioClip[] audioClip;
    private AudioSource source;

    void Awake()
    {
        source = GameObject.FindObjectOfType<AudioSource>();
        OnLeverSwitch(isLeft);
    }
    // Update is called once per frame
    void Update()
    {
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            if (wasTouched || TouchesThisUIItem(touch.position))
            {
                HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);
            }
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0) && (wasTouched || TouchesThisUIItem(Input.mousePosition)))
            {
                HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Began);
            }
            if (Input.GetMouseButton(0) && (wasTouched || TouchesThisUIItem(Input.mousePosition)))
            {
                HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0) && (wasTouched || TouchesThisUIItem(Input.mousePosition)))
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
                return true;
            }
        }
        return false;
    }
    private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                wasTouched = true;
                break;
            case TouchPhase.Moved:
                // TODO (maybe do nothing)
                break;
            case TouchPhase.Ended:
                isLeft = !isLeft;
                OnLeverSwitch(isLeft);
                wasTouched = false;
                break;
        }
    }
    private void OnLeverSwitch(bool isLeft)
    {
        if (isLeft)
        {
            rotationPivot.eulerAngles = new Vector3(-60f, 0, 0);
            fromNode.nextNode = leftNode;
            playSound(0);
        }
        else
        {
            rotationPivot.eulerAngles = new Vector3(-120f, 0, 0);
            fromNode.nextNode = rightNode;
            playSound(1);
        }
    }

    public void playSound(int i) {
        source.clip = audioClip[i];
        source.Play();
    }
}
