using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delayTime = 1f;

    [SerializeField] private ParticleSystem _particleSystem;
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "Collied" + other.gameObject.name);
        ReloadLevelSequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} ** Triggered by ** {other.gameObject.name}");
    }

    void ReloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    void ReloadLevelSequence()
    {
        _particleSystem.Play();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel" , delayTime);
    }
}
