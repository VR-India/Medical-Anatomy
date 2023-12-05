using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SplitButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Tween tween;
    public List<GameObject> _btns;
    private void Start()
    {
        foreach (AddGrabber t in tween.addgrabber)
        {
            GameObject temp = Instantiate(buttonPrefab);            
            temp.transform.parent = t.transform;
            temp.transform.localPosition = new Vector3 (0, -0.5f, 0.8f);
            temp.GetComponentInChildren<Button>().onClick.AddListener(temp.GetComponentInParent<Tween>().CallFold);
            temp.SetActive(false);
            _btns.Add(temp);
        }
    }

    bool hide;
    public void HideButtons()
    {
        hide = !hide;
        foreach (GameObject item in _btns)
        {
            item.SetActive(hide);
        }
        
    }
}