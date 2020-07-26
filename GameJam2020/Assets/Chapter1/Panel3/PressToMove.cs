using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToMove : MonoBehaviour
{
    [SerializeField] GameObject MainCharacter;
    [SerializeField] List<GameObject> EndOfInteractionObjects;
    [SerializeField] float TargetX;
    [SerializeField] float MaxYIncrease;

    bool isHolding = false;
    bool StopWalking = false;

    float OrigX;
    float OrigY;

    float yDir = 1;

    // Start is called before the first frame update
    void Start()
    {
        HideAllEndObjects();
        OrigY = MainCharacter.transform.position.y;
        OrigX = MainCharacter.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding && !StopWalking)
        {
            if(MainCharacter.transform.position.x < TargetX)
            {
                MainCharacter.transform.Translate(Vector2.right * Time.deltaTime * (TargetX - OrigX) /2);

                if(MainCharacter.transform.position.y > OrigY + MaxYIncrease || MainCharacter.transform.position.y < OrigY)
                {
                    yDir = -1 * yDir;
                }

                MainCharacter.transform.Translate(Vector2.up * Time.deltaTime * (MaxYIncrease + OrigY) * yDir / 2);
            }
            else
            {
                StopWalking = true;
                foreach(GameObject g in EndOfInteractionObjects)
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
}
