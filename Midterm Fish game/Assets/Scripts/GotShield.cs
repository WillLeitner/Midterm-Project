using UnityEngine;

public class GotShield : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance._gotShield == true)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance._gotShield = true;
        }
    }
}
