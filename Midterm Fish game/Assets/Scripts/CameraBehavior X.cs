using UnityEngine;

public class CameraBehaviorX : MonoBehaviour
{
    private Transform _playerLocation;
    void Start()
    {
        _playerLocation = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update() 
    {
    	transform.position = new Vector3 (_playerLocation.position.x + 2, 0, -10); // Camera follows the player but 6 to the right
    }
}
