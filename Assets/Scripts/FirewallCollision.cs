using UnityEngine;
using System.Collections;

public class FirewallCollision : MonoBehaviour {

	void OnParticleCollision(GameObject gameObj) {
		Creature creature = gameObj.GetComponent<Creature>();
		if (creature) {
			OnCreatureKill(creature);
		}
	}
	void OnCollisionEnter(Collision gameObj) {
		Creature creature = gameObj.gameObject.GetComponent<Creature>();
		if (creature) {
			OnCreatureKill(creature);
		}
	}
	void OnTriggerEnter(Collider gameObj) {
		Creature creature = gameObj.GetComponent<Creature>();
		if (creature) {
			OnCreatureKill(creature);
		}
	}
	void OnCollisionEnter(Collider gameObj) {
		Creature creature = gameObj.GetComponent<Creature>();
		if (creature) {
			OnCreatureKill(creature);
		}
	}
	void OnTriggerEnter(Collision gameObj) {
		Creature creature = gameObj.gameObject.GetComponent<Creature>();
		if (creature) {
			OnCreatureKill(creature);
		}
	}
	private void OnCreatureKill(Creature creature)
	{
		Destroy (creature.gameObject);
	}
}
