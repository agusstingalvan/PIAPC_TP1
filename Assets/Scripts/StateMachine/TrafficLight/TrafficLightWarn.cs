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

        //Cuando el tiempo es mayor o igual que 3 y el estado anteriror era stop, pasa a GO
        if (time >= 3 && ligth._oldState.type == "stop")
        {
            //Estado de la luz
            ligth._currentState = ligth._stateGo;
            ligth._currentState.EnterState(ligth);
        }

        //Cuando el tiempo es mayor o igual que 3 y el estado anteriror era go, pasa a STOP
        if (time >= 3 && ligth._oldState.type == "go")
        {
            ligth._currentState = ligth._stateStop;
            ligth._currentState.EnterState(ligth);
        }
        
    }

    public override void OnTriggerEnter(TrafficLightStateManager ligth, Collider other)
    {
    }
    public override void OnTriggerStay(TrafficLightStateManager ligth, Collider other)
    {
        //Si esta en el trigger de la semaforo en rojo, actualiza el estado del vehiculo a REVISANDO.
        other.GetComponent<PlayerStateManager>()._currentState = other.GetComponent<PlayerStateManager>()._stateReviewing;
        other.GetComponent<PlayerStateManager>()._currentState.EnterState(other.GetComponent<PlayerStateManager>());
    }

    public override void OnTriggerExit(TrafficLightStateManager ligth, Collider other)
    {
      
    }
}
