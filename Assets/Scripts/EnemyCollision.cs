using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] int hitPoints = 5;
    [SerializeField] GameObject hitParticle;

    Transform parent;
    Rigidbody spaceShipRB; 
    ScoreBoard playerScore; 
    private void Start()
    {
        AddRigidBody();
        playerScore = FindObjectOfType<ScoreBoard>();
    }

    private void AddRigidBody()
    {
        spaceShipRB = gameObject.AddComponent<Rigidbody>();
        spaceShipRB.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
            KillEnemy(); 
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
    private void ProcessHit()
    {
        playerScore.UpdateScore();
        if (hitPoints > 0)
        {
            GameObject hitVFX = Instantiate(hitParticle, transform.position, Quaternion.identity);
            parent = GameObject.FindWithTag("RunTimeSpawn").transform; 
            hitVFX.transform.parent = parent;
            hitPoints -= 1;
        }
    }
}
