using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour {
	
	public Text text;
	public AudioClip pickup, dump;

	private void OnTriggerEnter(Collider coll) {
		bool b = false;
		if (coll.gameObject.CompareTag("center")) {
			for (int i = 0; i < transform.childCount; i++) {
				GameObject.Find("SpawnArea").GetComponent<Spacer>().AddMass(transform.GetChild(i).GetComponent<Rigidbody>().mass);
				Destroy(transform.GetChild(i).gameObject);
			}
			if(transform.childCount>0)
				GetComponent<AudioSource>().PlayOneShot(dump, 0.7f);
			int points = int.Parse(text.text) + transform.childCount;
			PlayerPrefs.SetInt("LastScore", points);
			if (PlayerPrefs.GetInt("HighScore") < points) {
				PlayerPrefs.SetInt("HighScore", points);
			}
			text.text = points.ToString();
		}
		if (coll.gameObject.CompareTag("element")) {
			if (coll.gameObject.transform.parent.name != "Player") {
				GetComponent<AudioSource>().PlayOneShot(pickup, 0.5f);
				coll.gameObject.transform.parent = gameObject.transform;
			}
		}
	}
	

}
