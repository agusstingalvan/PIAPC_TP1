using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateManager : MonoBehaviour
{
    public TrafficLightBaseState _currentState;

    TrafficLightStateGo _stateGo = new TrafficLightStateGo();
    TrafficLightStateStop _stateStop = new TrafficLightStateStop();

    public bool visited = false;
    public bool inLastLight;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 2);
        _currentState = (randomNumber == 0)? _stateStop : _stateGo;
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
        //Is a function recursive
        int randomNumber = Random.Range(5, 3);
        yield return new WaitForSeconds(randomNumber);

        if(_currentState.type == "stop")
        {
            _currentState = _stateGo;
            _currentState.EnterState(this);
        }else if(_currentState.type == "go")
        {
            _currentState = _stateStop;
            _currentState.EnterState(this);
        }
        StartCoroutine(ChangeState());
    }
}
