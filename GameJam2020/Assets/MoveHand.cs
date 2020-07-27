using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    [SerializeField] private float handSpeed = 2f;
    [SerializeField] private float maxZ = 34.949f;
    [SerializeField] private float minZ = -15.405f;
    [SerializeField]    private float rotZ;
    

    private void Awake()
    {
        rotZ = transform.rotation.z;
    }

    void Update()
    {
        rotZ -= Input.GetAxis("Mouse X");


        if (rotZ >= maxZ) rotZ = maxZ;
        if (rotZ <= minZ) rotZ = minZ;

        
        transform.Rotate(new Vector3(0, 0, rotZ) * Time.deltaTime * handSpeed);
    }
}
