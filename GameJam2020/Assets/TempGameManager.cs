using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempGameManager : MonoBehaviour
{
    public static TempGameManager instance = null;

    [SerializeField] GameObject[] Panels;

    int index = 0;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach(GameObject p in Panels)
        {
            p.SetActive(false);
        }

        Panels[index].SetActive(true);
    }

    public void NextPanel()
    {
        Panels[index].SetActive(false);
        index += 1;
        Panels[index].SetActive(true);
    }
}
