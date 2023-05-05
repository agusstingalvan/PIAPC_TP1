using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.25f;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
        if (transform.position.z <= -10 || transform.position.x > 10 || transform.position.z > 108f)
        {
            transform.position = new Vector3(_initialPosition.x, transform.position.y, _initialPosition.z);
            transform.rotation = _initialRotation;
        }
    }
}
