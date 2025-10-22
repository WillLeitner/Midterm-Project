using UnityEngine;
using System.Collections;

public class BossBulletBehavior : MonoBehaviour
{
    private Transform _pTransform;
    [SerializeField] private float _bossBulletSpeed = 4.0f;
    private float _bulletDirectionX;
    private float _bulletDirectionY;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pTransform = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(FollowPlayer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.linearVelocityX = _bulletDirectionX * _bossBulletSpeed;
        _rb.linearVelocityY = _bulletDirectionY * _bossBulletSpeed;
    }
    IEnumerator FollowPlayer()
    {
        if (_pTransform.position.x < transform.position.x)
            _bulletDirectionX = -1.0f;
        else if (_pTransform.position.x > transform.position.x)
            _bulletDirectionX = 1.0f;

        if (_pTransform.position.y < transform.position.y)
            _bulletDirectionY = -1.0f;
        else if (_pTransform.position.y > transform.position.y)
            _bulletDirectionY = 1.0f;

        yield return new WaitForSeconds(0.75f);
        StartCoroutine(FollowPlayer());
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

        }
        else
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

        }
        else
            Destroy(gameObject);
    }
}
