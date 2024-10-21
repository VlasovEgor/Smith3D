using System;
using UnityEngine;
using Zenject;

public class ResurrectionUI : MonoBehaviour
{
    [SerializeField] private GameButton _adsButton;
    [SerializeField] private GameButton _menuButton;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _ads;

    private LevelManager _levelManager;
    
    [Inject]
    private void Construct(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    
    private void Start()
    {
        _adsButton.AddListener(EnableAds);
        _menuButton.AddListener(OpenMenu);
    }

    private void OnDestroy()
    {
        _adsButton.RemoveListener(EnableAds);
        _menuButton.AddListener(OpenMenu);
    }
    
    private void EnableAds()
    {
        _ads.SetActive(true);
    }
    
    private void OpenMenu()
    {
        gameObject.SetActive(false);
        _menu.SetActive(true);
        _levelManager.ResetGame();
    }

    public void ResumeGame()
    {
        _levelManager.ResumeGame();
    }
}
