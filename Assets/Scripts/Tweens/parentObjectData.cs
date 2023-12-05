using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class parentObjectData : MonoBehaviour
{
    //public List<Tween> subLayer;    
    //Vector3[] subIntialTransforms;
    //Quaternion[] subInitialRotation;
    //private void Awake()
    //{
    //    subLayer = GetComponentsInChildren<Tween>().ToList();
    //    subIntialTransforms = new Vector3[subLayer.Count];
    //    subInitialRotation = new Quaternion[subLayer.Count];
    //    for (int i = 0; i < subLayer.Count; i++)
    //    {
    //        subIntialTransforms[i] = subLayer[i].GetComponent<Transform>().localPosition;
    //        subInitialRotation[i] = subLayer[i].GetComponent<Transform>().rotation;
    //    }

    //}

    public Tween fold;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            fold.CallReset();
        }
    }

    ////calls the function to execute sidewaysFold function
    ////from TweenExplosion script
    //public void callSidewaysFold()
    //{
    //  //  Tweens.instance.sidewaysFold(subLayer, subIntialTransforms, subInitialRotation);
    //}
}
