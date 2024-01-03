using System.Collections.Generic;
using UnityEngine;
using iNucom.Ghost;

/// <summary>
/// Controls the visibility of lights based on the grabbed status of an object.
/// </summary>
public class GrabLights : MonoBehaviour
{
    /// <summary>
    /// The list of lights to be controlled.
    /// </summary>
    public List<Light> Lights;

    /// <summary>
    /// The Tween component used for animations.
    /// </summary>
    public Tween Tween;

    /// <summary>
    /// Updates the visibility of lights based on the grabbed status of an object.
    /// </summary>
    void Update()
    {
        if (Ghosting.GrabbedObject() != null)
        {
            DisableLightsOnGrabbedObject();
        }
        else
        {
            EnableAllLights();
        }
    }

    /// <summary>
    /// Disables the light on the grabbed object if it exists.
    /// </summary>
    private void DisableLightsOnGrabbedObject()
    {
        GameObject grabbedObject = Ghosting.GrabbedObject();

        // Check if a valid object is grabbed
        if (grabbedObject != null)
        {
            // Attempt to get the light component in the grabbed object's children
            Light grabbedObjectLight = grabbedObject.GetComponentInChildren<Light>();

            // Check if a light component is found
            if (grabbedObjectLight != null)
            {
                // Disable the light
                grabbedObjectLight.enabled = false;
            }
        }
    }

    /// <summary>
    /// Enables all lights in the Lights list.
    /// </summary>
    private void EnableAllLights()
    {
        // Uncomment the following line if Tween needs to be reset
        //Tween.CallReset();

        // Enable all lights in the list
        foreach (Light light in Lights)
        {
            light.enabled = true;
        }
    }
}