using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.25f;

    private Vector3 _initialPositon;
    // Start is called before the first frame update
    void Start()
    {
        _initialPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z <= -10 || transform.position.x > 10)
        {
            transform.position = new Vector3(_initialPositon.x, transform.position.y, _initialPositon.z);
        }
    }
}
