using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("Ship Speed")][SerializeField] private float controlSpeed = 30f;
    [Tooltip("X coordinate Range")][SerializeField] private float xposRange = 10f;
    [Tooltip("Y coordinate Range")][SerializeField] private float yposRange = 4.8f;
    //[SerializeField] private float zControl = 5f;

    [Tooltip("Ship Lasers")][SerializeField] GameObject[] lasers;
    
    [Tooltip("Position Y ")][SerializeField] private float pitchPosition = -2f;
    [Tooltip("Rotation Y ")][SerializeField] private float controllPosition = -10f;
    [Tooltip("Position X")][SerializeField] private float yawPosition = 1f;
    [Tooltip("Rotation Z")][SerializeField] private float controllPositionZ = -31f;
    
    private float vertical, horizontal , forwardd ;

    
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    public void ProcessTranslation()
    {
       
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            
            float xOffset = horizontal * Time.deltaTime * controlSpeed;
            float xPoss = transform.localPosition.x + xOffset;
            float clambXposs = Mathf.Clamp(xPoss, -xposRange, xposRange);

            float yOffset = vertical * Time.deltaTime * controlSpeed;
            float yPoss = transform.localPosition.y + yOffset;
            float clambYposs = Mathf.Clamp(yPoss, -yposRange, yposRange);

            //float zOffset = vertical * Time.deltaTime * controlSpeed;
            //float zPoss = transform.localPosition.z + zOffset;

            transform.localPosition = new Vector3(clambXposs, clambYposs,transform.localPosition.z);
        
    }

    void ProcessRotation()
    {
        float positionY = pitchPosition * transform.localPosition.y;
        float controllY = controllPosition * vertical;
        float pitch = positionY + controllY;

        float yaw = yawPosition * transform.localPosition.x;
        float roll = controllPositionZ * horizontal;
        transform.localRotation = Quaternion.Euler(pitch , yaw ,roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Basıldı");
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }
    void SetActiveLasers(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            lasers[0].SetActive(isActive);
            lasers[1].SetActive(isActive);
            lasers[2].SetActive(isActive);
            var emission = GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
            Debug.Log(isActive);
        }
    }
}
    
