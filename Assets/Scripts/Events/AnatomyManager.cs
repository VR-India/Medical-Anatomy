using UnityEngine;
using UnityEngine.Events;
namespace iNucom
{
    namespace iEvents
    {
        public class AnatomyManager : MonoBehaviour
        {
            public static AnatomyManager Instance;
            private void Awake()
            {
                if (Instance == null) Instance = this;
            }
            public UnityAction OnObjectGrab;
            public UnityAction OnLaserTagged;
        }
    }
}