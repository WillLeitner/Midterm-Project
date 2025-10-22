using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZoneBehavior : MonoBehaviour
{
    public int _loadzoneID;
    public string _sceneToLoad;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance._doorID = _loadzoneID;
            SceneManager.LoadScene(_sceneToLoad);
        }       
    }
}
