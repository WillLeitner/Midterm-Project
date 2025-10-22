using UnityEngine;

public class CameraBehaviorY : MonoBehaviour
{
    private Transform _playerLocation;
    void Start()
    {
        _playerLocation = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update() 
    {
    	transform.position = new Vector3 (0, _playerLocation.position.y, -10); // Camera follows the player but 6 to the right
    }
}
