using UnityEngine;
using TMPro;
using iNucom.Ghost;
using iNucom.iEvents;

namespace iNucom
{
    /// <summary>
    /// Fetches data from JSON or a ScriptableObject and assigns it to UI elements based on the currently grabbed object.
    /// </summary>
    public class AnatomyInformationOnUI : MonoBehaviour
    {
        /// <summary>
        /// ScriptableObject containing anatomy information.
        /// </summary>
        [SerializeField] private AnatomyInformationSO cadaverSO;

        /// <summary>
        /// JSON data fetcher.
        /// </summary>
        private JSONFetch jsonFetch;

        /// <summary>
        /// Text component displaying the object name.
        /// </summary>
        public TMP_Text objName;

        /// <summary>
        /// Text component displaying the object description.
        /// </summary>
        public TMP_Text objDescription;

        private void OnEnable()
        {
            AnatomyManager.Instance.OnObjectGrab += SetUIElements;
        }

        private void Start()
        {
            // Uncomment if using JSON
            jsonFetch = GetComponent<JSONFetch>();
        }

        /// <summary>
        /// Sets the name and description to the UI panel based on the currently grabbed object.
        /// </summary>
        private void SetUIElements()
        {
            string grabbedName = Ghosting.GrabbedName();

            // Set the name to the UI panel
            if (objName != null)
            {
                objName.text = grabbedName;
            }

            // Set the description to the UI panel based on the data source (SO or JSON)
            if (objDescription != null)
            {
                // Uncomment if using SO
                objDescription.text = cadaverSO.GetDetails(grabbedName);

                // Uncomment if using JSON
                 objDescription.text = jsonFetch.GetDescription(grabbedName);
            }
        }

        private void OnDisable()
        {
            AnatomyManager.Instance.OnObjectGrab -= SetUIElements;
        }

        private void Update()
        {
            // Debug.Log(Ghosting.GrabbedName())
            if (Ghosting.GrabbedName() != null)
            {
                AnatomyManager.Instance.OnObjectGrab();
            }
        }
    }
}