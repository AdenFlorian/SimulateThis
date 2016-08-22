using System;
using UnityEngine;

public class Agent : MonoBehaviour {

	Energy Energy = new Energy();

	void SetColor(Color newColor) {
		GetComponent<Renderer>().material.color = newColor;
	}

	public void AddEnergy(float energy) {
		Energy.Level += energy;

		UpdateColor();
	}

	private void UpdateColor() {
		if (Energy.Level < 5) {
			SetColor(Color.gray);
		} else if (Energy.Level < 25) {
			SetColor(Color.blue);
		} else if (Energy.Level < 50) {
			SetColor(Color.green);
		} else if (Energy.Level < 90) {
			SetColor(Color.yellow);
		} else {
			SetColor(Color.red);
		}
	}

	public float GetEnergyLevel() {
		return Energy.Level;
	}
}
