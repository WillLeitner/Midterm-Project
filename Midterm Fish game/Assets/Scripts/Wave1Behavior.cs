using UnityEngine;
using System.Collections;

public class Wave1Behavior : MonoBehaviour
{
    public GameObject _enemy1;
    public GameObject _enemy2;
    public GameObject _enemy1Spawn;
    public GameObject _enemy2Spawn;
    private Transform _enemy1Location;
    private Transform _enemy2Location;

    void Start()
    {
        ArenaBehavior.Instance._wave1Over = false;
        StartCoroutine(Wave1());
        _enemy1Location = _enemy1Spawn.GetComponent<Transform>();
        _enemy2Location = _enemy2Spawn.GetComponent<Transform>();
    }

    IEnumerator Wave1()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject _enemy1Spawn = Instantiate(_enemy1, _enemy1Location.position,
                                                     transform.rotation);
        GameObject _enemy2Spawn = Instantiate(_enemy2, _enemy2Location.position,
                                                     transform.rotation);
    }
    void Update()
    {
        if (ArenaBehavior.Instance._deadEnemies == 2)
        {
            Debug.Log("i said finish wave 1");
            ArenaBehavior.Instance._wave1Over = true;
        }
    }

}
