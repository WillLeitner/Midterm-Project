using UnityEngine;

public class GotWeapon : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance._gotWeapon == true)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance._gotWeapon = true;
        }
    }
}
