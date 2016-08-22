using UnityEngine;
using Random = UnityEngine.Random;

class RandomEx {
    public static Vector3 Vector3(float min, float max) {
        var vector = new Vector3();
        vector.x = Random.Range(min, max);
        vector.y = Random.Range(min, max);
        vector.z = Random.Range(min, max);
        return vector;
    }

	public static bool Bool() {
		return Random.Range(0, 2) == 1 ? true : false;
	}
}
