using iNucom.Ghost;
using UnityEngine;
public class GhostSnap : MonoBehaviour
{
    /// <summary>
    /// Checking the Trigger and setting the location back to its original ie snapping back..
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == this.gameObject.name)
        {
            other.gameObject.transform.position = this.transform.position;
            other.gameObject.transform.rotation = this.transform.rotation;
            
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}