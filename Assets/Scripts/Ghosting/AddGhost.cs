using UnityEngine;

/// <summary>
/// Adds ghost effects to child MeshRenderers by configuring them with a ghost material, MeshCollider, and GhostSnap component.
/// </summary>
public class AddGhost : MonoBehaviour
{
    /// <summary>
    /// Array of child MeshRenderers to be configured with ghost effects.
    /// </summary>
    public MeshRenderer[] _mesh;

    /// <summary>
    /// The material used for the ghost effect.
    /// </summary>
    public Material ghostMaterial;

    /// <summary>
    /// Configures child MeshRenderers with ghost effects during Awake.
    /// </summary>
    private void Awake()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mesh in _mesh)
        {
            Transform meshTransform = mesh.transform;

            // Set the parent, material, and enable/disable the MeshRenderer
            meshTransform.SetParent(transform, true);
            mesh.material = ghostMaterial;
            mesh.enabled = false;

            // Add and configure MeshCollider
            MeshCollider meshCollider = meshTransform.gameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;
            meshCollider.isTrigger = true;

            // Add GhostSnap component
            meshTransform.gameObject.AddComponent<GhostSnap>();
        }
    }
}