using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    private bool isPaused = false;

    void Start()
    {
        // Подключаем метод TogglePause к событию клика на кнопке паузы
        pauseButton.onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        // Изменяем состояние паузы
        isPaused = !isPaused;

        // Если игра на паузе, устанавливаем время на ноль и останавливаем физику
        if (isPaused)
        {
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
        }
        // Если игра возобновляется, устанавливаем время обратно на 1 и возобновляем физику
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}