using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInformation : MonoBehaviour {
	private int weaknessNumber = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BreakWeakness() {
		weaknessNumber -= 1;
		if (weaknessNumber == 0) {
			// Game over
		}
	}
}
