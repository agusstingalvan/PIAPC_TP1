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
        time = 0;
    }


    public override void UpdateState(TrafficLightStateManager ligth)
    {
        time += Time.deltaTime;
        if (time >= 7)
        {
            //Primero guardo el estado actual que pasa a ser el viejo estado
            ligth._oldState = ligth._currentState;
            //Segundo guardo el estado actual que pasa a ser el proximo estado
            ligth._currentState = ligth._stateWarn;
            ligth._currentState.EnterState(ligth);
        }
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
