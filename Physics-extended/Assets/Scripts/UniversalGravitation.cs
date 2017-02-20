using UnityEngine;

public class UniversalGravitation : MonoBehaviour {
	public int massMultiplyFactor = 100000000;

	private Rigidbody[] RigidbodyArray;
	private const float bigG = 6.673e-11f; // [m^3 s^-2 kg^-1]

	void Start () {
		RigidbodyArray = FindObjectsOfType<Rigidbody>();
	}

	void FixedUpdate () {
		CalculateGravity();
	}

	/// <summary>
	/// Sum the univeral gravity for each physic object in the scene
	/// </summary>
	void CalculateGravity() {
		/*
		 * THIRD NEWTON'S LAW:
		 * When one body exerts a force on a second body, the second body simultaneously
		 * exerts a force equal in magnitude and opposite in direction on the first body.
		 */
		foreach (Rigidbody RigidbodyA in RigidbodyArray) {

			foreach (Rigidbody RigidbodyB in RigidbodyArray) {
				if (RigidbodyA != RigidbodyB && RigidbodyA != this) {
					// Calculate gravitational force exerted on pysicsEngineA.name
					// due to the gravity of RigidbodyB
					Vector3 offset = RigidbodyA.transform.position - RigidbodyB.transform.position;
					float rSquared = Mathf.Pow(offset.magnitude, 2f);
					float gravityMagnitude = bigG * RigidbodyA.mass * RigidbodyB.mass / rSquared;
					Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

					RigidbodyA.AddForce(-gravityFeltVector * massMultiplyFactor);
				}
			}

		}
	}
}
