using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateGo : TrafficLightBaseState
{
    public override void EnterState(TrafficLightStateManager ligth)
    {
        type = "go";
        ligth.GetComponent<Light>().color = Color.green;
    }


    public override void UpdateState(TrafficLightStateManager ligth)
    {

    }

    public override void OnTriggerEnter(TrafficLightStateManager ligth)
    {
        ligth.GetComponent<Light>().color = Color.green;
    }

    public override void OnTriggerExit(TrafficLightStateManager ligth)
    {
        ligth.GetComponent<Light>().color = Color.red;
    }
}

