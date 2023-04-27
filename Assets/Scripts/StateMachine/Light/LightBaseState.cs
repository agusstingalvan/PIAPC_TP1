using UnityEngine;

public abstract class LightBaseState
{
    public abstract void EnterState(LightStateManager ligth);

    public abstract void UpdateState(LightStateManager ligth);

    public abstract void OnTriggerEnter(LightStateManager ligth);

    public abstract void OnTriggerExit(LightStateManager ligth);
}
