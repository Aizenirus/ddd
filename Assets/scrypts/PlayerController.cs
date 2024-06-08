using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public static PlayerController instance;
    private float _horizontal;
    public Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField]private TextMeshProUGUI _scoreText;
    private float _topScore = 0.0f;
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        Portal();
        UpdateScore();
    }
    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _horizontal = Input.acceleration.x;
        }
        else 
        {
            if(Application.platform == RuntimePlatform.WindowsPlayer)
            {
                _horizontal = Input.GetAxisRaw("Horizontal");
            }
        }
        if (Input.acceleration.x < -0.05)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.acceleration.x > 0.05)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        _rb.velocity = new Vector2(_horizontal * 10f, _rb.velocity.y);

        if (transform.position.y - 20 > CamFollow._camTransform.position.y)
        {
            death();
        }
    }

    private void Portal()
    {
        if(transform.position.x >= 3.32f)
        {
            transform.position = new Vector3(-3.15f, transform.position.y);
        }
        else if(transform.position.x <= -3.15f)
        {
            transform.position = new Vector3(3.32f, transform.position.y);
        }
    }
    private void UpdateScore()
    {
        if(transform.position.y > _topScore && -_rb.velocity.y > 0)
        {
            _topScore = transform.position.y;
        }
        _scoreText.text = "Score " + Mathf.Round(_topScore).ToString();
    }

    private void death()
    {
        _animator.Play("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            death();
        }
        
    }
}
