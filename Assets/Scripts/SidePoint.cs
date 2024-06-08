using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePoint : MonoBehaviour
{
    private Camera mainCamera;
    private Transform playerTransform;
    private Vector3 playerPosition;

    void Start()
    {
        // Получаем ссылку на основную камеру и на трансформ персонажа
        mainCamera = Camera.main;
        playerTransform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // Обновляем позицию персонажа
        playerPosition = playerTransform.position;

        // Проверяем, вышел ли персонаж за пределы камеры
        CheckCameraBounds();
    }

    void CheckCameraBounds()
    {
        // Получаем размеры камеры в мировых координатах
        float cameraWidth = mainCamera.orthographicSize * 2f * mainCamera.aspect;

        // Проверяем, вышел ли персонаж за пределы камеры по горизонтали
        if (playerPosition.x < -cameraWidth / 2f)
        {
            playerPosition.x = cameraWidth / 2f;
        }
        else if (playerPosition.x > cameraWidth / 2f)
        {
            playerPosition.x = -cameraWidth / 2f;
        }


        // Обновляем позицию персонажа
        playerTransform.position = playerPosition;
    }
}
