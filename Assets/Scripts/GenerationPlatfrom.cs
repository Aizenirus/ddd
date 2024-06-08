using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationPlatfrom : MonoBehaviour
{
    [SerializeField] private GameObject[] platfomPrefabs; // Массив префабов платформ
    [SerializeField] private GameObject deadZone; // Ссылка на объект DeadZone
    [SerializeField] private int numPlatforms = 10; // Количество платформ
    [SerializeField] private float minDistanceY = 2f; // Минимальное расстояние между платформами по y
    [SerializeField] private float xMinLimit = -1.7f; // Минимальное значение по x
    [SerializeField] private float xMaxLimit = 1.7f; // Максимальное значение по x

    private List<GameObject> generatedPlatforms = new List<GameObject>(); // Список сгенерированных платформ
    private float currentY = 0f; // Текущее положение по y

    void Start()
    {
        GeneratePlatforms();
    }

    void Update()
    {
        CheckPlatformCollisions();
    }

    void GeneratePlatforms()
    {
        for (int i = 0; i < numPlatforms; i++)
        {
            GameObject newPlatform = Instantiate(platfomPrefabs[Random.Range(0, platfomPrefabs.Length)], Vector3.zero, Quaternion.identity);
            bool platformPlaced = false;

            int attempts = 0;
            while (!platformPlaced && attempts < 10)
            {
                float xPosition = Random.Range(xMinLimit, xMaxLimit);
                float yPosition = currentY + Random.Range(minDistanceY, minDistanceY * 2);
                Vector3 position = new Vector3(xPosition, yPosition, 0f);
                bool overlaps = false;

                // Проверяем, не пересекается ли новая платформа с уже существующими
                foreach (GameObject platform in generatedPlatforms)
                {
                    if (Vector3.Distance(position, platform.transform.position) < minDistanceY)
                    {
                        overlaps = true;
                        break;
                    }
                }

                if (!overlaps)
                {
                    newPlatform.transform.position = position;
                    generatedPlatforms.Add(newPlatform);
                    currentY = yPosition;
                    platformPlaced = true;
                }

                attempts++;
            }

            if (!platformPlaced)
            {
                Destroy(newPlatform);
            }
        }
    }

    void CheckPlatformCollisions()
    {
        List<GameObject> platformsToRemove = new List<GameObject>();

        // Проверяем столкновения с DeadZone
        foreach (GameObject platform in generatedPlatforms)
        {
            if (platform.transform.position.y < deadZone.transform.position.y)
            {
                platformsToRemove.Add(platform);
            }
        }

        // Удаляем платформы, которые попали в DeadZone
        foreach (GameObject platform in platformsToRemove)
        {
            generatedPlatforms.Remove(platform);
            Destroy(platform);
        }

        // Генерируем новые платформы сверху
        GeneratePlatforms();
    }
}
