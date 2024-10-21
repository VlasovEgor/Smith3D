using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public event Action<TypeReward> RewardAdded;
    
    public void AddReward(TypeReward type)
    {   
       RewardAdded?.Invoke(type);
    }
}
