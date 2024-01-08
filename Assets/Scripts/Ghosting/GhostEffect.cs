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
            string grabbedName = Ghosting.GetGrabbedName();
            Transform grabbedItem = this.transform.Find(grabbedName);

            DisableAllRenderersAndColliders();

            if (grabbedItem != null)
            {
                itemName = grabbedName;

                EnableRendererAndCollider(grabbedItem);
            }
            else if (!string.IsNullOrEmpty(itemName))
            {
                Transform namedItem = this.transform.Find(itemName);
                EnableCollider(namedItem);
            }
        }

        private void DisableAllRenderersAndColliders()
        {
            foreach (MeshRenderer meshRenderer in renderers)
            {
                meshRenderer.enabled = false;
            }

            foreach (MeshCollider collider in colliders)
            {
                collider.enabled = false;
            }
        }

        private void EnableRendererAndCollider(Transform item)
        {
            if (item != null)
            {
                MeshRenderer meshRenderer = item.GetComponent<MeshRenderer>();
                MeshCollider meshCollider = item.GetComponent<MeshCollider>();

                if (meshRenderer != null && meshCollider != null)
                {
                    meshRenderer.enabled = true;
                    meshCollider.enabled = true;
                }
            }
        }

        private void EnableCollider(Transform item)
        {
            if (item != null)
            {
                MeshCollider meshCollider = item.GetComponent<MeshCollider>();
                if (meshCollider != null)
                {
                    meshCollider.enabled = true;
                }
            }
        }

    }
}
