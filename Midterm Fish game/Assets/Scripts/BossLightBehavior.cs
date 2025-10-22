using UnityEngine;

public class BossLightBehavior : MonoBehaviour
{
    private SpriteRenderer _sr;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (BossManager.Instance._lightHealth > 1)
            {
                Destroy(other.gameObject);
                BossManager.Instance._lightHealth--;
                Debug.Log("The light has taken damage. My health is: " + BossManager.Instance._lightHealth);
            }
            else if (BossManager.Instance._lightHealth == 1)
            {
                BossManager.Instance._stunPhase = true;
                transform.position = new Vector2(1000, 1000);
                Debug.Log("the boss is now stunned");
                Destroy(other.gameObject);
            }
        }
    }
    void Update()
    {
        if (BossManager.Instance._lightHealth == 10)
        {
            transform.position = new Vector2(17, -15);
        }
        if (BossManager.Instance._bossOver == true)
            Destroy(gameObject);
    }
}
