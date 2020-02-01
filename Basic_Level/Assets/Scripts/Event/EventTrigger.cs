using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public SquareToHole thisSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(thisSquare.squareInHole == true)
        {
            //PUT EVENT THINGS HERE
            Destroy(gameObject);
        }
    }
}
