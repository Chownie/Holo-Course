using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ToolboxController : MonoBehaviour, IInputClickHandler
{
    public Transform target;
    bool active = false;
    int clicks = 0;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (clicks == 0)
        {
            clicks = eventData.TapCount;
            Invoke("SingleTap", 0.5f);
        }
        else
        {
            CancelInvoke("SingleTap");
            DoubleTap();
        }
    }

    void SingleTap()
    {
        clicks = 0;
    }

    void DoubleTap()
    {
        clicks = 0;
        transform.position = target.position + (target.forward * 2);
        // transform.LookAt(transform.position - target.position);

        Vector3 direction = transform.position - target.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
