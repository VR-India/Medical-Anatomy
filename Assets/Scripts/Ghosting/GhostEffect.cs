using UnityEngine;
using iNucom.Ghost;

namespace iNucom
{
    /// <summary>
    /// Enables Ghost Shader effects on the held item by obtaining the name from the Ghosting script.
    /// </summary>
    public class GhostEffect : MonoBehaviour
    {
        private MeshCollider[] colliders;
        private MeshRenderer[] renderers;
        private string itemName;

        /// <summary>
        /// Initializes the GhostEffect component by obtaining references to child MeshColliders and MeshRenderers.
        /// </summary>
        private void Awake()
        {
            colliders = GetComponentsInChildren<MeshCollider>();
            renderers = GetComponentsInChildren<MeshRenderer>();
        }

        /// <summary>
        /// Updates the GhostEffect component based on the currently held item.
        /// </summary>
        void Update()
        {
            string grabbedName = Ghosting.GrabbedName();
            Transform grabbedItem = this.transform.Find(grabbedName);

            if (grabbedItem != null)
            {
                itemName = grabbedName;

                foreach (MeshRenderer meshRenderer in renderers)
                {
                    meshRenderer.enabled = false;
                }

                if (!string.IsNullOrEmpty(itemName))
                {
                    grabbedItem.GetComponent<MeshRenderer>().enabled = true;
                }
            }
            else
            {
                foreach (MeshCollider collider in colliders)
                {
                    collider.enabled = false;
                }

                if (!string.IsNullOrEmpty(itemName))
                {
                    Transform namedItem = this.transform.Find(itemName);
                    if (namedItem != null)
                    {
                        namedItem.GetComponent<MeshCollider>().enabled = true;
                    }
                }
            }
        }
    }
}
