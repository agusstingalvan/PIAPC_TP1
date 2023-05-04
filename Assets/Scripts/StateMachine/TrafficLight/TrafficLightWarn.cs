using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightWarn : TrafficLightBaseState
{
    public override void EnterState(TrafficLightStateManager ligth)
    {
        type = "warn";
        ligth.GetComponent<Light>().color = Color.yellow;
        time = 0;
    }


    public override void UpdateState(TrafficLightStateManager ligth)
    {
        time += Time.deltaTime;

        if (time >= 3 && ligth._oldState.type == "stop")
        {
            ligth._currentState = ligth._stateGo;
            ligth._currentState.EnterState(ligth);
        }

        if (time >= 3 && ligth._oldState.type == "go")
        {
            ligth._currentState = ligth._stateStop;
            ligth._currentState.EnterState(ligth);
        }
    }

    public override void OnTriggerEnter(TrafficLightStateManager ligth)
    {
    }

    public override void OnTriggerExit(TrafficLightStateManager ligth)
    {
    }
}
