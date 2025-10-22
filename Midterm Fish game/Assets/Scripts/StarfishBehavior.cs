using UnityEngine;

public class StarfishBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
            Destroy(other.gameObject);
    }
}
