using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class DeletionButton : MonoBehaviour, IInputClickHandler {
    public PopOverController parent;
    
    public void OnInputClicked(InputClickedEventData eventData) {
        GameObject obj = parent.GetSelected();
        ReactiveBlock block = obj.GetComponent<ReactiveBlock>();
        if (obj == null) {
            return;
        }
        if(block.block == blocktype.WAYPOINT) {
            block.collection.RemoveWaypoint(block);
        }
        Destroy(obj);
        parent.Hide();
    }
}
