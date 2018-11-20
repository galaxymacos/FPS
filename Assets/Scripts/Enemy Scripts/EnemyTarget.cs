using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour {
    [SerializeField] private GameObject flameEffect;
    [SerializeField] private GameObject dustExplosionEffect;

    [SerializeField] private float hp = 200f;
    
    // Update is called once per frame
    void Update() {
        if (hp <= 0) {
            Die();
        }
    }

    public void TakeDamage(float damage) {
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    public void Die() {
        Instantiate(dustExplosionEffect, transform.position, Quaternion.identity);
        Instantiate(flameEffect, transform.position+new Vector3(0,-1,0), Quaternion.identity);    // To put the fire on the ground
        Destroy(gameObject);
    }
}