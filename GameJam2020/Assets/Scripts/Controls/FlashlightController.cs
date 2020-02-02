using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    Light light;

    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        light.enabled = !light.enabled;
        playerController.FlashLightOn = light.enabled;
    }
}
