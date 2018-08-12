using System;
using UnityEngine;

public class Spacer : MonoBehaviour {

	public bool playing;
	public AudioClip death;

	public float speed;
	float StartSpeed;
	GameObject StartMenu;

	Vector3 StartScale;

	private void Start() {
		StartScale = transform.localScale;
		StartSpeed = speed;
		StartMenu = GameObject.Find("StartMenu");
	}

	void Update() {
		if (playing) {
			transform.localScale = Vector3.MoveTowards(transform.localScale, transform.localScale * 0.95f, speed * Time.deltaTime);
			speed += (speed * 0.1f) * Time.deltaTime;
			if (transform.localScale.x < 0.15f || transform.localScale.z < 0.07f) {
				GetComponent<AudioSource>().PlayOneShot(death, 0.5f);
				StartMenu.SetActive(true);
			}
		}
	}

	public void Restart() {
		transform.localScale = StartScale;
		speed = StartSpeed * 1.5f;
		StartSpeed = speed;
	}

	public void AddMass(float mass) {
		transform.localScale *= 1 + (0.010f * mass);
	}
}
