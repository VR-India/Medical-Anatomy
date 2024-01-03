using UnityEngine;

namespace iNucom
{
    /// <summary>
    /// Draws a LineRenderer from this Transform to another Transform, specified in local space.
    /// </summary>
    public class LineTransform : MonoBehaviour
    {
        /// <summary>
        /// The Transform to connect the line to.
        /// </summary>
        public Transform ConnectTo;

        private LineRenderer line;

        /// <summary>
        /// Initializes the LineRenderer component.
        /// </summary>
        private void Start() { InitializeLine(); }

        /// <summary>
        /// Updates the line position in LateUpdate.
        /// </summary>
        private void LateUpdate() { UpdateLine(); }

        /// <summary>
        /// Initializes the LineRenderer if it is not already assigned.
        /// </summary>
        private void InitializeLine()
        {
            if (line == null)
            {
                line = GetComponent<LineRenderer>();
                if (line != null)
                {
                    line.useWorldSpace = false;
                }
            }
        }

        /// <summary>
        /// Updates the line position using the specified ConnectTo Transform.
        /// </summary>
        public void UpdateLine()
        {
            InitializeLine();

            if (line != null)
            {
                // Set the line positions
                line.SetPosition(0, Vector3.zero);
                line.SetPosition(1, transform.InverseTransformPoint(ConnectTo.position));
            }
        }

        /// <summary>
        /// Forces an update of the line in the Scene view when selected.
        /// </summary>
        private void OnDrawGizmos() { UpdateLine(); }
    }
}