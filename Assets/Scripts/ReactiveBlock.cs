using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum blocktype
{
    OBSTACLE,
    WAYPOINT,
    GOAL
}

[RequireComponent(typeof(Collider))]
public class ReactiveBlock : MonoBehaviour
{
    Collider cd;
    Renderer rd;
    public blocktype block;

    public AudioClip Waypoint;
    public AudioClip Obstacle;
    public CourseObjectCollection collection;

    private bool active = true;

    // Use this for initialization
    void Start()
    {
        cd = GetComponent<Collider>();
        cd.isTrigger = true;
        rd = GetComponent<Renderer>();

        if(block == blocktype.WAYPOINT && collection.GetPrevious(this) != this)
        {
            Deactivate();
        }
    }

    public void Activate() {
        this.active = true;
    }

    public void Deactivate() {
        this.active = false;
    }

    public void Reset() {
        Color newCol = new Color();
        ColorUtility.TryParseHtmlString("#FFFFFF40", out newCol);
        rd.material.color = newCol;
    }

    void OnTriggerEnter(Collider other) {
        if(!active) {
            return;
        }
        if (other.tag == "MainCamera") {
            switch (block)
            {
                case blocktype.GOAL:
                    Debug.Log("You did it!");
                    break;
                case blocktype.OBSTACLE:
                    other.GetComponent<AudioSource>().PlayOneShot(this.Obstacle, 1.0f);
                    rd.material.color = Color.red;
                    break;
                case blocktype.WAYPOINT:
                    other.GetComponent<AudioSource>().PlayOneShot(this.Waypoint, 1.0f);
                    rd.material.color = Color.blue;
                    ReactiveBlock nextBlock = collection.GetNext(this);
                    if(nextBlock != this && nextBlock != null)
                    {
                        nextBlock.Activate();
                    }
                    break;
            }
            Deactivate();
        }
    }
}
