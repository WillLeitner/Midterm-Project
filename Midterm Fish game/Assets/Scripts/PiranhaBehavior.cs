using UnityEngine;

public class PiranhaBehavior : MonoBehaviour
{
    [SerializeField] private float Speed = 1.5f;
    [SerializeField] private float _pathDistance = 7.0f;
    [SerializeField] private int _scoreWorth;
    private float _direction;
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    private Transform _location;
    private float _originX;
    private float _originY;
    public int _enemyHealth = 3;

    void Awake()
    {
        _location = GetComponent<Transform>();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _originX = _location.position.x;
        _originY = _location.position.y;
        ResetPiranha();
    }

    // Update is called once per frame
    void ResetPiranha()
    {
        Vector2 origin = new Vector2(_originX, _originY);
        transform.position = origin;
        _sr.flipX = false;
        _direction = -1.0f;
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
        if (_location.position.x >= _originX)
        {
            _rb.linearVelocityX = _direction * Speed;
            _sr.flipX = false;
        }
        if (_location.position.x <= (_originX - _pathDistance))
        {
            _rb.linearVelocityX = -(_direction * Speed);
            _sr.flipX = true;
        }
    }
}
