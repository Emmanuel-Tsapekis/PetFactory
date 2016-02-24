using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
	[SerializeField]
	private Node node;
	private Creature jumpingCreature;
	
    public void OnTouched(TouchPhase touchPhase)
    {       
        switch (touchPhase)
        {
            case TouchPhase.Began:
                if (jumpingCreature)
                {
                    jumpingCreature.targetNode = node;
                }
                break;
            case TouchPhase.Moved:
                break;
            case TouchPhase.Ended:
                break;
        }
    }

	void OnTriggerExit(Collider other)
    {
		Creature creature = other.GetComponent<Creature>();
		if (creature) {
			creature.jumpNode = null;
            if(jumpingCreature == creature)
            {
                jumpingCreature = null;
            }
		}
	}
	void OnTriggerEnter(Collider other)
    {
		Creature creature = other.GetComponent<Creature>();
		if (creature) {
			jumpingCreature = creature;
			creature.jumpNode = node;
		}
	}
}
