﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour {
    [SerializeField] private GameObject flameEffect;
    [SerializeField] private GameObject dustExplosionEffect;
    private AudioSource _audioSource;
    [SerializeField] private float hp = 200f;

    private Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
        _audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update() {
        
        if (hp <= 0) {
            Die();
        }
    }

    public void TakeDamage(float damage) {
        print("Hp: "+hp);
        _audioSource.Play();
        StartCoroutine(TurnRedAnimation());
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    IEnumerator TurnRedAnimation() {
        mat.color = Color.red;
        mat.SetColor("_EmissionColor",Color.red);
        yield return new WaitForSeconds(0.01f);
        mat.color = Color.white;
        mat.SetColor("_EmissionColor",Color.yellow);

    }

    public void Die() {
        if (gameObject.CompareTag("Weakness")) {
            GetComponent<WeaknessBreak>().BreakWeakness();
        }
        Instantiate(dustExplosionEffect, transform.position, Quaternion.identity);
        Instantiate(flameEffect, transform.position+new Vector3(0,-1,0), Quaternion.identity);    // To put the fire on the ground
        Destroy(gameObject);
    }
}