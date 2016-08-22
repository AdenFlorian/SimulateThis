using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Wiggle : Gene {

    public float MaxForce = 3;

    new Rigidbody rigidbody;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
		GetComponent<Agent>().AddEnergy(20);
    }

    void FixedUpdate() {
        rigidbody.AddForce(RandomEx.Vector3(-MaxForce, MaxForce));
    }
}
