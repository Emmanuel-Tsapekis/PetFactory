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
        OnLeverSwitch();
    }

    public void OnTouched(TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                isLeft = !isLeft;
                OnLeverSwitch();
                break;
            case TouchPhase.Moved:
                break;
            case TouchPhase.Ended:
                break;
        }
    }

    private void OnLeverSwitch()
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
