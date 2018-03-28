using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class MoveButton : MonoBehaviour, IInputClickHandler {
    public PopOverController parent;

    // Update is called once per frame
    public void OnInputClicked(InputClickedEventData eventData) {
        GameObject obj = parent.GetSelected();
        ConstrainedTapToPlace placer = obj.GetComponent<ConstrainedTapToPlace>();
        placer.active = true;
        placer.IsBeingPlaced = true;
        parent.Hide();
    }
}
