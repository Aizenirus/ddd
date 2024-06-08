using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    public static Transform _camTransform;
    // Update is called once per frame
    private void Start()
    {
        _camTransform = transform;
    }
    private void Update()
    {
        if(_playerPos.position.y-2 > transform.position.y )
        {
            transform.position = new Vector3(transform.position.x, _playerPos.position.y-2, transform.position.z);
        }
    }
}
