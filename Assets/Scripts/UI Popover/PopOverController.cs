using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOverController : MonoBehaviour {
    private GameObject Selected;
    private GameObject cam;

    void Start() {
        cam = GameObject.Find("MixedRealityCamera");
    }

    public GameObject GetSelected() {
        return Selected;
    }

    public void Select(GameObject target) {
        Selected = target;
        transform.position = target.transform.position;
        transform.Translate(Vector3.up * 1);
    }

    public void Hide() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        Destroy(this);
    }

	// Update is called once per frame
	void Update () {
		if(Selected != null) {
            Vector3 direction = transform.position - cam.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
	}
}
