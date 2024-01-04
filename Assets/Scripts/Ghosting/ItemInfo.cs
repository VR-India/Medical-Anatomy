#region
/// copyright (c) iNucom. All rights reserved.
#endregion

using UnityEngine;

namespace iNucom
{
    public class ItemInfo : MonoBehaviour
    {
        public GameObject temp;
        void Start()
        {
            GameObject t=Instantiate(temp,transform.position,Quaternion.identity);
                  // transform.position = new Vector3(transform.position)
        }
    }
}