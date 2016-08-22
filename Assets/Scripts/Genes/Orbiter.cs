using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Orbiter : Gene {

	public float ForceMultiplier = 11.5f;
	public float DesiredDistance = 7f;
	new Rigidbody rigidbody;

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		GetComponent<Agent>().AddEnergy(47);
	}

	// Use this for initialization
	void Start() {
		transform.localScale += new Vector3(1, 0, 0);
	}

	// Update is called once per frame
	void FixedUpdate() {
		var nearestNeighbor = FindNearestYellowNeighbor();
		if (nearestNeighbor == null) {
			return;
		}
		ApplyDistanceKeepingForce(nearestNeighbor);
	}

	GameObject FindNearestYellowNeighbor() {
		Collider[] results = new Collider[7];
		var numberOfResults = Physics.OverlapSphereNonAlloc(transform.position, 30f, results);
		float smallestDistance = float.MaxValue;
		GameObject nearestNeighbor = null;
		for (int i = 0; i < numberOfResults; i++) {
			var distance = Vector3.Distance(results[i].transform.position, transform.position);
			if (distance == 0) continue;
			var agent = results[i].GetComponent<Agent>();
			if (agent == null) continue;
			if (IsInDesiredEnergyLevelRange(agent) == false) continue;
			if (distance < smallestDistance) {
				smallestDistance = distance;
				nearestNeighbor = results[i].gameObject;
			}
		}
		return nearestNeighbor;
	}

	bool IsInDesiredEnergyLevelRange(Agent agent) {
		var energyLevel = agent.GetEnergyLevel();
		return energyLevel < 90 && energyLevel > 75;
	}

	void ApplyDistanceKeepingForce(GameObject nearestNeighbor) {
		var direction = CloserOrFurther(nearestNeighbor);
		
		var force = nearestNeighbor.transform.position - transform.position;
		force.Normalize();
		force = force * ForceMultiplier;
		switch (direction) {
			case Direction.Closer:
				rigidbody.AddForce(force);
				break;
			case Direction.Further:
				rigidbody.AddForce(-force);
				break;
		}
	}

	private Direction CloserOrFurther(GameObject target) {
		var distance = Vector3.Distance(transform.position, target.transform.position);
		if (distance > DesiredDistance) {
			return Direction.Closer;
		}
		return Direction.Further;
	}

	enum Direction {
		Closer,
		Further
	}
}
