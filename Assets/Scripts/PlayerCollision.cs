using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeBeforeReloading = 1f;
    [SerializeField] ParticleSystem explosion; 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{this.name} collide with {collision.gameObject.name}");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} triggered by {other.gameObject.name}");

        this.gameObject.GetComponent<PlayerController>().enabled = false;
        if (!explosion.isPlaying)
            explosion.Play();

        Invoke("ReloadLevel", timeBeforeReloading);     
    }
    private void ReloadLevel()
    {
     
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex);
    }
}
