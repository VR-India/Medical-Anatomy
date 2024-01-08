using UnityEngine;

/// <summary>
/// Adds ghost effects to child MeshRenderers by configuring them with a ghost material, MeshCollider, and GhostSnap component.
/// </summary>
public class AddGhost : MonoBehaviour
{
    /// <summary>
    /// The material used for the ghost effect.
    /// </summary>
    public Material ghostMaterial;

    /// <summary>
    /// Configures child MeshRenderers with ghost effects during Awake.
    /// </summary>
    private void Awake()
    {
        foreach (Transform childTransform in transform)
        {
            MeshRenderer mesh = childTransform.GetComponent<MeshRenderer>();

            if (mesh != null)
            {
                // Set the parent, material, and enable/disable the MeshRenderer
                childTransform.SetParent(transform, true);
                mesh.material = ghostMaterial;
                mesh.enabled = false;

                // Add and configure MeshCollider
                MeshCollider meshCollider = childTransform.gameObject.AddComponent<MeshCollider>();
                meshCollider.convex = true;
                meshCollider.isTrigger = true;
                meshCollider.enabled = false;

                // Add GhostSnap component
                childTransform.gameObject.AddComponent<GhostSnap>();
            }
        }
    }
}
