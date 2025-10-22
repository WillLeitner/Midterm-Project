using UnityEngine;
using System.Collections;

public class JellyfishBehavior : MonoBehaviour
{
    [SerializeField] private float Speed = 1.5f;
    [SerializeField] private float _pathTime = 0.5f;
    [SerializeField] private int _scoreWorth;
    private float _direction;
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    private Transform _location;
    private float _originX;
    private float _originY;
    private CapsuleCollider2D _cc;
    [SerializeField] private bool _ffJellyfish;
    [SerializeField] private Sprite _jfUp;
    [SerializeField] private Sprite _jfDown;
    [SerializeField] private int _enemyHealth = 3;

    void Awake()
    {
        _location = GetComponent<Transform>();
        if (_ffJellyfish == true)
            _enemyHealth = 4;
        else
            _enemyHealth = 3;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _cc = GetComponent<CapsuleCollider2D>();
        _originX = _location.position.x;
        _originY = _location.position.y;
        ResetJF();
    }

    // Update is called once per frame
    void ResetJF()
    {
        Vector2 origin = new Vector2(_originX, _originY);
        transform.position = origin;
        _direction = 1.0f;
        StartCoroutine(JFMovement());
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
    IEnumerator JFMovement()
    {
        if (_enemyHealth > 0)
        {
            _rb.linearVelocityY = _direction * (Speed * 2);
            _sr.sprite = _jfUp;
            _cc.offset = new Vector2(0f, 0.8f);
            yield return new WaitForSeconds(_pathTime);
            if (_ffJellyfish == true)
            {
                _rb.simulated = false;
                yield return new WaitForSeconds(1.0f);
                _rb.simulated = true;
            }
            _rb.linearVelocityY = -(_direction * Speed);
            _sr.sprite = _jfDown;
            _cc.offset = new Vector2(0f, 0.2f);
            yield return new WaitForSeconds(_pathTime * 2);
            StartCoroutine(JFMovement());
        }
    }
}
