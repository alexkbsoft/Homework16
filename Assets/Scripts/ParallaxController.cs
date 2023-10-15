using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _coeff;

    private Vector3 _startingPoint;

    void Start() {
        _startingPoint = transform.position;
    }

    void LateUpdate()
    {
        var delta = transform.position - _startingPoint;
        _startingPoint = transform.position;

        for (int i = 0; i < _layers.Length; i++)
        {
            _layers[i].position += delta * _coeff[i];
        }        
    }
}
