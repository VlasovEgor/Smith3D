
using System;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour, IInitializable, IDisposable
{
    public event Action<int> ScoreChanged;
    public event Action<TypeReward, int> RewardChanged;
    
    private Bag _bag;
    private ValueRewards _valueRewards;
    private LevelManager _levelManager;
    
    private int _diamondScore;
    private int _emiralcore;
    private int _topasScore;
    
    [Space]
    [SerializeField] private int _scorePerSecond;

    private int _score;
    private float _timeSinceLastUpdate;
    
    private bool _gameStarted;
    
    [Inject]
    public void Construct(Entity entity, ValueRewards valueRewards, LevelManager levelManager)
    {
        _bag = entity.GetComponentImplementing<Bag>();
        _valueRewards = valueRewards;
        _levelManager = levelManager;
    }
    
    public void Initialize()
    {
        _bag.RewardAdded += AddReward;
        _levelManager.GameStarted += StartGame;
        _levelManager.GameEnded += EndGame;
    }
    
    public void Dispose()
    {
        _bag.RewardAdded -= AddReward;
        _levelManager.GameStarted -= StartGame;
        _levelManager.GameEnded -= EndGame;
    }

    private void StartGame()
    {
        _gameStarted = true;
    }
    
    private void EndGame()
    {
        _gameStarted = false;
    }

    private void Update()
    {   
        if (!_gameStarted)
        {
            return;
        }
        
        AddScore();
    }

    private void AddScore()
    {
        _timeSinceLastUpdate += Time.deltaTime;
        
        int pointsToAdd = Mathf.FloorToInt(_timeSinceLastUpdate * _scorePerSecond);
        
        _score += pointsToAdd;
        
        ScoreChanged.Invoke(_score);
        
        _timeSinceLastUpdate -= pointsToAdd / (float)_scorePerSecond;
    }

    private void AddReward(TypeReward type)
    {
        switch (type)
        {
            case TypeReward.DIAMOND:
                _diamondScore++;
               RewardChanged?.Invoke(TypeReward.DIAMOND,_diamondScore);
                break;
            case TypeReward.EMIRAL:
                _emiralcore++;
                RewardChanged?.Invoke(TypeReward.EMIRAL,_emiralcore);
                break;
            case TypeReward.TOPAS:
                _topasScore++;
                RewardChanged?.Invoke(TypeReward.TOPAS,_topasScore);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        Debug.Log(_valueRewards.Value);
        _score += _valueRewards.Value[type];
        ScoreChanged.Invoke(_score);
    }

    public void ResetReward()
    {
        _diamondScore = 0;
        _emiralcore = 0;
        _topasScore = 0;
        
        RewardChanged?.Invoke(TypeReward.DIAMOND,_diamondScore);
        RewardChanged?.Invoke(TypeReward.EMIRAL,_emiralcore);
        RewardChanged?.Invoke(TypeReward.TOPAS,_topasScore);

    }

    public void ResetScore()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
