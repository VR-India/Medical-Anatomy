using UnityEngine;
using DG.Tweening;
public class Tweens : MonoBehaviour
{
    #region Variables
    [SerializeField] float Rmin, Rmax;
    public static Tweens instance;
    #endregion
    private void Awake() { instance = this; }
    #region Fold  
    /// <summary>
    /// folds and unfolds the gameObject into small pieces and back together
    /// using data provided by the call
    /// </summary>
    public void Fold(GameObject[] childTransforms, Vector3[] initTransforms, Quaternion[] initRotation, bool fold)
    {
        for (int i = 0; i < childTransforms.Length; i++)
        {
            if (!fold)
                childTransforms[i].GetComponent<Transform>().DOLocalMove(new Vector3(Random.Range(Rmin, Rmax), Random.Range(Rmin, Rmax), Random.Range(Rmin, Rmax)), 0.6f);
            if (fold)
            {
                childTransforms[i].GetComponent<Transform>().DOLocalMove(initTransforms[i], 0.6f);
                childTransforms[i].GetComponent<Transform>().DORotate(new Vector3(initRotation[i].eulerAngles.x, initRotation[i].eulerAngles.y, initRotation[i].eulerAngles.z), 0.6f);
            }
        }
    }
    #endregion
    #region Reset
    /// <summary>
    /// resets the already blasted gameObjects to their original form(does not effect sidewaysFold)
    /// using data provided by the call
    /// </summary>
    public void ResetAnatomy(GameObject[] childTransforms, Vector3[] initTransforms, Quaternion[] initRotation, bool fold)
    {
        for (int i = 0; i < childTransforms.Length; i++)
        {
            childTransforms[i].GetComponent<Transform>().DOLocalMove(initTransforms[i], 2f);
            childTransforms[i].GetComponent<Transform>().DORotate(new Vector3(initRotation[i].eulerAngles.x, initRotation[i].eulerAngles.y, initRotation[i].eulerAngles.z), 1f);
        }
    }
    #endregion
    #region SideWays
    /// <summary>
    /// Moves the gameObjects and related buttons sideways
    /// using data provided by the call
    /// </summary>
    public void sidewaysFold(GameObject[] childTransforms, Vector3[] subInitTransforms, Quaternion[] subInitRotation, bool fold)
    {
       // sideFold = !sideFold;
        for (int i = 0; i < childTransforms.Length; i++)
        {
            if (!fold)
            {
                childTransforms[i].transform.DOLocalMove(new Vector3(i * 2, 0, childTransforms[i].transform.localPosition.z), 0.6f);
            }
            if (fold)
            {
                childTransforms[i].transform.DOLocalMove(subInitTransforms[i], 0.6f);
                childTransforms[i].transform.DORotate(new Vector3(subInitRotation[i].eulerAngles.x, subInitRotation[i].eulerAngles.y, subInitRotation[i].eulerAngles.z), 0.6f);
            }
        }
    }
    #endregion
}