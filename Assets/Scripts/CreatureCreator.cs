using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureCreator : MonoBehaviour {

	[SerializeField] private float timer;
	[SerializeField] private float time = 0f;
	[SerializeField] private List<Creature> creaturePrefabs;
	private Node node;
	// Update is called once per frame
	void Awake()
	{
		node = GetComponent<Node> ();
		SpawnCreature();
	}
	void FixedUpdate () 
	{
		time += Time.fixedDeltaTime;
		if (time >= timer) 
		{
			time = 0f;
			SpawnCreature();
		}
	}
	private void SpawnCreature()
	{
        Creature creaturePrefab = creaturePrefabs[Random.Range(0,creaturePrefabs.Count)];
		Creature creature = (Creature)Instantiate(creaturePrefab, transform.position, transform.rotation)as Creature;
		creature.transform.parent = transform.parent;
		creature.targetNode = node;
	}
}
