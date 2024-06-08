using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private GameObject _back02;
    [SerializeField] private GameObject _back03;

    private Rigidbody2D _rigidbody2D_back02;
    private Rigidbody2D _rigidbody2D_back03;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D_back02 = _back02.GetComponent<Rigidbody2D>();
        _rigidbody2D_back03 = _back03.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_rigidbody2D_back02.position.x < 1.537f)
        {
            _rigidbody2D_back02.velocity = new Vector3(0.5f, 0);
        }
        else 
        {
            _rigidbody2D_back02.velocity = new Vector3(-0.5f, 0);
        }
       
        
        
    }
    private void FixedUpdate()
    {
        if (_rigidbody2D_back02.position.x < 1.537f)
        {

        }
        else
        {
            _rigidbody2D_back03.velocity = new Vector3(-1f, 0);
        }
    }
}
