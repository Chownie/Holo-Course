using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpawnerButton : MonoBehaviour, IInputClickHandler {
    [SerializeField]
    private GameObject spawn;
    private GameObject parent;

    void Start() {
        parent = GameObject.Find("Game Manager");
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        GameObject obj = Instantiate(spawn);
        ReactiveBlock block = obj.GetComponent<ReactiveBlock>();
        ConstrainedTapToPlace placer = obj.GetComponent<ConstrainedTapToPlace>();
        placer.collect = parent.GetComponent<CourseObjectCollection>();
        if (block.block == blocktype.WAYPOINT)
        {
            placer.collect.AddWaypointToChain(block);
        }
        block.collection = placer.collect;
        block.collection.objectList.Add(obj);
        placer.active = true;
        placer.IsBeingPlaced = true;
    }
}
