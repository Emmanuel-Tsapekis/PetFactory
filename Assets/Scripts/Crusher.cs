using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {

	[SerializeField] private GameObject blood;
	[SerializeField] private float yUp;
	[SerializeField] private float yDown;
	void Update()
	{
		if (transform.position.y >= yUp) {

		}
	}
	void OnTriggerEnter(Collider other) {
		Creature creature = other.GetComponent<Creature>();
		if (creature) {
			blood.SetActive(true);
			Destroy (creature.gameObject);
		}
	}
}
