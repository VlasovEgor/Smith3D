using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Storage : MonoBehaviour, IInitializable, IDisposable
{
    private Dictionary<TypeReward, int> _dictionaryRewards = new();

    private Bag _bag;
    
    [Inject]
    private void Construct(Entity entity)
    {
        _bag = entity.GetComponentImplementing<Bag>();
    }
    
    public void Initialize()
    {
        _bag.RewardAdded += AddReward;
    }

    public void Dispose()
    {
        _bag.RewardAdded -= AddReward;
    }

    private void Start()
    {
        foreach (var reward in Enum.GetValues(typeof(TypeReward)))
        {
            _dictionaryRewards.Add((TypeReward)reward,0);
        }
    }

    private void AddReward(TypeReward type)
    {   
        _dictionaryRewards[type] += 1;
    }
}
