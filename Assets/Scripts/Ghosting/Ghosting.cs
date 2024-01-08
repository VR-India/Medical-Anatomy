using UnityEngine;
using BNG;

namespace iNucom
{
    namespace Ghost
    {
        /// <summary>
        /// Provides functionality to retrieve information about the currently grabbed object using the Grabber script.
        /// Grabber is BNG dependent; replace when using another API.
        /// </summary>
        public class Ghosting : MonoBehaviour
        {
            private static Grabber Grabber;

            private void Awake() { Grabber = GetComponent<Grabber>(); }

            /// <summary>
            /// Gets the name of the currently held object.
            /// </summary>
            /// <returns>The name of the held object or an empty string if no object is held.</returns>
            /// <remarks>
            /// This method returns the name of the currently held object using the Grabber script.
            /// If no object is being held, it returns an empty string.
            /// </remarks>
            public static string GetGrabbedName()
            {
                return Grabber.HoldingItem ? Grabber.HeldGrabbable.name : " ";
            }

            /// <summary>
            /// Gets the GameObject of the currently held object.
            /// </summary>
            /// <returns>The GameObject of the held object or null if no object is held.</returns>
            /// <remarks>
            /// This method returns the GameObject of the currently held object using the Grabber script.
            /// If no object is being held, it returns null.
            /// </remarks>
            public static GameObject GetGrabbedObject()
            {
                return Grabber.HoldingItem ? Grabber.HeldGrabbable.gameObject : null;
            }

        }
    }
}