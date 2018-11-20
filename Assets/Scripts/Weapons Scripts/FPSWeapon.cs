using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWeapon : MonoBehaviour {

	public int cartridge;
	[SerializeField] internal float damage;
	[SerializeField] internal float fireRate;
	public int bulletLeft;
	private GameObject muzzleFlash;
	[SerializeField] internal int bulletCapacity;
    [SerializeField] internal float reloadTime;

	// Use this for initialization
	void Awake () {
		muzzleFlash = transform.Find("Muzzle Flash").gameObject;
		muzzleFlash.SetActive(false);
		bulletLeft = cartridge;

	}

	private void Start() {
	}

	public void Shoot() {
		StartCoroutine(TurnOnMuzzleFlash());
	}

	IEnumerator TurnOnMuzzleFlash() {
		muzzleFlash.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		muzzleFlash.SetActive(false);
	}
}
