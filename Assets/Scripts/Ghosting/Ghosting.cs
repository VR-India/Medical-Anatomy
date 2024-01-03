using UnityEngine;
using BNG;

namespace iNucom
{
    namespace Ghost
    {
        /// <summary>
        /// Provides static methods to retrieve information about the currently grabbed object using the Grabber component.
        /// </summary>
        public class Ghosting : MonoBehaviour
        {
            /// <summary>
            /// The Grabber component used to interact with grabbable objects.
            /// </summary>
            private static Grabber grabber;

            /// <summary>
            /// Initializes the Grabber component during the Awake phase.
            /// </summary>
            private void Awake()
            {
                grabber = GetComponent<Grabber>();
            }

            /// <summary>
            /// Retrieves the name of the currently grabbed object, or an empty string if no object is being held.
            /// </summary>
            /// <returns>The name of the currently grabbed object.</returns>
            public static string GrabbedName()
            {
                return grabber.HoldingItem ? grabber.HeldGrabbable.name : string.Empty;
            }

            /// <summary>
            /// Retrieves the GameObject of the currently grabbed object, or null if no object is being held.
            /// </summary>
            /// <returns>The GameObject of the currently grabbed object.</returns>
            public static GameObject GrabbedObject()
            {
                return grabber.HoldingItem ? grabber.HeldGrabbable.gameObject : null;
            }
        }
    }
}