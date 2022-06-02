using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPosition;
    public List<Draggable> draggableObject;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Draggable draggable in draggableObject)
        {
            draggable.dragEndCallBack = OnDragEnded;
        }
    }

    private void OnDragEnded(Draggable draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPosition)
        {
            float currentDistance = Vector2.Distance(draggable.transform.position, snapPoint.position);
            if(closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.position = closestSnapPoint.position;
        }
    }
}
