using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UIScore : MonoBehaviour, IInitializable, IDisposable
{
    private Bag _bag;
    
    [SerializeField]
    private TextMeshProUGUI _diamondScoreText;
    
    [Space]
    [SerializeField]
    private TextMeshProUGUI _emiralScoreText;
    
    [Space]
    [SerializeField]
    private TextMeshProUGUI _topasScoreText;

    [Space]
    [SerializeField]
    private TextMeshProUGUI _ScoreText;
    

    private Score _score;
    
    [Inject]
    public void Construct(Score score)
    {
        _score = score;
    }
    
    public void Initialize()
    {
        _score.RewardChanged += ChangeReward;
        _score.ScoreChanged += ChangeScore;
    }
    
    public void Dispose()
    {
        _score.RewardChanged -= ChangeReward;
        _score.ScoreChanged += ChangeScore;
    }

    private void ChangeReward(TypeReward type, int amount)
    {
        switch (type)
        {
            case TypeReward.DIAMOND:
                _diamondScoreText.text = amount.ToString();
                
                break;
            case TypeReward.EMIRAL:
                _emiralScoreText.text = amount.ToString();
                break;
            case TypeReward.TOPAS:
                _topasScoreText.text = amount.ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
    
    private void ChangeScore(int currentScore)
    {
        _ScoreText.text = "Score: " + currentScore;
    }


    
}
