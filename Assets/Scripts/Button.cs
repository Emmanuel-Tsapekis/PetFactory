using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField] private Transform buttonToMove;
	[SerializeField] private float yValueUp;
	[SerializeField] private float yValueDown;
    [SerializeField]
    private AudioClip[] audioClip;
    private AudioSource source;

    public bool isPressed = false;
    void Awake()
    {
        //source = GameObject.FindObjectOfType<AudioSource>();
    }
	public void OnTouched(TouchPhase touchPhase)
	{
		switch (touchPhase)
		{
		case TouchPhase.Began:
            Pressed(true);
			break;
		case TouchPhase.Moved:
			break;
		case TouchPhase.Ended:
			break;
		}
	}
	public void Pressed(bool pressed)
	{
        isPressed = pressed;
		float yValue = (pressed) ? yValueDown : yValueUp;
       
        if (buttonToMove)
		{
            
            buttonToMove.position = new Vector3(buttonToMove.position.x, yValue, buttonToMove.position.z);
		}
	}

    public void playSound(int clip)
    {
        //source.clip = audioClip[clip];
        source.Play();
    }
}
