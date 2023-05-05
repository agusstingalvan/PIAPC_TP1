using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateGo : TrafficLightBaseState
{
    public override void EnterState(TrafficLightStateManager ligth)
    {
        type = "go";
        ligth.GetComponent<Light>().color = Color.green;
        time = 0;
    }


    public override void UpdateState(TrafficLightStateManager ligth)
    {
        time += Time.deltaTime;
        if(time >= 7)
        {
            ligth._oldState = ligth._currentState;
            ligth._currentState = ligth._stateWarn;
            ligth._currentState.EnterState(ligth);
        }
    }

    public override void OnTriggerEnter(TrafficLightStateManager ligth, Collider other)
    {
       
    }
    public override void OnTriggerStay(TrafficLightStateManager ligth, Collider other)
    {

    }
    public override void OnTriggerExit(TrafficLightStateManager ligth, Collider other)
    {
        
    }
}

