using UnityEngine;
using TMPro;
using iNucom.Ghost;
using iNucom.iEvents;

namespace iNucom
{
    // this script fetches data from json and scriptable object and assigns that to UI elements
    public class AnatomyInformationOnUI : MonoBehaviour
    {
        public string partName;
        // uncomment if using SO
        [SerializeField] private AnatomyInformationSO cadavarSO ;

        // uncomment if using JSON
       // private JSONFetch jsonFetch;

        public TMP_Text objName;
        public TMP_Text objDescription;

        private void OnEnable()
        {
            AnatomyManager.Instance.OnObjectGrab += SetNameToPanel;
            AnatomyManager.Instance.OnObjectGrab += SetDescriptionToPanel;
        }

        private void Start()
        {
            // uncomment if using JSON
            //jsonFetch = GetComponent<JSONFetch>();
        }
        public void SetNameToPanel()
        {
            if (objName == null)
            {
                objName.text = Ghosting.GrabbedName();
                partName = Ghosting.GrabbedName();
            }
        }

        public void SetDescriptionToPanel()
        {
            // uncomment if using SO
             objDescription.text = cadavarSO.GetDetails(Ghosting.GrabbedName());

            // uncomment if using JSON
           // objDescription.text = jsonFetch.GetDescription(Ghosting.GrabbedName());
        }

        private void OnDisable()
        {
            AnatomyManager.Instance.OnObjectGrab -= SetNameToPanel;
            AnatomyManager.Instance.OnObjectGrab -= SetDescriptionToPanel;
        }
        
        private void Update()
        {
          //  Debug.Log(Ghosting.GrabbedName)
            if (Ghosting.GrabbedName()!=null)
            {
                AnatomyManager.Instance.OnObjectGrab();               
            }
        }
    }
}