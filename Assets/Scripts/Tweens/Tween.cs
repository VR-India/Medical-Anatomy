using System.Linq;
using UnityEngine;

/// <summary>
/// Controls the folding and resetting of child objects for animation purposes.
/// </summary>
public class Tween : MonoBehaviour
{
    /// <summary>
    /// Array of MeshRenderers used for folding and resetting.
    /// </summary>
    private MeshRenderer[] meshRenderers;

    /// <summary>
    /// Array of AddGrabber components used for folding and resetting.
    /// </summary>
    public AddGrabber[] AddGrabbers;

    /// <summary>
    /// Array of child transforms.
    /// </summary>
    private GameObject[] childTransforms;

    /// <summary>
    /// Initial local positions of child transforms.
    /// </summary>
    private Vector3[] initialTransforms;

    /// <summary>
    /// Initial rotations of child transforms.
    /// </summary>
    private Quaternion[] initialRotations;

    /// <summary>
    /// Flag indicating whether parents are considered.
    /// </summary>
    public bool Parents;

    /// <summary>
    /// Flag indicating whether the Tween is valid for reset.
    /// </summary>
    public bool IsValidForReset;

    /// <summary>
    /// Flag indicating the current fold state.
    /// </summary>
    private bool fold = true;

    /// <summary>
    /// Initializes the component by retrieving child objects and storing their initial transforms.
    /// </summary>
    private void Awake()
    {
        // Retrieve child objects based on the selected option (Parents or meshRenderers)
        if (Parents)
            AddGrabbers = GetComponentsInChildren<AddGrabber>();
        else
            meshRenderers = GetComponentsInChildren<MeshRenderer>();

        // Create an array of child GameObjects
        childTransforms = Parents ? AddGrabbers.Select(ag => ag.gameObject).ToArray() : meshRenderers.Select(mr => mr.gameObject).ToArray();

        // Initialize arrays to store the initial transforms of the child GameObjects
        initialTransforms = new Vector3[childTransforms.Length];
        initialRotations = new Quaternion[childTransforms.Length];

        // Store the initial local positions and rotations of the child GameObjects
        for (int i = 0; i < childTransforms.Length; i++)
        {
            initialTransforms[i] = childTransforms[i].transform.localPosition;
            initialRotations[i] = childTransforms[i].transform.rotation;
        }
    }


    /// <summary>
    /// Calls the function to execute fold/unfold from the Tweens script.
    /// </summary>
    public void CallFold()
    {
        fold = !fold;
        Tweens.Instance.Fold(childTransforms, initialTransforms, initialRotations, fold);
    }

    /// <summary>
    /// Calls the function to execute reset from the Tweens script.
    /// </summary>
    public void CallReset()
    {
        fold = !fold;
        Tweens.Instance.ResetAnatomy(childTransforms, initialTransforms, initialRotations, 3f);
    }

    /// <summary>
    /// Executes side fold animation.
    /// </summary>
    public void SideFold()
    {
        fold = !fold;
        Tweens.Instance.SidewaysFold(childTransforms, initialTransforms, initialRotations, fold);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) || BNG.InputBridge.Instance.BButtonDown)
        {
            if (IsValidForReset)
                CallReset();
        }
    }
}
