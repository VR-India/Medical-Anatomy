using UnityEngine;

/// <summary>
/// Snaps an object back to its original position and rotation when triggered by another object with the same name.
/// </summary>
public class GhostSnap : MonoBehaviour
{
    /// <summary>
    /// Checks for triggers and snaps the object back to its original position and rotation.
    /// </summary>
    /// <param name="other">The Collider of the triggering object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Ensure the triggering object has the same name as this object
        if (other.gameObject.name == this.gameObject.name)
        {
            // Snap the triggering object back to the original position and rotation
            other.gameObject.transform.position = this.transform.position;
            other.gameObject.transform.rotation = this.transform.rotation;

            // Disable the MeshRenderer of this object
            this.GetComponent<MeshRenderer>().enabled = false;
            //Tweens.Instance.ResetTransform(other.gameObject, other.gameObject.transform.position, other.gameObject.transform.rotation,3f);
        }
    }
}