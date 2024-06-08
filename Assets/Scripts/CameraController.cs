using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Start()
    {
        _target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        }
    }
}
