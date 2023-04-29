using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateManager : MonoBehaviour
{
    public TrafficLightBaseState _currentState;
    public TrafficLightBaseState _oldState;

    TrafficLightWarn _stateWarn = new TrafficLightWarn();
    TrafficLightStateStop _stateStop = new TrafficLightStateStop();
    TrafficLightStateGo _stateGo = new TrafficLightStateGo();

    public bool visited = false;
    public bool inLastLight;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 2);
        _currentState = (randomNumber == 0) ? _stateStop : _stateGo;
        _currentState.EnterState(this);
        StartCoroutine(ChangeState());
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

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(7);
        while (true)
        {
            if (_currentState == _stateStop || _currentState == _stateGo)
            {
                _oldState = _currentState;
                _currentState = _stateWarn;
                _currentState.EnterState(this);
                yield return new WaitForSeconds(3);
            }
            else if (_currentState == _stateWarn && _oldState == _stateStop)
            {
                _oldState = _currentState;
                _currentState = _stateGo;
                _currentState.EnterState(this);
                yield return new WaitForSeconds(7);
            }
            else if (_currentState == _stateWarn && _oldState == _stateGo)
            {
                _oldState = _currentState;
                _currentState = _stateStop;
                _currentState.EnterState(this);
                yield return new WaitForSeconds(7);
            }
        }
    }
}
