using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] float FadeSpeed;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color col = sr.color;
        col.a = 0;
        while(col.a < 1f)
        {
            sr.color = col;
            col.a += Time.deltaTime * FadeSpeed;
            yield return null;
        }
    }
}
