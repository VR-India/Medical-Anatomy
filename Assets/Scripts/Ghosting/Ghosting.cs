using UnityEngine;
using BNG;

namespace iNucom
{
    namespace Ghost
    {
        /// <summary>
        /// Getting the name of the object that we are holding from the Grabber Script
        /// Grabber is BNG dependent replace when using another api
        /// </summary>
        public class Ghosting : MonoBehaviour
        {
            private static Grabber Grabber;

            private void Awake()
            {
                Grabber = GetComponent<Grabber>();
            }

            public static string GrabbedName()
            {
                if (Grabber.HoldingItem)
                {
                    return Grabber.HeldGrabbable.name;
                }
                else
                    return " ";
            }

            public static GameObject GrabbedObject()
            {
                if (Grabber.HoldingItem)
                {
                    return Grabber.HeldGrabbable.gameObject;
                }
                else
                { return null; }
            }
        }
    }
}