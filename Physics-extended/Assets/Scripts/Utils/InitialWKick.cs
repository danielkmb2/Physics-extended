using UnityEngine;

public class InitialWKick : MonoBehaviour {

	public Vector3 initialVelocity;
	public Vector3 initialW;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();

		rigidBody.velocity = initialVelocity;
		rigidBody.angularVelocity = initialW;
	}
}
