using UnityEngine;
using System.Collections;

public class ShooterBehavior : MonoBehaviour
{
    [SerializeField] private float Speed = 2.3f;
    [SerializeField] private float _pathDistance = 3.0f;
    [SerializeField] private int _scoreWorth;
    public GameObject[] _bullets;
    private float _direction;
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    private Transform _location;
    private float _originX;
    private float _originY;
    private int _playerLocation;
    private Transform _pTransform;
    [SerializeField] private float _bulletSpeed = 7.0f;
    [SerializeField] private float _cooldown = 0.5f;
    [SerializeField] private float _shootRange = 8.5f;
    public int _enemyHealth = 5;

    void Awake()
    {
        _location = GetComponent<Transform>();
    }

    void Start()
    {
        _pTransform = GameObject.Find("Player").GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _originX = _location.position.x;
        _originY = _location.position.y;
        StartCoroutine(Shoot());
        ResetShooter();
    }
    void ResetShooter()
    {
        Vector2 origin = new Vector2(_originX, _originY);
        transform.position = origin;
        _direction = 1.0f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (_enemyHealth == 1)
            {
                GameManager.Instance.Score += _scoreWorth;
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            else
                _enemyHealth--;
            Destroy(other.gameObject);
            Debug.Log("I have taken damage. My health is: " + _enemyHealth);
        }
    }
    void FixedUpdate()
    {
        if (_location.position.y <= _originY)
        {
            _rb.linearVelocityY = _direction * Speed;
        }
        if (_location.position.y >= (_originY + _pathDistance))
        {
            _rb.linearVelocityY = -(_direction * Speed);
        }
        if (_pTransform.position.x >= (_originX - _shootRange) && _pTransform.position.x <= _originX)
        {
            _sr.flipX = false;
            _playerLocation = 1;
        }
        if (_pTransform.position.x <= (_originX + _shootRange) && _pTransform.position.x >= _originX)
        {
            _sr.flipX = true;
            _playerLocation = 2;
        }
        if (_pTransform.position.x < (_originX - _shootRange) || _pTransform.position.x > (_originX + _shootRange))
            _playerLocation = 0;
    }

    IEnumerator Shoot()
    {
        yield return (_playerLocation > 0);
        if (_playerLocation == 1)
        {
            GameManager.Instance._shootRight = false;
            _bullets[0].GetComponent<Transform>().position = (transform.position);
            _bullets[0].GetComponent<Rigidbody2D>().linearVelocityX = -1.0f * _bulletSpeed;
            yield return new WaitForSeconds(_cooldown);
            _bullets[1].GetComponent<Transform>().position = (transform.position);
            _bullets[1].GetComponent<Rigidbody2D>().linearVelocityX = -1.0f * _bulletSpeed;
            yield return new WaitForSeconds(_cooldown);
            _bullets[2].GetComponent<Transform>().position = (transform.position);
            _bullets[2].GetComponent<Rigidbody2D>().linearVelocityX = -1.0f * _bulletSpeed;
            yield return new WaitForSeconds(_cooldown);
            StartCoroutine(Shoot());
        }
        if (_playerLocation == 2)
        {
            GameManager.Instance._shootRight = true;
            _bullets[0].GetComponent<Transform>().position = (transform.position);
            _bullets[0].GetComponent<Rigidbody2D>().linearVelocityX = 1.0f * _bulletSpeed;
            yield return new WaitForSeconds(_cooldown);
            _bullets[1].GetComponent<Transform>().position = (transform.position);
            _bullets[1].GetComponent<Rigidbody2D>().linearVelocityX = 1.0f * _bulletSpeed;
            yield return new WaitForSeconds(_cooldown);
            _bullets[2].GetComponent<Transform>().position = (transform.position);
            _bullets[2].GetComponent<Rigidbody2D>().linearVelocityX = 1.0f * _bulletSpeed;
            yield return new WaitForSeconds(_cooldown);
            StartCoroutine(Shoot());
        }
        else
            StartCoroutine(Shoot());
    }
}
