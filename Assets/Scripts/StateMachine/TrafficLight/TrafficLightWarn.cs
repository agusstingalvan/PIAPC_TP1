using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightWarn : TrafficLightBaseState
{
    public override void EnterState(TrafficLightStateManager ligth)
    {
        type = "warn";
        ligth.GetComponent<Light>().color = Color.yellow;
    }


    public override void UpdateState(TrafficLightStateManager ligth)
    {
    }

    public override void OnTriggerEnter(TrafficLightStateManager ligth)
    {
    }

    public override void OnTriggerExit(TrafficLightStateManager ligth)
    {
    }
}
