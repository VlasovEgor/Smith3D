using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public event Action LevelOpened;
    
    [SerializeField] private GameButton gameButton;
    [SerializeField] private GameObject _gameUI;

    private void Start()
    {
        gameButton.AddListener(OpenLevel);
    }

    private void OnDestroy()
    {
        gameButton.RemoveListener(OpenLevel);
    }

    private void OpenLevel()
    {
        gameObject.SetActive(false);
        _gameUI.SetActive(true);
        
        LevelOpened?.Invoke();
    }
}
