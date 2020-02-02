using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{

    public GameObject LeftDoor;
    public GameObject RightDoor;
    public bool doorIsOpening;

    public GameObject pauseMenuUI;

    public static bool GameIsPaused = false;

    public string levelLoad;
    public int waitTime = 20;

    private int timer;

    // Update is called once per frame

    private void Start()
    {
        timer = 0;

    }
    void Update()
    {

        if(doorIsOpening == true) // If the bool is true, then open the door...
        {
            Resume();
            LeftDoor.transform.Translate(Vector2.left * Time.deltaTime * 50);
            RightDoor.transform.Translate(Vector2.right * Time.deltaTime * 50);

            timer++;
            Debug.Log(timer);

        }
        if(timer > waitTime) // If the Y of the door is > 7 we want to stop the door
        {

            doorIsOpening = false;
            SceneManager.LoadScene(levelLoad);
        }

        
    }

    void OnMouseDown() // This function will detect the mouse click on a cllider, in our case it will detect the click on the button
    {

        doorIsOpening = true; // If we click on the button door must start to open....
         
    }
    
    public void DoorIsOpen()
    {
        doorIsOpening = true;
    }

    public void Resume() // Resume Function
    {

        pauseMenuUI.SetActive(false); // Set the pause menu to false
        //Time.timeScale = 1f; // Unfreeze the background
        //GameIsPaused = false; // Game is not paused

        //SceneManager.LoadScene(1);

    }

 
}
