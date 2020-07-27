using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToMove : MonoBehaviour, Panel
{
    [SerializeField] GameObject MainCharacter;
    [SerializeField] List<GameObject> EndOfInteractionObjects;
    [SerializeField] float xDistance;
    [SerializeField] float MaxYIncrease;

    bool isHolding = false;
    bool StopWalking = false;
    bool OnPanel;

    float OrigX;
    float OrigY;

    float yDir = 1;

    // Start is called before the first frame update
    void Awake()
    {
        HideAllEndObjects();
        OrigY = MainCharacter.transform.position.y;
        OrigX = MainCharacter.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding && !StopWalking && OnPanel)
        {
            if(MainCharacter.transform.position.x  - OrigX < xDistance)
            {
                MainCharacter.transform.Translate(Vector2.right * Time.deltaTime * xDistance /2);

                if(MainCharacter.transform.position.y > OrigY + MaxYIncrease || MainCharacter.transform.position.y < OrigY)
                {
                    yDir = -1 * yDir;
                }

                MainCharacter.transform.Translate(Vector2.up * Time.deltaTime * yDir);
            }
            else
            {
                StopWalking = true;
                foreach (GameObject g in EndOfInteractionObjects)
                {
                    g.SetActive(true);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Holding down");
        isHolding = true;
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }

    void HideAllEndObjects()
    {
        foreach(GameObject g in EndOfInteractionObjects)
        {
            g.SetActive(false);
        }
    }

    public void Activate()
    {
        OnPanel = true;
    }
}
