using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrafficLightStateStop : TrafficLightBaseState
{
    public override void EnterState(TrafficLightStateManager ligth)
    {
        type = "stop";
        ligth.GetComponent<Light>().color = Color.red;

    }


    public override void UpdateState(TrafficLightStateManager ligth)
    {
    }

    public override void OnTriggerEnter(TrafficLightStateManager ligth)
    {
        ligth.GetComponent<Light>().color = Color.red;
    }

    public override void OnTriggerExit(TrafficLightStateManager ligth)
    {
        ligth.GetComponent<Light>().color = Color.green;
    }
}
