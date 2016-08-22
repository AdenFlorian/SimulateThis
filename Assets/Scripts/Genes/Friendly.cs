using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Friendly : Gene {
	new Rigidbody rigidbody;

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		GetComponent<Agent>().AddEnergy(40);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var nearestNeighbor = FindNearestNeighbor();
		var multi = 7f;
		if (nearestNeighbor == null) {
			return;
		}
		var force = nearestNeighbor.transform.position - transform.position;
		force.Normalize();
		force *= multi;
		rigidbody.AddForce(force);
	}

	GameObject FindNearestNeighbor() {
		Collider[] results = new Collider[7];
		var numberOfResults = Physics.OverlapSphereNonAlloc(transform.position, 10f, results);
		float smallestDistance = float.MaxValue;
		GameObject nearestNeighbor = null;
		for (int i = 0; i < numberOfResults; i++) {
			var distance = Vector3.Distance(results[i].transform.position, transform.position);
			if (distance == 0) {
				continue;
			}
			if (distance < smallestDistance) {
				smallestDistance = distance;
				nearestNeighbor = results[i].gameObject;
			}
		}
		return nearestNeighbor;
	}
}
