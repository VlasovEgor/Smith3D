using UnityEngine;

[CreateAssetMenu(fileName = "SpeedObjects", menuName = "GameEditor/SpeedObjects")]
public class SpeedObjects : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}
