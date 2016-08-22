using System;

class Energy {
	const float MaxEnergy = 100f;

	float _level = 0f;

	public float Level {
		get {
			return _level;
		}
		set {
			_level = Math.Max(0, Math.Min(MaxEnergy, value));
		}
	}
}
