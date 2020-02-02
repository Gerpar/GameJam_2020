using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndVolume : MonoBehaviour
{
    [SerializeField] GameObject lastPuzzle;

    PuzzleFinalCheck puzzleScript;
    // Start is called before the first frame update
    void Start()
    {
        puzzleScript = lastPuzzle.GetComponent<PuzzleFinalCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && puzzleScript.puzzleDone)
        {
            SceneManager.LoadScene(1);
        }
    }
}
