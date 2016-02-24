using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {
    
    public LayerMask layer;

    private const string JUMP_TAG = "Jump";
    private const string TELEPORT_BUTTON_TAG = "TeleportButton";
    private const string CRUSHER_TAG = "Crusher";
    private const string LEVER_TAG = "Lever";

    private static TouchManager m_Instance;
    public static TouchManager Instance
    {
        get { return m_Instance; }        
    }
    void Awake()
    {
        m_Instance = this;
    }
    void Update()
    {
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleTouch(touch.fingerId, touch.position, touch.phase);
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTouch(100, Input.mousePosition, TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                HandleTouch(100, Input.mousePosition, TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                HandleTouch(100, Input.mousePosition, TouchPhase.Ended);
            }
        }
    }
    private void HandleTouch(int touchFingerId, Vector2 touchPosition, TouchPhase touchPhase)
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(touchPosition);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        Physics.Raycast(ray, out hit,100f, layer.value);
        if (hit.collider)
        {
            switch(hit.collider.tag)
            {
                case JUMP_TAG:
                    HandleJump(hit.collider.gameObject, touchFingerId, touchPosition, touchPhase);
                    break;
                case TELEPORT_BUTTON_TAG:
                    HandleTeleportSwitch(hit.collider.gameObject, touchFingerId, touchPosition, touchPhase);
                    break;
                case CRUSHER_TAG:
                    HandleCrusher(hit.collider.gameObject, touchFingerId, touchPosition, touchPhase);
                    break;
                case LEVER_TAG:
                    HandleLever(hit.collider.gameObject, touchFingerId, touchPosition, touchPhase);
                    break;
                default:
                    break;
            }
        }
    }
    private void HandleJump(GameObject subject, int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        Jump jump = subject.GetComponent<Jump>();
        if (jump)
        {
            jump.OnTouched(touchPhase);
        }
    }

    private void HandleTeleportSwitch(GameObject subject, int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        Button button = subject.GetComponent<Button>();
        if (button)
        {
            button.OnTouched(touchPhase);
        }
    }

    private void HandleCrusher(GameObject subject, int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        Crusher crusher = subject.GetComponent<Crusher>();
        if (crusher)
        {
            crusher.OnTouched(touchFingerId, touchPhase);
        }
       
    }

    private void HandleLever(GameObject subject, int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        Lever lever = subject.GetComponent<Lever>();
        if (lever)
        {
            lever.OnTouched(touchPhase);
        }
    }
}
