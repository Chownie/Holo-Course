using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CourseObjectCollection : MonoBehaviour
{
    private GameObject selectedObject = null;

    // ONLY FOR WAYPOINTS {
    private LineRenderer beam;
    // }
    private List<ReactiveBlock> waypointList = new List<ReactiveBlock>();

    public List<GameObject> objectList = new List<GameObject>();

    public void Start()
    {
        beam = GetComponent<LineRenderer>();
    }

    public ReactiveBlock GetPrevious(ReactiveBlock current)
    {
        int index = waypointList.IndexOf(current);
        if(index == 0)
        {
            return current;
        } else
        {
            return waypointList[index - 1];
        }
    }

    public ReactiveBlock GetNext(ReactiveBlock current)
    {
        int index = waypointList.IndexOf(current);
        if (index == waypointList.Count)
        {
            return current;
        }
        else
        {
            return waypointList[index + 1];
        }
    }

    public void AddWaypointToChain(ReactiveBlock bl)
    {
        waypointList.Add(bl);
        FixWaypointChain();
    }

    public void RemoveWaypoint(ReactiveBlock bl)
    {
        waypointList.Remove(bl);
        FixWaypointChain();
    }

    public void FixWaypointChain()
    {
        beam.SetVertexCount(waypointList.Count);
        int count = 0;
        foreach (var waypoint in waypointList)
        {
            beam.SetPosition(count, waypoint.transform.position);
            count++;
        }
    }

    public void Clear() {
        waypointList.Clear();
        objectList.Clear();
        selectedObject = null;
        FixWaypointChain();
    }

    public GameObject GetSelectedObject()
    {
        GameObject output = this.selectedObject;
        this.selectedObject = null;
        return output;
    }

    public void SetSelectedObject(GameObject selection)
    {
        selectedObject = selection;
    }
}
