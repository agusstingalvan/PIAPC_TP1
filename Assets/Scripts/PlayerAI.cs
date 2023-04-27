using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    private string _targetName;
    private string _status;

    [SerializeField] private GameObject[] _target;
    //[SerializeField] private GameObject _nextPointObject;


    TrafficLightStateManager _tlsmanager;

    [SerializeField] TMPro.TextMeshProUGUI _flText;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Transform>();
        
        //States Managers
        _tlsmanager = new TrafficLightStateManager();

        if(GetComponent<PlayerStateManager>() != null)
        {
           _status = GetComponent<PlayerStateManager>().statusPlayer;
        }
    }

    void Update()
    {
        
        foreach (GameObject light in _target)
        {
            if (light.GetComponentInChildren<TrafficLightStateManager>())
            {
                _agent.SetDestination(light.transform.position);
                
            }
        }
        if (_status != null)
        {
            _status = GetComponent<PlayerStateManager>().statusPlayer;
            _flText.text = _status;
        }
    }
    

    private void FuzzyLogic(Transform _targetPos, Transform _playerPos)
    {
        float distance = (_targetPos.position - _playerPos.position).magnitude;

        //Debug.Log(distance);

        if (distance >= 40)
        {
            _flText.text = _targetName + " lejos!";
        }
        if (distance < 45 && distance >= 30)
        {
            _flText.text = _targetName + " menos lejos..";
        }
        if (distance < 30 && distance >= 25)
        {
            _flText.text = _targetName + " cerca..";
        }
        if (distance < 25 && distance >= 20)
        {
            _flText.text = _targetName + " mas cerca..";
        }
        if (distance < 20 && distance >= 0)
        {
            _flText.text = _targetName + " llegué..";
        }
    }


    
}
