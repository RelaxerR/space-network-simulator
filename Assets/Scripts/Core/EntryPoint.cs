using System;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private List<SpaceObjectController> SpaceObjects;
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

        foreach (var obj in SpaceObjects)
        {
            obj.UpdateSelf(_time);
        }
    }
}
