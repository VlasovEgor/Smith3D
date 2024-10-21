using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SegmentsSpawner : MonoBehaviour, IInitializable , IDisposable
{
    [SerializeField] private List<GameObject> _segmentsList;

    [Space]
    [SerializeField] private float _timeBetweenSpawns;

    private SpeedObjects _speedObjects;

    private float _currentTime;
    
    private bool _gameStarted;
    private LevelManager _levelManager;

    private List<GameObject> _spawnedSegments = new();
    private List<int> _segmentIndices = new();

    private int _currentIndex;

    [Inject]
    private void Construct(SpeedObjects speedObjects, LevelManager levelManager)
    {
        _speedObjects = speedObjects;
        _levelManager = levelManager;
    }
    
    public void Initialize()
    {
        _levelManager.GameStarted += StartGame;
        _levelManager.GameEnded += EndGame;
        
        InitializeSegmentIndices();
    }

    public void Dispose()
    {
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
        if (_gameStarted == false)
        {   
            return;
        }
        
        UpdateSpawnTimer();
    }

    private void UpdateSpawnTimer()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeBetweenSpawns)
        {
            SpawnSegment();
            _currentTime = 0;
        }
    }

    private void SpawnSegment()
    {   
        if (_currentIndex >= _segmentIndices.Count)
        {
            InitializeSegmentIndices();
        }

        int randomSegmentIndex = _segmentIndices[_currentIndex];
        _currentIndex++;

        var segmentPrefabs = _segmentsList[randomSegmentIndex];

        var segment = Instantiate(segmentPrefabs, transform.position, Quaternion.identity, transform);

        IMovable movable = segment.GetComponent<IMovable>();
        movable.SetSpeed(_speedObjects.Speed);

        _spawnedSegments.Add(segment);
    }

    public void DestroySegments()
    {
        foreach (var segment in _spawnedSegments)
        {
            Destroy(segment);
        }
        
        _spawnedSegments.Clear();
    }
    
    
    private void InitializeSegmentIndices()
    {
        _segmentIndices.Clear();
        for (int i = 0; i < _segmentsList.Count; i++)
        {
            _segmentIndices.Add(i);
        }

        Shuffle(_segmentIndices);
        _currentIndex = 0;
    }
    
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
   
}
