using UnityEngine;
using System.Collections;
public class EnemyBulletBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Transform _transform;
    private float _originX;
    private float _originY;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _originX = _transform.position.x;
        _originY = _transform.position.y;
        ResetBullet();
    }

    void ResetBullet()
    {
        Vector2 origin = new Vector2(_originX, _originY);
        transform.position = origin;
    }
    void FixedUpdate()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            ResetBullet();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PlayerFF"))
        {
            Debug.Log("I have hit the shield");
            ResetBullet();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I have hit the player");
            ResetBullet();
        }
    }
}
