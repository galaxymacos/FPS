using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInformation : MonoBehaviour {
    private int weaknessNumber = 1; // TODO change back to 5

    [SerializeField] private GameObject explosionPoint;

    [SerializeField] private float explosionForce = 1000f;

    [SerializeField] private float explosionRadius = 100f;
    [SerializeField] internal AudioSource backgroundMusic;
    [SerializeField] private AudioClip victoryMusic;
    [SerializeField] private AudioClip victoryJingle;
    [SerializeField] private SpawnPoint SpawnPoint;
    [SerializeField] private GameObject VictoryBoard;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void BreakWeakness() {
        weaknessNumber -= 1;
        if (weaknessNumber == 0) {
            BossExplosion();
        }
    }

    private void BossExplosion() {

        StartCoroutine(PlayVictoryMusic());
       
        DisableAllAnimationAndScriptWhenGameOver();    // TODO change name
        
        
        GetComponent<Animator>().enabled = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddExplosionForce(explosionForce, explosionPoint.transform.position, explosionRadius);                
            }
        }

        StartCoroutine(LoadVictoryBoard());
    }

    IEnumerator PlayVictoryMusic() {
        // replace the gloomy background music to a happy one
        if (backgroundMusic.clip != victoryMusic) {
            backgroundMusic.clip = victoryMusic;
        }
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        
        backgroundMusic.loop = false;
        backgroundMusic.Play();
    }

    IEnumerator LoadVictoryBoard() {
        yield return new WaitForSeconds(3f);
        VictoryBoard.SetActive(true);
        
    }
    
    private void DisableAllAnimationAndScriptWhenGameOver() {
        SpawnPoint.enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies) {
            Destroy(enemy);
        }

//        foreach (var currentScript in FPSPlayer.GetComponentsInChildren<MonoBehaviour>()) {
//            if (currentScript.GetType().Name != "Target") {
//                currentScript.enabled = false;
//            }
//        }

//        GetComponent<CharacterController>().enabled = false;
//        GetComponent<Animator>().enabled = false;
    }
}