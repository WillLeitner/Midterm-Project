using UnityEngine;

public class GotDash : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance._gotDash == true)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance._gotDash = true;
        }
    }
}
