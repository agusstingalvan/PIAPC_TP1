using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateManager : MonoBehaviour
{
    public TrafficLightBaseState _currentState;
    public TrafficLightBaseState _oldState;

    public TrafficLightWarn _stateWarn = new TrafficLightWarn();
    public TrafficLightStateStop _stateStop = new TrafficLightStateStop();
    public TrafficLightStateGo _stateGo = new TrafficLightStateGo();

    public bool visited = false;
    public bool inLastLight;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 2);
        _currentState = (randomNumber == 0) ? _stateStop : _stateGo;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            visited = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
