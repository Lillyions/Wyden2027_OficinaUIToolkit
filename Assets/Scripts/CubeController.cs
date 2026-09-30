using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;

    [SerializeField] private bool isRotating = true;

    [Header("Color Settings")]
    public Material[] colorMaterials;


    private Renderer cubeRenderer;
    private int currentColorIndex = 1;


    void Awake()
    {
        cubeRenderer = GetComponent<Renderer>();
        currentColorIndex = 0;

        if (colorMaterials != null && colorMaterials.Length > 0)
        {
            cubeRenderer.sharedMaterial = colorMaterials[currentColorIndex];
        }
    }

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }

    public void ChangeColor()
    {

        if (colorMaterials == null || colorMaterials.Length == 0)
        {
            Debug.LogError("No color materials assigned.");
            return;
        }

        currentColorIndex = (currentColorIndex + 1) % colorMaterials.Length;
        cubeRenderer.sharedMaterial = colorMaterials[currentColorIndex];
    }
}
