using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float CameraMoveSpeed = 5f;
    [SerializeField] float timeBetweenPanels;

    bool transitioning = false;

    public delegate void Completed();
    public static Completed FinishedMoving;

    float timer = 0;


    public void InitialFrame(Vector3 pos)
    {
        this.transform.position = new Vector3(pos.x, pos.y, this.transform.position.z);
        FinishedMoving.Invoke();
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
        float distance = Vector3.Magnitude(target - this.transform.position);
        while (Vector3.Magnitude(target - this.transform.position) > 0.05f)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target, timer / timeBetweenPanels);
            yield return null;
            timer += Time.deltaTime;
        }
        this.transform.position = target;
        transitioning = false;

        FinishedMoving.Invoke();
    }

}
