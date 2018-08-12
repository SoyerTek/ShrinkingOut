using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour {

	private void OnEnable() {
		GetComponent<Text>().text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0) + " LastScore:" + PlayerPrefs.GetInt("LastScore", 0);
	}
}
