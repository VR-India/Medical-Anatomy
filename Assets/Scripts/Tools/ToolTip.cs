using UnityEngine;

namespace iNucom
{
    /// <summary>
    /// Provides a tooltip for an object with optional line connection to another object.
    /// </summary>
    public class ToolTip : MonoBehaviour
    {
        /// <summary>
        /// Offset from the object to display the tooltip.
        /// </summary>
        public Vector3 TipOffset = new Vector3(1.5f, 0.2f, 0);

        /// <summary>
        /// If true, the Y axis will be in world coordinates; false for local coordinates.
        /// </summary>
        public bool UseWorldYAxis = true;

        /// <summary>
        /// Hide the tooltip if the camera is farther away than this distance (in meters).
        /// </summary>
        public float MaxViewDistance = 10f;

        /// <summary>
        /// The target object to draw a line to.
        /// </summary>
        public Transform DrawLineTo;
        private LineTransform lineTo;
        private Transform lookAt;
        private Transform childTransform;

        private void Start()
        {
            InitializeComponents();
        }

        private void Update()
        {
            UpdateTooltipPosition();
        }

        /// <summary>
        /// Initializes necessary components and settings.
        /// </summary>
        private void InitializeComponents()
        {
            lookAt = Camera.main?.transform;
            lineTo = GetComponentInChildren<LineTransform>();
            childTransform = transform.GetChild(0);

            if (DrawLineTo && lineTo)
            {
                lineTo.ConnectTo = DrawLineTo;
            }
        }

        /// <summary>
        /// Updates the position and visibility of the tooltip.
        /// </summary>
        public virtual void UpdateTooltipPosition()
        {
            if (lookAt == null && Camera.main != null)
            {
                lookAt = Camera.main.transform;
            }

            if (lookAt == null)
            {
                return;
            }

            transform.LookAt(lookAt);

            transform.parent = DrawLineTo;
            transform.localPosition = TipOffset;

            if (UseWorldYAxis)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
                transform.position += new Vector3(0, TipOffset.y, 0);
            }

            if (childTransform)
            {
                childTransform.gameObject.SetActive(Vector3.Distance(transform.position, lookAt.position) <= MaxViewDistance);
            }
        }
    }
}