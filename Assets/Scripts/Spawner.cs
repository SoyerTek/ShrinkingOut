using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public int spawnNum;
	public float delay;

	public bool playing = false;

	List<GameObject> spawned;

	Transform parent;

	Bounds area;

	float timer = 0;

	void Start() {
		spawned = new List<GameObject>();
		parent = GameObject.Find("Elements").transform;
		area = GameObject.Find("SpawnArea").GetComponent<Renderer>().bounds;
	}

	public void Restart() {
		for (int i = 0; i < spawned.Count; i++) {
			Destroy(spawned[i]);
		}
	}

	void Update() {
		if (!playing)
			return;

		area = GameObject.Find("SpawnArea").GetComponent<Renderer>().bounds;

		for (int i = 0; i < spawned.Count; i++) {
			GameObject go = spawned[i];
			if (go == null) {
				spawned.Remove(go);
				continue;
			}
			if (go.transform.position.x > area.max.x + 0.5f || go.transform.position.x < area.min.x - 0.5f
			|| go.transform.position.z > area.max.z + 0.5f || go.transform.position.z < area.min.z - 0.5f) {
				if (go.transform.parent.name != "Player") {
					Destroy(go);
					spawned.Remove(go);
					timer = 0;
				}
			}
		}

		if (timer > delay && spawned.Count < spawnNum) {
			timer = 0;
			spawned.Add(Instantiate(prefab, randomPos(), Quaternion.identity, parent));
			spawned[spawned.Count - 1].tag = "element";
			float m = Random.Range(1f, 5f);
			spawned[spawned.Count - 1].GetComponent<Rigidbody>().mass = m;
			spawned[spawned.Count - 1].transform.localScale = new Vector3(0.3f + m / 10, 0.3f + m / 10, 0.3f + m / 10);
		}
		timer += Time.deltaTime;
	}

	Vector3 randomPos() {
		return new Vector3(Random.Range(area.min.x * 0.85f, area.max.x * 0.85f), 0.5f, Random.Range(area.min.z * 0.85f, area.max.z * 0.85f));
	}
}
