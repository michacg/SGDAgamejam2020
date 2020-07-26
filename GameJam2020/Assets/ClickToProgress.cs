using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToProgress : MonoBehaviour
{
    void OnMouseDown()
    {
        TempGameManager.instance.NextPanel();
    }
}
