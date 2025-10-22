using UnityEngine;
using System.Collections;

public class Wave2Behavior : MonoBehaviour
{
    public GameObject _enemy1;
    public GameObject _enemy2;
    public GameObject _enemy3;
    public GameObject _enemy1Spawn;
    public GameObject _enemy2Spawn;
    public GameObject _enemy3Spawn;
    private Transform _enemy1Location;
    private Transform _enemy2Location;
    private Transform _enemy3Location;
    private bool _wave2Exist = false;

    void Start()
    {
        _enemy1Location = _enemy1Spawn.GetComponent<Transform>();
        _enemy2Location = _enemy2Spawn.GetComponent<Transform>();
        _enemy3Location = _enemy3Spawn.GetComponent<Transform>();
    }

    IEnumerator Wave2()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject _enemy1Spawn = Instantiate(_enemy1, _enemy1Location.position,
                                                     transform.rotation);
        GameObject _enemy2Spawn = Instantiate(_enemy2, _enemy2Location.position,
                                                     transform.rotation);
        GameObject _enemy3Spawn = Instantiate(_enemy3, _enemy3Location.position,
                                                     transform.rotation);
    }
    void Update()
    {
        if (ArenaBehavior.Instance._wave1Over == true && _wave2Exist == false)
        {
            StartCoroutine(Wave2());
            _wave2Exist = true;
        }
        if (ArenaBehavior.Instance._deadEnemies == 5)
        {
            Debug.Log("i said finish wave 2");
            ArenaBehavior.Instance._wave2Over = true;
        }
    }

}
