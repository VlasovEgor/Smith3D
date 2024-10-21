using System;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour, IInitializable, IDisposable
{
   public event Action GameStarted;
   public event Action GameEnded;

   [SerializeField] private Score _score;
   
   private Menu _menu;
   private ResurrectionUI _resurrectionUI;
   private bool _levelIsRunning;
   private bool _screenIsTapped;
   private Resurection _resurection;
   private SegmentsSpawner _segmentsSpawner;
   private Visual _playerViusal;

   private IDamageable _playerDamageable;

   private float _timeScale;
   
   [Inject]
   private void Construct(Menu menu, Entity entity, ResurrectionUI resurrectionUI, SegmentsSpawner segmentsSpawner)
   {
      _menu = menu;
      _playerDamageable = entity.GetComponentImplementing<IDamageable>();
      _resurrectionUI = resurrectionUI;
      _resurection = entity.GetComponentImplementing<Resurection>();
      _segmentsSpawner = segmentsSpawner;
      _playerViusal = entity.GetComponentImplementing<Visual>();
   }

   public void Initialize()
   {
      _menu.LevelOpened += StartLevel;
      _playerDamageable.PlayerDied += StopGame;

      _timeScale = Time.timeScale;
   }

   public void Dispose()
   {
      _menu.LevelOpened -= StartLevel;
      _playerDamageable.PlayerDied -= StopGame;
   }
   
   private void StartLevel()
   {  
      _playerViusal.gameObject.SetActive(true);
      _levelIsRunning = true;
   }
   
   private void Update()
   {
      CheckingTapToScreen();
   }
   
   private void CheckingTapToScreen()
   {
      if (!_levelIsRunning)
      {
         return;
      }
      
      if (Input.GetMouseButtonDown(0) && !_screenIsTapped)
      {
         
         _screenIsTapped = true;
         GameStarted?.Invoke();
      }
   }

   private void StopGame()
   {
      Time.timeScale = 0;
      _resurrectionUI.gameObject.SetActive(true);
   }

   private void StartGame()
   {
      throw new NotImplementedException();
   }

   public void ResetGame()
   {  
      Time.timeScale = _timeScale; 
      
      _score.ResetReward();
      _score.ResetScore();
      _resurection.ResurectPlayer();
      _segmentsSpawner.DestroySegments();

      _levelIsRunning = false;
      _screenIsTapped = false;
      
      GameEnded?.Invoke();
   }

   public void ResumeGame()
   {
      Time.timeScale = _timeScale;
      _resurection.RestoreHealth();
   }
}
