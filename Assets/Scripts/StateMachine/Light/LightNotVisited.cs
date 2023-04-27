using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightNotVisited : LightBaseState
{

   
    public override void EnterState(LightStateManager ligth)
    {
        
    }


    public override void UpdateState(LightStateManager ligth)
    {

    }

    public override void OnTriggerEnter(LightStateManager ligth)
    {
        ligth.GetComponent<Light>().color = Color.green;

    }

    public override void OnTriggerExit(LightStateManager ligth)
    {

    }
}
