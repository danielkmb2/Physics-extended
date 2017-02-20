using UnityEngine;

public class MagnusEffect : MonoBehaviour {

	public float magnusFactor = 1f;

	private Rigidbody rigidBody;
	private SphereCollider scollider;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
		scollider = GetComponent<SphereCollider>();
	}

	void FixedUpdate() {

		//TODO: aproximate for non-espherical objects

		Vector3 crossProduct = Vector3.Cross(rigidBody.angularVelocity, rigidBody.velocity);
		float p = Mathf.Pow(Mathf.PI, 2) * Mathf.Pow(scollider.radius, 3) * rigidBody.drag;
		rigidBody.AddForce(magnusFactor * p * crossProduct * Time.fixedDeltaTime);
	}
}
