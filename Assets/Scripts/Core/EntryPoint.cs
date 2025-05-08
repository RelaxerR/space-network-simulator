using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GlobalSettings _globalSettings;
    private float _time;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _time += _globalSettings.TimeStep;
    }
}
