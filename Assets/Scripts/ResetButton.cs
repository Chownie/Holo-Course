using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ResetButton : MonoBehaviour, IInputClickHandler {
    [SerializeField]
    private CourseObjectCollection parent;

    void Start() {
        parent = GameObject.Find("Game Manager").GetComponent<CourseObjectCollection>();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        foreach (GameObject item in parent.objectList) {
            item.GetComponent<ReactiveBlock>().Reset();
        }
    }
}
