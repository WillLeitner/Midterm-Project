using UnityEngine;
using System.Collections;

public class ArenaBehavior : MonoBehaviour
{
    public static ArenaBehavior Instance;
    public bool _wave1Over = false;
    public bool _wave2Over = false;
    public bool _wave3Over = false;
    public int _deadEnemies = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Debug.Log(_deadEnemies);
        if (_wave1Over == true)
        {
            Debug.Log("wave 1 over");
        }
        if (_wave2Over == true)
        {
            Debug.Log("wave 2 over");
        }
        if (_wave3Over == true)
        {
            Debug.Log("wave 3 over");
        }
    }
}
