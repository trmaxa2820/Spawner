using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingObject : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    private void OnEnable()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
