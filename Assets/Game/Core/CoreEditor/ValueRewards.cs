
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ValueRewards", menuName = "GameEditor/ValueRewards")]
public class ValueRewards : SerializedScriptableObject
{
    [SerializeField]
    public Dictionary<TypeReward, int> Value = new();
}
