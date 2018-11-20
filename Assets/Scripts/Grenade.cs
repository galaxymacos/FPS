﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    [SerializeField] private float delay = 3f;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce = 700f;
    private GameObject FPSPlayer;
    private float countDown;
    private bool hasExploded;

    // Use this for initialization
    void Start() {
        FPSPlayer = GameObject.Find("FPS Player");
        countDown = delay;
    }

    // Update is called once per frame
    void Update() {
        if (!hasExploded) {
            countDown -= Time.deltaTime;
            if (countDown <= 0f) {
                hasExploded = true;
                Explode();
            }
        }
    }

    void Explode() {


		Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var nearbyObject in colliders) {
            if (nearbyObject.gameObject == FPSPlayer) {
                FPSPlayer.GetComponent<Target>().Die();
            }
            
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null) {
                dest.Destroy();
            }
        }
		Destroy(gameObject);
    }
}