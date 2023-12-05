using UnityEngine;
using Unity.VisualScripting;
using BNG;

public class AddGrabber : MonoBehaviour
{
    public MeshRenderer[] _collider;
    private void Awake()
    {
        _collider = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in _collider)
        {
            mesh.transform.SetParent(transform, true);
            mesh.transform.localScale=new Vector3(1,1,1);
            mesh.AddComponent<Rigidbody>();
            mesh.GetComponent<Rigidbody>().isKinematic = true;
            mesh.GetComponent<Rigidbody>().useGravity = false;            

            mesh.AddComponent<MeshCollider>();
            mesh.GetComponent<MeshCollider>().convex = true;
            mesh.GetComponent<MeshCollider>().isTrigger = true;

            // these 4 lines are  BNG Dependent Change it when using other api
            mesh.AddComponent<Grabbable>();
            mesh.GetComponent<Grabbable>().HideHandGraphics = true;
            mesh.GetComponent<Grabbable>().ParentHandModel = false;
            mesh.GetComponent<Grabbable>().ParentToHands = true;
        }
    }
}