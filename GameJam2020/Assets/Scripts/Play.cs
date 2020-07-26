using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using TMPro;

public class Play : MonoBehaviour
{

    [SerializeField] GameObject fadeInObj;
    [SerializeField] GameObject button;

    public void StartChapter()
    {
        StartCoroutine(Fade(true));
        StartCoroutine(Fade(false));
    }

    private IEnumerator Fade(bool fadeIn)
    {

        if (fadeIn)
        {
            for (float i = 0; i <= 0.48; i += Time.deltaTime)
            {
                fadeInObj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                button.GetComponent<Image>().color = new Color(1, 1, 1, i);
                button.SetActive(false);
                yield return null;
            }
        }

    }
}
