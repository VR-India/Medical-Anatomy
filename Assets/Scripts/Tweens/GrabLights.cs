using System.Collections.Generic;
using UnityEngine;
using iNucom.Ghost;
public class GrabLights : MonoBehaviour
{
    public List<Light> lights;
    public Tween tween;
    void Update()
    {
        if ((Ghosting.GrabbedObject()) != null)
        {
            //Debug.LogWarning(" its not null");
            if (Ghosting.GrabbedObject().GetComponentInChildren<Light>())
                Ghosting.GrabbedObject().GetComponentInChildren<Light>().enabled = false;
        }
        else
        {
            // tween.CallReset();
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
        }
    }
}