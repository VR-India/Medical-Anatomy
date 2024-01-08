using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the creation and visibility of buttons associated with a Tween.
/// </summary>
public class SplitButtons : MonoBehaviour
{
    /// <summary>
    /// Prefab for the buttons.
    /// </summary>
    public GameObject buttonPrefab;

    /// <summary>
    /// Tween component reference.
    /// </summary>
    public Tween tween;

    /// <summary>
    /// List of buttons created.
    /// </summary>
    private List<GameObject> _buttons;

    private void Start()
    {
        _buttons = new List<GameObject>();

        //// Instantiate buttons for each AddGrabber in the tween.
        //foreach (AddGrabber grabber in tween.AddGrabbers)
        //{
        //    GameObject button = InstantiateButton();
        //    button.transform.parent = grabber.transform;
        //    button.transform.localPosition = new Vector3(0, -0.5f, 0.8f);

        //    // Add button click listener to call the Fold method in the associated Tween.
        //    button.GetComponentInChildren<Button>().onClick.AddListener(button.GetComponentInParent<Tween>().CallFold);

        //    button.SetActive(false);
        //    _buttons.Add(button);
        //}
    }

    /// <summary>
    /// Instantiates a new button based on the buttonPrefab.
    /// </summary>
    /// <returns>The instantiated button GameObject.</returns>
    private GameObject InstantiateButton()
    {
        return Instantiate(buttonPrefab);
    }

    /// <summary>
    /// Toggles the visibility of the buttons.
    /// </summary>
    public void ToggleButtonsVisibility()
    {
        foreach (GameObject button in _buttons)
        {
            button.SetActive(!button.activeSelf);
        }
    }
}