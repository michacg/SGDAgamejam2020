using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager instance = null;

    [SerializeField] GameObject[] Panels;

    CameraMovement cam;

    int index = 0;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
        CameraMovement.FinishedMoving += ActivateNextPanel;
    }

    void Start()
    {
        cam = Camera.main.gameObject.GetComponent<CameraMovement>();
        cam.InitialFrame(Panels[index].transform.position);
    }

    public void NextPanel()
    {
        cam.MoveCameraToNextPanel(Panels[++index].transform.position);
    }

    void ActivateNextPanel()
    {
        Debug.Log("Activating");
        Panels[index].GetComponent<Panel>().Activate();
    }

}
