//==================================================================================
//   #GGJ2020 Title Manager Script
//
//   Author:  Denis Nguyen
//   Edit by:
//   Created: 31 January, 2020
//   Version: 1.0
//==================================================================================
// This script adds New Game and Exit button functionality.
//==================================================================================
// Changelog:
//----------------------------------------------------------------------------------
// 2020.02.01 - renamed PlayNGSound() appropriately
//            - adjusted wait time

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public AudioSource sound;
    public string loadLevel; 

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        StartCoroutine(PlayNGSound());
    }
    
    IEnumerator PlayNGSound()
    {
        if (sound != null)
            sound.Play();

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
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
