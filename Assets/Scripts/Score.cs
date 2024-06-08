using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    private int bestScore;

    [SerializeField] private float scorePerUnit = 1f; // Количество очков, начисляемых за единицу расстояния
    private float previousY; // Предыдущая позиция по Y
    private float currentScore; // Текущее количество очков

    void Start()
    {
        // Сохраняем начальную позицию персонажа
        previousY = transform.position.y;
        // Загружаем лучший результат из PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
    }

    void Update()
    {
        // Получаем текущую позицию персонажа
        float currentY = transform.position.y;

        // Проверяем, если персонаж поднялся выше, чем был ранее
        if (currentY > previousY)
        {
            // Рассчитываем количество очков, которые нужно начислить
            float distanceTraveled = currentY - previousY;
            float scoreEarned = distanceTraveled * scorePerUnit;

            // Увеличиваем общее количество очков
            currentScore += scoreEarned;

            // Обновляем предыдущую позицию
            previousY = currentY;

            // Обновляем текст с отображением очков
            UpdateScoreText();

            // Если текущий счет больше лучшего, сохраняем его
            if (currentScore > bestScore)
            {
                bestScore = (int)currentScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
                UpdateBestScoreText();
            }
        }
    }


    private void UpdateScoreText()
    {
        // Обновляем текст с текущим счетом
        scoreText.text = "Score: " + (int)currentScore;
    }

    private void UpdateBestScoreText()
    {
        // Обновляем текст с лучшим результатом
        bestScoreText.text = "Best Score: " + bestScore;
    }
}