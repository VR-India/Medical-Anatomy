using UnityEngine;
using iNucom.iEvents;
using BNG;

namespace iNucom
{
    public class Laser : MonoBehaviour
    {
        public float MaxRange = 25f;
        public LayerMask ValidLayers;
        public Transform LaserEnd;
        public bool Active = true;
        LineRenderer line;
        public static string triggeredObject = null;
        [HideInInspector] public GameObject triObj;
        void Start()
        {
            line = GetComponent<LineRenderer>();
        }
        void LateUpdate()
        {
            if (Active)
            {
                line.enabled = true;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, MaxRange, ValidLayers, QueryTriggerInteraction.Ignore))
                {
                    line.useWorldSpace = true;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, hit.point);
                    triggeredObject = hit.collider.gameObject.name;
                    triObj = hit.collider.gameObject;
                    LaserEnd.gameObject.SetActive(true);
                    LaserEnd.position = hit.point;
                    LaserEnd.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                }
                else
                {
                    line.useWorldSpace = false;
                    line.SetPosition(0, transform.localPosition);
                    line.SetPosition(1, new Vector3(0, 0, MaxRange));
                    LaserEnd.gameObject.SetActive(false);
                }
            }
            else
            {
                LaserEnd.gameObject.SetActive(false);
                triggeredObject = null;
                if (line)
                {
                    line.enabled = false;
                }
            }
            if (triggeredObject != null)
            {
                if (InputBridge.Instance.RightTriggerDown) // this line BNG dependent change it when using other api
                {
                    //triObj.transform.SetParent(LaserEnd);
                    triObj.transform.localPosition = LaserEnd.localPosition;
                }
                AnatomyManager.Instance.OnLaserTagged();
            }
        }
    }
}