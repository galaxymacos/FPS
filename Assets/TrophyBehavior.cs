using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyBehavior : MonoBehaviour {

	[SerializeField] private float rotateSpeed = 100f;

	[SerializeField] private float liveTime = 8f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,rotateSpeed*Time.deltaTime,0));
		liveTime -= Time.deltaTime;
		if (liveTime <= 0f) {
			Destroy(gameObject);
		}
	}
	
	
}
