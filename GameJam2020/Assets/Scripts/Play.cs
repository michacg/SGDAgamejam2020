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
    [SerializeField] GameObject food;
    [SerializeField] GameObject uiPanel;
    [SerializeField] GameObject uiButton;

    public void StartChapter()
    {
        StartCoroutine(TurnOnVendingMachine());

        StartCoroutine(Fade(true));
        StartCoroutine(Fade(false));
        uiButton.SetActive(false);
    }

    private IEnumerator TurnOnVendingMachine()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            button.GetComponent<SpriteRenderer>().color = new Color(i * 255f, i * 255f, i * 255f, 1);
            food.GetComponent<SpriteRenderer>().color = new Color(i * 255f, i * 255f, i * 255f, 1);
            yield return null;
        }
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
                uiButton.GetComponent<Image>().color = new Color(1, 1, 1, i);
                uiPanel.GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

    }
}
