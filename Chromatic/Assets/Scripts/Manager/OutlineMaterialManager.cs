using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMaterialManager : MonoBehaviour
{
    public Material materialToAdd; // Reference to the material to add

    public GameObject[] targetObjects; // Array of GameObjects to manage materials for

    private void Start()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            Renderer rendererComponent = targetObject.GetComponent<Renderer>();
            if (rendererComponent != null)
            {
                // Do any initialization or setup for each target object here
            }
        }
    }

    public void AddMaterialToAll()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            Renderer rendererComponent = targetObject.GetComponent<Renderer>();
            if (rendererComponent != null)
            {
                AddMaterialToRenderer(rendererComponent);
            }
        }
    }

    public void RemoveMaterialFromAll()
    {
        foreach (GameObject targetObject in targetObjects)
        {
            Renderer rendererComponent = targetObject.GetComponent<Renderer>();
            if (rendererComponent != null)
            {
                RemoveMaterialFromRenderer(rendererComponent);
            }
        }
    }

    private void AddMaterialToRenderer(Renderer renderer)
    {
        Material[] materials = renderer.materials; // Get the array of materials
        Material[] newMaterials = new Material[materials.Length + 1]; // Create a new array with one additional slot
        materials.CopyTo(newMaterials, 0); // Copy the existing materials to the new array
        newMaterials[newMaterials.Length - 1] = materialToAdd; // Add the new material to the last slot
        renderer.materials = newMaterials; // Assign the new array back to the Renderer
    }

    private void RemoveMaterialFromRenderer(Renderer renderer)
    {
        Material[] materials = renderer.materials; // Get the array of materials
        if (materials.Length > 0)
        {
            Material[] newMaterials = new Material[materials.Length - 1]; // Create a new array with one less slot
            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = materials[i]; // Copy the existing materials except the last one
            }
            renderer.materials = newMaterials; // Assign the new array back to the Renderer
        }
    }
}

