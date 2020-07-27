using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float CameraMoveSpeed = 5f;

    bool transitioning = false;

    private void Start()
    {
        this.transform.position = new Vector3(0, 0, -10);
    }

    public void MoveCameraToNextPanel(Vector3 pos)
    {
        if (!transitioning)
        {
            StartCoroutine(MoveCamera(pos));
        }
    }

    IEnumerator MoveCamera(Vector3 pos)
    {
        transitioning = true;
        Vector3 target = new Vector3(pos.x, pos.y, this.transform.position.z);
        float distance = target.x - this.transform.position.x;
        while (target.x - this.transform.position.x > 0.1f)
        {
            this.transform.Translate(Vector2.right * CameraMoveSpeed * Time.deltaTime);
            yield return null;
        }
        this.transform.position = target;
        transitioning = false;
    }

}
