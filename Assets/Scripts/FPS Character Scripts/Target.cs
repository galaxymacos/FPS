using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour {

	[SerializeField] internal float maxHp = 200f;
	internal float currentHp;

	[SerializeField] private TextMeshProUGUI hpBar;

	[SerializeField] private GameObject GameoverScreen;

	private AudioSource _audioSource;
	[SerializeField] private AudioClip DeathSound;

	[SerializeField] private float DieFallOverSpeed = 200f;
    [SerializeField] private SpawnPoint spawnPoint;
	private bool isDead;
	
	// Use this for initialization
	void Start () {
		currentHp = maxHp;
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {

			if (transform.rotation.eulerAngles.z < 90f) {
				transform.Rotate(new Vector3(0,0,DieFallOverSpeed*Time.deltaTime));
			}
		}
		if (currentHp <= 0) {
			
			Die();
			
		}
	}

	public void TakeDamage(float damage) {
		currentHp -= damage;
		print("HP: " + currentHp);
		hpBar.text = "HP: " + currentHp;
	}

	public void Die() {
        hpBar.text = "HP:0";
		isDead = true;
		if (gameObject.name == "FPS Player") {
			_audioSource.Play();
            spawnPoint.enabled = false;
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (var enemy in enemies) {
				Destroy(enemy);
			}
			
			foreach (var currentScript in GetComponentsInChildren<MonoBehaviour>()) {
                if (currentScript.GetType().Name != "Target") {
                    currentScript.enabled = false;
                }
            }
			GetComponent<CharacterController>().enabled = false;
			GetComponent<Animator>().enabled = false;
			StartCoroutine(ShowGameoverScreen());
		}
		else {
			Destroy(gameObject);
		}
	}

	IEnumerator ShowGameoverScreen() {
		yield return new WaitForSeconds(3);
		
		
		GetComponent<CapsuleCollider>().enabled = true;
		Cursor.lockState = CursorLockMode.None;

		GameoverScreen.SetActive(true);
		
	}
}
