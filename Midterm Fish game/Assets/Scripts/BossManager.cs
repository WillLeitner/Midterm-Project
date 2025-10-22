using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance;
    public bool _stunPhase = false;
    public bool _bossOver = false;
    public int _bossHealth = 20;
    public int _lightHealth = 10;
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
        if (_bossOver == true)
        {
            Debug.Log("Boss defeated");
        }
    }
}
