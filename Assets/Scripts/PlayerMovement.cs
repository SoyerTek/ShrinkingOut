using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Vector3 startPos;

	public bool playing = false;

	float a, c;

	void Start() {
		startPos = transform.localPosition;
	}

	public void Restart() {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity *= 0;
		transform.localPosition = startPos;
		for (int i =0; i<transform.childCount; i++) {
			Destroy(transform.GetChild(i).gameObject);
		}
	}

	private void Update() {
		if (!playing)
			return;

		Bounds b = GameObject.Find("SpawnArea").GetComponent<Renderer>().bounds;
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity *= 1 - Time.deltaTime;

		int acc = 1;

		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
			acc = 2;
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			a = 0;
			rb.AddForce(Vector3.left * acc);
		} else a += Time.deltaTime;

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			a = 0;
			rb.AddForce(Vector3.right * acc);
		} else a += Time.deltaTime;

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			c = 0;
			rb.AddForce(Vector3.forward * acc);
		} else c += Time.deltaTime;

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			c = 0;
			rb.AddForce(Vector3.back * acc);
		} else c += Time.deltaTime;

		if (b.max != b.min) {
			if (transform.position.x < b.min.x) {
				Vector3 v = rb.velocity;
				v.x = 0;
				rb.velocity = v;
				rb.AddForce(Vector3.right * 50);
			}

			if (transform.position.x > b.max.x) {
				Vector3 v = rb.velocity;
				v.x = 0;
				rb.velocity = v;
				rb.AddForce(Vector3.left * 50);
			}

			if (transform.position.z < b.min.z) {
				Vector3 v = rb.velocity;
				v.z = 0;
				rb.velocity = v;
				rb.AddForce(Vector3.forward * 50);
			}

			if (transform.position.z > b.max.z) {
				Vector3 v = rb.velocity;
				v.z = 0;
				rb.velocity = v;
				rb.AddForce(Vector3.back * 50);
			}
		}

	}
}
