using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{

    [SerializeField] private float maxZ = 34.949f;
    [SerializeField] private float minZ = -15.405f;

    void Update()
    {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = 1f; //The distance between the camera and object
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        // mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

        if (angle > minZ && angle < maxZ)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
         
    }
}
