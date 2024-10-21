using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private List<GameObject> _activityobjects;

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {   
            
            int spawnedInt = Random.Range(0, 2);

            if (spawnedInt == 1)
            {   
                int randomActivityObject = Random.Range(0, _activityobjects.Count);
                
                Instantiate(_activityobjects[randomActivityObject], 
                    _spawnPoints[i].transform.position, 
                    Quaternion.identity, 
                    _spawnPoints[i].transform);
            }
        }
        
    }
}
