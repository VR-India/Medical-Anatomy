using UnityEngine;
using BNG;

/// <summary>
/// Adds grabbable properties to child MeshRenderers using the BNG (VR Interaction) framework.
/// </summary>
public class AddGrabber : MonoBehaviour
{
    /// <summary>
    /// Array of child MeshRenderers to be configured as grabbable objects.
    /// </summary>
    public MeshRenderer[] _colliders;

    /// <summary>
    /// Configures child MeshRenderers as grabbable objects during Awake.
    /// </summary>
    private void Awake()
    {
        _colliders = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer mesh in _colliders)
        {
            Transform meshTransform = mesh.transform;

            // Set the parent and scale of the MeshRenderer
            meshTransform.SetParent(transform, true);
            meshTransform.localScale = Vector3.one;

            // Add and configure Rigidbody
            Rigidbody rigidbody = meshTransform.gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;

            // Add and configure MeshCollider
            MeshCollider meshCollider = meshTransform.gameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;
            meshCollider.isTrigger = true;

            // Add and configure Grabbable component (BNG framework)
            Grabbable grabbable = meshTransform.gameObject.AddComponent<Grabbable>();
            grabbable.HideHandGraphics = true;
            grabbable.ParentHandModel = false;
            grabbable.ParentToHands = true;
        }
    }
}