using UnityEngine;

public abstract class TrafficLightBaseState 
{
    public string type = "";
    public float time = 0f;
    public abstract void EnterState(TrafficLightStateManager ligth);

    public abstract void UpdateState(TrafficLightStateManager ligth);

    public abstract void OnTriggerEnter(TrafficLightStateManager ligth, Collider other);

    public abstract void OnTriggerStay(TrafficLightStateManager ligth, Collider other);
    public abstract void OnTriggerExit(TrafficLightStateManager ligth, Collider other);
}
