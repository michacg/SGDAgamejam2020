﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAndHold : MonoBehaviour
{
    [SerializeField] float SpriteChangeTimer;
    [SerializeField] List<Sprite> Sprites;
    [SerializeField] List<GameObject> EndOfInteractionObjects;

    SpriteRenderer SpriteRend;

    float totalTime;
    float timer;

    bool isHolding = false;


    // Start is called before the first frame update
    void Start()
    {
        totalTime = SpriteChangeTimer * Sprites.Count;
        SpriteRend = this.GetComponent<SpriteRenderer>();
        NotInteracting();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding)
        {
            if(RoundToOneDP(timer) % SpriteChangeTimer == 0)
            {
                if (timer < totalTime)
                {
                    SpriteRend.sprite = Sprites[(int)(timer / SpriteChangeTimer)];

                    if ((int)(timer / SpriteChangeTimer) == Sprites.Count - 1)
                    {
                        foreach (GameObject g in EndOfInteractionObjects)
                        {
                            g.SetActive(true);
                        }
                    }
                }

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
        foreach (GameObject g in EndOfInteractionObjects)
        {
            g.SetActive(false);
        }
    }
}