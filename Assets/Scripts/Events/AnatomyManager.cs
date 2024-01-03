using UnityEngine;
using UnityEngine.Events;

namespace iNucom.iEvents
{
    /// <summary>
    /// Manages anatomy-related events in the application.
    /// </summary>
    public class AnatomyManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the AnatomyManager.
        /// </summary>
        public static AnatomyManager Instance { get; private set; }
        private void Awake()
        {
            // Ensure only one instance of AnatomyManager exists
            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// <summary>
        /// Event triggered when an object is grabbed.
        /// </summary>
        public UnityAction OnObjectGrab;

        /// <summary>
        /// Event triggered when the laser tags an object.
        /// </summary>
        public UnityAction OnLaserTagged;
    }
}