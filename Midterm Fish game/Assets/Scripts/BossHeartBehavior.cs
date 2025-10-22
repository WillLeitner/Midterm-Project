using UnityEngine;

public class BossHeartBehavior : MonoBehaviour
{
    void Update()
    {
        if (BossManager.Instance._stunPhase == true)
        {
            transform.position = new Vector2(26, -4);
        }
        else if (BossManager.Instance._stunPhase == false)
        {
            transform.position = new Vector2(2000, 2000);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (BossManager.Instance._bossHealth == 1)
            {
                GameManager.Instance.Score += 100;
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                BossManager.Instance._bossOver = true;
            }
            else
                BossManager.Instance._bossHealth--;
            Destroy(other.gameObject);
            Debug.Log("I have taken damage. My health is: " + BossManager.Instance._bossHealth);
        }
    }
}
