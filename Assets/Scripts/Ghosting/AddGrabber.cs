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
            ConfigureMesh(mesh);
        }
    }
    private void ConfigureMesh(MeshRenderer mesh)
    {
        Transform meshTransform = mesh.transform;

        // Set the parent and scale of the MeshRenderer
        meshTransform.SetParent(transform, true);
        meshTransform.localScale = Vector3.one;

        // Add and configure Rigidbody
        Rigidbody rigidbody = AddRigidbody(meshTransform);

        // Add and configure MeshCollider
        AddMeshCollider(meshTransform);

        // Add and configure Grabbable component (BNG framework)
        AddGrabbable(meshTransform);
    }
    private Rigidbody AddRigidbody(Transform parent)
    {
        Rigidbody rigidbody = parent.gameObject.AddComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
            return rigidbody;
    }
    private void AddMeshCollider(Transform parent)
    {
        MeshCollider meshCollider = parent.gameObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
    }
    private void AddGrabbable(Transform parent)
    {
        Grabbable grabbable = parent.gameObject.AddComponent<Grabbable>();
        grabbable.HideHandGraphics = true;
        grabbable.ParentHandModel = false;
        grabbable.ParentToHands = true;
        grabbable.SnapHandModel = false;
    }
}