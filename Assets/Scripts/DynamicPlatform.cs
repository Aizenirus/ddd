using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DynamicPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float distanceToMove = 3f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    [SerializeField] private bool isMovingRight = true;
    void Start()
    {
        // Инициализируем начальную и конечную точки движения
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(distanceToMove, 0f, 0f);
    }

    void Update()
    {
        // Перемещаем объект
        MoveObject();
    }

    void MoveObject()
    {
        // Проверяем, достиг ли объект конечной точки
        if (isMovingRight && transform.position.x >= endPosition.x)
        {
            isMovingRight = false;
        }
        else if (!isMovingRight && transform.position.x <= startPosition.x)
        {
            isMovingRight = true;
        }

        // Перемещаем объект
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}