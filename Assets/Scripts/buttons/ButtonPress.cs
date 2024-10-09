using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleAmount = 0.5f;
    public float scaleDuration = 0.2f;
    private bool originalScaleSet = false;
    public void ScaleDown()
    {
        if (!originalScaleSet)
        {
            originalScale = transform.localScale;
            originalScaleSet = true;
        }
        Vector3 scaledDown = new Vector3(
        originalScale.x,
        originalScale.y * scaleAmount,
        originalScale.z
        );

        transform.localScale = scaledDown;


        Invoke("ScaleUp", scaleDuration);
    }

    private void ScaleUp()
    {
        transform.localScale = originalScale;
    }
}
