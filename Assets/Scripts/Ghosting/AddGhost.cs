using Unity.VisualScripting;
using UnityEngine;

public class AddGhost : MonoBehaviour
{
    public MeshRenderer[] _mesh;
    public Material ghostMaterial;
    private void Awake()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in _mesh)
        {
            mesh.transform.SetParent(transform, true);
            mesh.material = ghostMaterial;
            mesh.enabled = false;
           // mesh.AddComponent<Rigidbody>();
          //  mesh.GetComponent<Rigidbody>().isKinematic = true;
           // mesh.GetComponent<Rigidbody>().useGravity = false;

            mesh.AddComponent<MeshCollider>();
            mesh.GetComponent<MeshCollider>().convex = true;
            mesh.GetComponent<MeshCollider>().isTrigger = true;

            mesh.AddComponent<GhostSnap>();
        }
    }
}