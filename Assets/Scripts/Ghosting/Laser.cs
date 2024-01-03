using UnityEngine;
using BNG;
using iNucom.iEvents;

namespace iNucom
{
    /// <summary>
    /// Controls a laser beam that interacts with objects in the scene.
    /// </summary>
    public class Laser : MonoBehaviour
    {
        /// <summary>
        /// The maximum range of the laser beam.
        /// </summary>
        public float MaxRange = 25f;

        /// <summary>
        /// The layers considered as valid targets for the laser.
        /// </summary>
        public LayerMask ValidLayers;

        /// <summary>
        /// The transform representing the end point of the laser.
        /// </summary>
        public Transform LaserEnd;

        /// <summary>
        /// Determines if the laser is currently active.
        /// </summary>
        public bool Active = true;

        private LineRenderer line;

        /// <summary>
        /// The name of the object currently triggered by the laser.
        /// </summary>
        public static string TriggeredObject { get; private set; } = null;

        /// <summary>
        /// The GameObject currently triggered by the laser.
        /// </summary>
        [HideInInspector] public GameObject TriggeredGameObject;

        private void Start()
        {
            line = GetComponent<LineRenderer>();
        }

        private void LateUpdate()
        {
            if (Active)
            {
                HandleActiveLaser();
            }
            else
            {
                HandleInactiveLaser();
            }
        }

        RaycastHit hit;
        private void HandleActiveLaser()
        {
            line.enabled = true;

            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxRange, ValidLayers, QueryTriggerInteraction.Ignore))
            {
                UpdateLaserPositions(hit.point);
                HandleHitObject(hit);
            }
            else
            {
                UpdateLaserPositions(transform.localPosition + transform.forward * MaxRange);
                LaserEnd.gameObject.SetActive(false);
            }
        }

        private void HandleInactiveLaser()
        {
            LaserEnd.gameObject.SetActive(false);
            TriggeredObject = null;

            if (line)
            {
                line.enabled = false;
            }
        }

        private void UpdateLaserPositions(Vector3 endPosition)
        {
            line.useWorldSpace = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, endPosition);

            LaserEnd.gameObject.SetActive(true);
            LaserEnd.position = endPosition;
            LaserEnd.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
        }

        private void HandleHitObject(RaycastHit hit)
        {
            TriggeredObject = hit.collider.gameObject.name;
            TriggeredGameObject = hit.collider.gameObject;

            if (InputBridge.Instance.RightTriggerDown) // BNG dependent; change when using other API
            {
                // triObj.transform.SetParent(LaserEnd);
                TriggeredGameObject.transform.localPosition = LaserEnd.localPosition;
            }

            AnatomyManager.Instance.OnLaserTagged();
        }
    }
}