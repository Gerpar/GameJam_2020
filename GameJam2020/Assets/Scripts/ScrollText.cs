using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < (Screen.height / 2))
            transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed);
    }
}
