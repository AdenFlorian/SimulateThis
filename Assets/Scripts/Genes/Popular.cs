using UnityEngine;
using System.Collections;

public class Popular : Gene {

	bool flag = true;
	
	void Awake() {
		GetComponent<Agent>().AddEnergy(100);
	}

	void Start() {
		transform.localScale += new Vector3(1, 1, 1);
		var light = gameObject.AddComponent<Light>();
		light.color = new Color(1f, 0.3f, 0.5f);
		light.range *= 23;
		light.intensity *= 1.4f;
	}
	
	void FixedUpdate() {
		if (flag) {
			AttractNearbyAgents();
			flag = false;
		} else {
			flag = true;
		}
	}

	private void AttractNearbyAgents() {
		Collider[] results = new Collider[50];
		var numberOfResults = Physics.OverlapSphereNonAlloc(transform.position, 50f, results);
		for (int i = 0; i < numberOfResults; i++) {
			var rb = results[i].GetComponent<Rigidbody>();
			if (rb != null) {
				rb.AddForce((transform.position - results[i].transform.position).normalized * 30f);
			}
		}
	}
}
