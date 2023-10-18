using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How fast the ship moves?")] [SerializeField] float movementSpeed = 1f;
    [SerializeField] float xRange = 4f;
    [SerializeField] float yRange = 4f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f; 

    float horizontalThrow, verticalThrow;

    [SerializeField] GameObject[] lasers;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRoation();
        ProcessingFire(); 
       
    }

    void ProcessRoation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = verticalThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = 0f;

        float rollhDueToPosition = transform.localPosition.x * positionPitchFactor;
        float rollDueToControlThrow = horizontalThrow * controlPitchFactor;
        float roll = rollhDueToPosition + rollDueToControlThrow;
        
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 
    }
    void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        float xPos = (horizontalThrow * movementSpeed * Time.deltaTime) + transform.localPosition.x;
        float clampedXPos = Mathf.Clamp(xPos, -xRange, xRange);

        float yPos = (verticalThrow * movementSpeed * Time.deltaTime) + transform.localPosition.y;
        float clampedYPos = Mathf.Clamp(yPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessingFire()
    {
        if (Input.GetButton("Fire1"))
        {
            ActivateDeactivateLasers(true);
        }
        else
            ActivateDeactivateLasers(false); 
    }

    void ActivateDeactivateLasers(bool isActivated)
    {
        foreach (GameObject laser in lasers) {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActivated;
        }
        
    }

}
