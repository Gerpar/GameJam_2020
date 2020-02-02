using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueController : MonoBehaviour
{
    [SerializeField] bool statueOnByDefault = false;
    bool statueIsOn;

    public bool StatueIsOn
    {
        set
        {
            statueIsOn = value;
            ToggleLights();
        }
    }

    [Header("Materials")]
    [SerializeField] Material offMat;
    [SerializeField] Material ringOnMat;
    [SerializeField] Material sphereOnMat;
    

    [Header("Central sphere properties")]
    [SerializeField] GameObject centralSphere;
    [SerializeField] Vector3 spinVelocityCentral;
    Light[] centralLights;

    [Header("Inner ring properties")]
    [SerializeField] GameObject innerRing;
    [SerializeField] Vector3 spinVelocityInner;
    Light[] innerLights;

    [Header("Middle ring properties")]
    [SerializeField] GameObject middleRing;
    [SerializeField] Vector3 spinVelocityMiddle;
    Light[] middleLights;

    [Header("Outer ring properties")]
    [SerializeField] GameObject outerRing;
    [SerializeField] Vector3 spinVelocityOuter;
    Light[] outerLights;

    Renderer[] glowingObjectRenderers = new Renderer[4];
    // Start is called before the first frame update
    void Start()
    {
        centralLights = centralSphere.GetComponentsInChildren<Light>();
        innerLights = innerRing.GetComponentsInChildren<Light>();
        middleLights = middleRing.GetComponentsInChildren<Light>();
        outerLights = outerRing.GetComponentsInChildren<Light>();

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        Renderer[] newRends = new Renderer[4];

        int i = 0;
        foreach(Renderer rend in rends)
        {
            if(rend.gameObject.CompareTag("StatueGlow"))
            {
                newRends[i] = rend;
                i++;
            }
        }

        glowingObjectRenderers = newRends;

        statueIsOn = statueOnByDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if(statueIsOn)
        {
            centralSphere.transform.Rotate(spinVelocityCentral * Time.deltaTime);
            innerRing.transform.Rotate(spinVelocityInner * Time.deltaTime);
            middleRing.transform.Rotate(spinVelocityMiddle * Time.deltaTime);
            outerRing.transform.Rotate(spinVelocityOuter * Time.deltaTime);
        }
        float lerp = Mathf.PingPong(Time.time, 2.0f) / 2.0f;

        ToggleLights();
    }

    void ToggleLights()
    {
        foreach(Light light in centralLights)
        {
            light.enabled = statueIsOn;
        }
        foreach(Light light in innerLights)
        {
            light.enabled = statueIsOn;
        }
        foreach(Light light in middleLights)
        {
            light.enabled = statueIsOn;
        }
        foreach(Light light in outerLights)
        {
            light.enabled = statueIsOn;
        }

        if (statueIsOn)
        {
            foreach (Renderer rend in glowingObjectRenderers)
            {
                if(rend.gameObject.name.Contains("CentralSphere"))
                {
                    rend.material = sphereOnMat;
                }
                else
                {
                    rend.material = ringOnMat;
                }
            }
        }
        else
        {
            foreach (Renderer rend in glowingObjectRenderers)
            {
                rend.material = offMat;
            }
        }
    }
}
