using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrimitiveSpawner : MonoBehaviour
{
    [SerializeField] private CollapsingObject _collapsingObject;
    [SerializeField] private Transform[] _transforms;
    [SerializeField] private float _timeBetweenSpawn;

    private Vector3[] _spawnPoints;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _spawnPoints = new Vector3[_transforms.Count()];
        for(int i = 0; i < _transforms.Count(); i++)
        {
            _spawnPoints[i] = _transforms[i].position;
        }
    }

    private void OnEnable()
    {
        _spawnCoroutine = StartCoroutine(SpawnObject());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
    }
    private IEnumerator SpawnObject()
    {
        var waitTime = new WaitForSeconds(_timeBetweenSpawn);
        int spawnPointNumber = 0;
        while (true)
        {
            int countSpawnPoint = _transforms.Count() - 1;
            Instantiate(_collapsingObject, _spawnPoints[spawnPointNumber], Quaternion.identity);
            spawnPointNumber = spawnPointNumber == countSpawnPoint ? 0 : spawnPointNumber + 1;
            yield return waitTime;
        }
    }
}
