using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour {

	public Material a, b;
	public float timer;
	bool mA;
	float time = 0;

	void Update() {
		if (mA) {
			if (time > timer) {
				time = 0;
				mA = false;
				GetComponent<Renderer>().material = b;
			}
		} else if(time>timer*0.8f){
			mA = true;
			GetComponent<Renderer>().material = a;

		}
		time += Time.deltaTime;
	}
}
