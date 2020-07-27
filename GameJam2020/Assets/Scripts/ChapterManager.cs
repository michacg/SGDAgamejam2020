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
    }

    void Start()
    {
        cam = Camera.main.gameObject.GetComponent<CameraMovement>();
        Panels[index].SetActive(true);
    }

    public void NextPanel()
    {
        cam.MoveCameraToNextPanel(Panels[++index].transform.position);
    }

}
