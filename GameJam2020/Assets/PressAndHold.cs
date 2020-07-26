using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAndHold : MonoBehaviour
{
    [SerializeField] float SpriteChangeTimer;
    [SerializeField] List<Sprite> Sprites;

    SpriteRenderer SpriteRend;

    float totalTime;
    float timer;

    bool isHolding = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(RoundToOneDP(0.25f));   
        timer = 0;
        totalTime = SpriteChangeTimer * Sprites.Count;
        SpriteRend = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding)
        {
            if(RoundToOneDP(timer) % SpriteChangeTimer == 0)
            {
                if(timer < totalTime)
                    SpriteRend.sprite = Sprites[(int)(timer / SpriteChangeTimer)];
            }

            timer += Time.deltaTime;

        }
    }

    float RoundToOneDP(float num)
    {
        return (int)(num * 10) / 10f;
    }

    private void OnMouseDown()
    {
        Debug.Log("Holding down");
        isHolding = true;
    }

    private void OnMouseUp()
    {
        NotInteracting();
    }

    private void OnMouseExit()
    {
        NotInteracting();
    }

    void NotInteracting()
    {
        Debug.Log("Not interacting");
        isHolding = false;
        timer = 0f;
        SpriteRend.sprite = Sprites[0];
    }
}
