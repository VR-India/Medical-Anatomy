using UnityEngine;
using iNucom.Ghost;

namespace iNucom
{
    /// <summary>
    /// Enabling the Ghost Shader effects on the item we hold by getting the name from ghosting script
    /// </summary>
    public class GhostEffect : MonoBehaviour
    {
        MeshCollider[] colliders;
        MeshRenderer[] renderers;
        public string _name;
        private void Awake()
        {
            colliders = GetComponentsInChildren<MeshCollider>();
            renderers = GetComponentsInChildren<MeshRenderer>();    
        }

        void Update()
        {
            if (this.transform.Find(Ghosting.GrabbedName()) != null)
            {
                _name = Ghosting.GrabbedName();
                foreach (MeshRenderer mess in renderers)
                {
                    mess.enabled = false;
                }
                this.transform.Find(Ghosting.GrabbedName()).GetComponent<MeshRenderer>().enabled = true;
            }
            if (this.transform.Find(Ghosting.GrabbedName()) == null)
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = false;
                }
                if (_name != "")
                    this.transform.Find(_name).GetComponent<MeshCollider>().enabled = true;
            }
        }
    }
}