//==================================================================================
//   #GGJ2020 Credits Manager Script
//
//   Author:  Denis Nguyen
//   Created: 31 January, 2020
//   Version: 1.0
//==================================================================================
// This script rolls the credits text, fades in and out an array of images to be 
// displayed during the credits sequence, as well as adds exit button functionality.
//==================================================================================
// Changelog:
//----------------------------------------------------------------------------------
// 2020.02.01 - added FadeInImage function

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public GameObject creditsText;
    public float scrollSpeed = 1.0f;                    // speed for credits text
    public UnityEngine.UI.Image[] images;               // array of images
    public float fadeSpeed = 2.0f;                      // speed for fades in/out
    public float waitTime = 5.0f;                       // time image stays on screen
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInImage());
    }

    // Update is called once per frame
    void Update()
    {
        if (creditsText.transform.position.y < (Screen.height / 2))
            creditsText.transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed);
    }

    private IEnumerator FadeInImage()
    {
        for (int i = 0; i < images.Length; i++)
        {
            // fades in image
            var tempColour = images[i].GetComponent<UnityEngine.UI.Image>().color;
            while (tempColour.a < 1.0f)
            {
                tempColour.a += Time.deltaTime * fadeSpeed;
                images[i].GetComponent<UnityEngine.UI.Image>().color = tempColour;
                yield return null;
            }

            // image stays on screen for X seconds
            yield return new WaitForSeconds(waitTime);

            // fades out image
            while (tempColour.a > 0)
            {
                tempColour.a -= Time.deltaTime * fadeSpeed;
                images[i].GetComponent<UnityEngine.UI.Image>().color = tempColour;
                yield return null;
            }
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
