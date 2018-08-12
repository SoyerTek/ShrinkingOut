using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {

	float t;

	GameObject Player, SpawnArea, Manager;

	private void OnEnable() {
		t = 0;
		Player = GameObject.Find("Player");
		SpawnArea= GameObject.Find("SpawnArea");
		Manager = GameObject.Find("Manager");

		Player.GetComponent<PlayerMovement>().playing = false;
		SpawnArea.GetComponent<Spacer>().playing = false;
		Manager.GetComponent<Spawner>().playing = false;
		GameObject.Find("CurrentScore").GetComponent<Text>().text = "0";
	}

	void Update() {
		if (Input.anyKey && t > 1) {
			Player.GetComponent<PlayerMovement>().playing = true;
			SpawnArea.GetComponent<Spacer>().playing = true;
			Manager.GetComponent<Spawner>().playing = true;
			Player.GetComponent<PlayerMovement>().Restart();
			SpawnArea.GetComponent<Spacer>().Restart();

			gameObject.SetActive(false);
		}
		t += Time.deltaTime;
	}
}
