using UnityEngine;

public class MovingStarfishDown : MonoBehaviour
{
    [SerializeField] private float _flingStrength = 5.0f;
    private float _direction;
    private Rigidbody2D _rb;
    private Transform _location;
    private float _originX;
    private float _originY;

    void Awake()
    {
        _location = GetComponent<Transform>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _originX = _location.position.x;
        _originY = _location.position.y;
        ResetEnemy();
    }

    // Update is called once per frame
    void ResetEnemy()
    {
        Vector2 origin = new Vector2(_originX, _originY);
        transform.position = origin;
        _direction = -1.0f;
    }

    void FixedUpdate()
    {
        _rb.linearVelocityY = _direction * _flingStrength;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("StarBlock") || other.gameObject.CompareTag("Player"))
        {
            ResetEnemy();
        }
    }       
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
            Destroy(other.gameObject);
    }
}
