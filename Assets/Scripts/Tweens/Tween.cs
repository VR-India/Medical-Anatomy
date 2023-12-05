using UnityEngine;

public class Tween : MonoBehaviour
{
    MeshRenderer[] meshRenderers;
    public AddGrabber[] addgrabber;
    GameObject[] childTransforms;
    Vector3[] initalTransforms;
    Quaternion[] initialRotation;
    public bool parents;
    bool fold = true;
    private void Awake()
    {
        if (parents)
        {
            addgrabber = GetComponentsInChildren<AddGrabber>();
            initalTransforms = new Vector3[addgrabber.Length];
            initialRotation = new Quaternion[addgrabber.Length];
            childTransforms = new GameObject[addgrabber.Length];
            for (int i = 0; i < childTransforms.Length; i++)
            {
                childTransforms[i] = addgrabber[i].gameObject;
            }
        }
        if (!parents)
        {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
            initalTransforms = new Vector3[meshRenderers.Length];
            initialRotation = new Quaternion[meshRenderers.Length];
            childTransforms = new GameObject[meshRenderers.Length];
            for (int i = 0; i < childTransforms.Length; i++)
            {
                childTransforms[i] = meshRenderers[i].gameObject;
            }
        }
        for (int i = 0; i < childTransforms.Length; i++)
        {
            initalTransforms[i] = childTransforms[i].GetComponent<Transform>().localPosition;
            initialRotation[i] = childTransforms[i].GetComponent<Transform>().rotation;
        }
    }

    public bool isValidForReset;
    //calls the fuction to execute Fold/unfold
    //from Tweens script
    public void CallFold()
    {
        fold = !fold;
        Tweens.instance.Fold(childTransforms, initalTransforms, initialRotation, fold);
    }
    //calls the function to execute reset function
    //from Tweens script
    public void CallReset()
    {
        fold = !fold;
        Tweens.instance.ResetAnatomy(childTransforms, initalTransforms, initialRotation, fold);
    }

    public void SideFold()
    {
        fold = !fold;
        Tweens.instance.sidewaysFold(childTransforms, initalTransforms, initialRotation, fold);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) || BNG.InputBridge.Instance.BButtonDown)
        {
            if (isValidForReset)
                CallReset();
        }
    }
}