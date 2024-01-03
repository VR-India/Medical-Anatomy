using UnityEngine;
using DG.Tweening;

/// <summary>
/// Handles various tweening animations using DOTween.
/// </summary>
public class Tweens : MonoBehaviour
{
    [SerializeField] private float randomMin, randomMax;
    public static Tweens Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Folds or unfolds the specified GameObjects, creating a dynamic animation.
    /// </summary>
    /// <param name="childTransforms">Array of child GameObjects to be folded or unfolded.</param>
    /// <param name="initTransforms">Initial positions of child GameObjects.</param>
    /// <param name="initRotation">Initial rotations of child GameObjects.</param>
    /// <param name="fold">If true, folds the GameObject; if false, unfolds it.</param>
    public void Fold(GameObject[] childTransforms, Vector3[] initTransforms, Quaternion[] initRotation, bool fold)
    {
        for (int i = 0; i < childTransforms.Length; i++)
        {
            if (!fold)
                childTransforms[i].transform.DOLocalMove(GetRandomPosition(), 0.6f);
            else
                ResetTransform(childTransforms[i], initTransforms[i], initRotation[i], 0.6f);
        }
    }

    /// <summary>
    /// Resets the specified GameObjects to their original form.
    /// </summary>
    /// <param name="childTransforms">Array of child GameObjects to be reset.</param>
    /// <param name="initTransforms">Initial positions of child GameObjects.</param>
    /// <param name="initRotation">Initial rotations of child GameObjects.</param>
    /// <param name="duration">Duration of the reset animation.</param>
    public void ResetAnatomy(GameObject[] childTransforms, Vector3[] initTransforms, Quaternion[] initRotation, float duration)
    {
        for (int i = 0; i < childTransforms.Length; i++)
        {
            ResetTransform(childTransforms[i], initTransforms[i], initRotation[i], duration);
        }
    }

    /// <summary>
    /// Resets the position and rotation of a GameObject to specified values over a specified duration.
    /// </summary>
    /// <param name="target">The GameObject to reset.</param>
    /// <param name="position">The target local position for the reset.</param>
    /// <param name="rotation">The target rotation for the reset.</param>
    /// <param name="duration">The duration of the reset animation.</param>
    public void ResetTransform(GameObject target, Vector3 position, Quaternion rotation, float duration)
    {
        target.transform.DOLocalMove(position, duration);
        target.transform.DORotate(rotation.eulerAngles, duration * 0.5f);
    }


    /// <summary>
    /// Moves the specified GameObjects and related buttons sideways.
    /// </summary>
    /// <param name="childTransforms">Array of child GameObjects to be moved sideways.</param>
    /// <param name="subInitTransforms">Initial positions of child GameObjects for sideways movement.</param>
    /// <param name="subInitRotation">Initial rotations of child GameObjects for sideways movement.</param>
    /// <param name="fold">If true, moves GameObjects sideways; if false, moves them back to initial positions.</param>
    public void SidewaysFold(GameObject[] childTransforms, Vector3[] subInitTransforms, Quaternion[] subInitRotation, bool fold)
    {
        for (int i = 0; i < childTransforms.Length; i++)
        {
            if (!fold)
                childTransforms[i].transform.DOLocalMove(GetSidewaysPosition(i, childTransforms), 0.6f);
            else
                ResetTransform(childTransforms[i], subInitTransforms[i], subInitRotation[i], 0.6f);
        }
    }

    // Helper method to get a random position within the specified range
    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(randomMin, randomMax), Random.Range(randomMin, randomMax), Random.Range(randomMin, randomMax));
    }

    // Helper method to get a sideways position based on index
    private Vector3 GetSidewaysPosition(int index, GameObject[] childTransforms)
    {
        return new Vector3(index * 2, 0, childTransforms[index].transform.localPosition.z);
    }
}