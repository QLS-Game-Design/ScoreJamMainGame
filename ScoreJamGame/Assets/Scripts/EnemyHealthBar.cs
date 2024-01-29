using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{

    [SerializeField] private Slider slider;

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private Camera mainCamera;

    private void Start()
    {
        // Find the main camera dynamically
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found in the scene.");
        }
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }


    void Update()
    {
        // Only update the position and rotation if the camera is found
        if (mainCamera != null && target != null)
        {
            transform.rotation = mainCamera.transform.rotation;
            transform.position = target.position + offset;
        }
    }
}