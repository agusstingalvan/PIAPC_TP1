using UnityEngine;

public abstract class TrafficLightBaseState 
{
    public string type = "";

    public abstract void EnterState(TrafficLightStateManager ligth);

    public abstract void UpdateState(TrafficLightStateManager ligth);

    public abstract void OnTriggerEnter(TrafficLightStateManager ligth);

    public abstract void OnTriggerExit(TrafficLightStateManager ligth);
}
