using UnityEngine;

public class AgentSpawner : MonoBehaviour {

    public Agent AgentPrefab;
    public int numberOfSpawns = 1000;
    public float MaxPosition = 100;

    void Start() {
		SpawnAgents();
	}

	void SpawnAgents() {
		for (int i = 0; i < numberOfSpawns; i++) {
			var newAgent = Instantiate(AgentPrefab.gameObject);
			SetRandomPosition(newAgent);
			AddRandomGeneToGameObject(newAgent);
		}
	}

	void SetRandomPosition(GameObject newAgent) {
		var newPosition = RandomEx.Vector3(-MaxPosition, MaxPosition);
		newAgent.transform.position = newPosition;
	}

	static void AddRandomGeneToGameObject(GameObject gameObject) {
		if (Random.Range(0, 2) == 0) {
			gameObject.AddComponent<Wiggle>();
		}
		if (Random.Range(0, 3) == 0) {
			gameObject.AddComponent<Friendly>();
		}
		if (Random.Range(0, 13) == 0) {
			gameObject.AddComponent<Orbiter>();
		}
		if (Random.Range(0, 45) == 0) {
			gameObject.AddComponent<Popular>();
		}
	}
}
