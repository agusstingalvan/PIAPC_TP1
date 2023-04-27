using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStateManager : MonoBehaviour
{
    public LightBaseState _currentState;

    LightVisited _lightVisited = new LightVisited();
    LightNotVisited _lightNotVisited = new LightNotVisited();

    public bool visited = false;
    void Start()
    {
        _currentState = _lightNotVisited;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            visited = true;
            _currentState.OnTriggerEnter(this);
            _currentState = _lightVisited;
         }

    }

    private void OnTriggerExit(Collider other)
    {
        _currentState.OnTriggerExit(this);

    }

}
