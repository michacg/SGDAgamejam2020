using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToProgress : MonoBehaviour
{
    void OnMouseDown()
    {
        ChapterManager.instance.NextPanel();
    }
}
