using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FishBehavior : MonoBehaviour
{
    [Range(1.0f, 10.0f)] public float Speed = 5.0f;
    [SerializeField] private float _swimForce = 5.0f;
    [SerializeField] private KeyCode _rightDirection;
    [SerializeField] private KeyCode _enter;
    [SerializeField] private KeyCode _leftDirection;
    [SerializeField] private KeyCode _swimButton;
    [SerializeField] private KeyCode _shootButton;
    [SerializeField] private KeyCode _dashButton;
    [SerializeField] private KeyCode _shieldButton;
    [SerializeField] private float _dashTime = 0.2f;
    [SerializeField] private float _shieldTime = 1.0f;
    [SerializeField] private float _shieldCooldown = 3.0f;
    [SerializeField] private float _shootCooldown = 0.15f;
    private SpriteRenderer _sr;
    private BoxCollider2D _bc;
    private SpriteRenderer _ffsr;
    private CircleCollider2D _ffcc;
    private bool _isDashing = false;
    public GameObject projectile;
    public GameObject _bulletOrigin;
    private bool _canShield = true;
    private bool _canShoot = true;
    private bool _shieldOn = false;
    private float _direction;
    public GameObject[] _loadOrigins;
    public float launchVelocity = 700f;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _bc = GetComponent<BoxCollider2D>();
        _ffsr = GameObject.Find("PlayerFF").GetComponent<SpriteRenderer>();
        _ffcc = GameObject.Find("PlayerFF").GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        if (GameManager.Instance._doorID == 1)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[0].transform.position;
        }
        if (GameManager.Instance._doorID == 2)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[1].transform.position;
        }
        if (GameManager.Instance._doorID == 3)
        {
            _sr.flipX = true;
            transform.position = _loadOrigins[2].transform.position;
        }
        if (GameManager.Instance._doorID == 4)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[3].transform.position;
        }
        if (GameManager.Instance._doorID == 5)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[4].transform.position;
        }
        if (GameManager.Instance._doorID == 6)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[5].transform.position;
        }
        if (GameManager.Instance._doorID == 7)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[6].transform.position;
        }
        if (GameManager.Instance._doorID == 8)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[7].transform.position;
        }
        if (GameManager.Instance._doorID == 9)
        {
            _sr.flipX = false;
            transform.position = _loadOrigins[8].transform.position;
        }
    }

    void FixedUpdate()
    {
        if (!_isDashing == true)
            _rb.linearVelocityX = _direction * Speed;
        else
            _rb.linearVelocityX = _direction * (Speed * 5);
    }

    void Update()
    {
        _direction = 0.0f;
        Vector2 _swimDirection = new Vector2(0, 0.1f).normalized;
        Vector2 _dashVector = new Vector2(1.0f, 0).normalized;

        if (Input.GetKey(_rightDirection))
        {
            _direction += 1.0f;
            _sr.flipX = false;
            _bc.offset = new Vector2(0.15f, 0.06f);
        }

        if (Input.GetKey(_leftDirection))
        {
            _direction -= 1.0f;
            _sr.flipX = true;
            _bc.offset = new Vector2(-0.15f, 0.06f);
        }

        if (Input.GetKeyDown(_swimButton))
            _rb.AddForce(_swimDirection * _swimForce, ForceMode2D.Impulse);

        if (Input.GetKeyDown(_dashButton) && GameManager.Instance._gotDash == true)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(_shootButton) && GameManager.Instance._gotWeapon == true && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetKeyDown(_shieldButton) && GameManager.Instance._gotShield == true)
        {
            StartCoroutine(Shield());
        }
        if (GameManager.Instance.State == Utilities.GameState.Pause || GameManager.Instance.State == Utilities.GameState.Win)
            _rb.simulated = false;
        if (GameManager.Instance.State == Utilities.GameState.Play)
            _rb.simulated = true;
        if (GameManager.Instance.State == Utilities.GameState.GameOver)
            Destroy(gameObject);
    }

    IEnumerator Shoot()
    {
        GameObject _bulletOrigin = Instantiate(projectile, transform.position,
                                                     transform.rotation);

        _canShoot = false;

        yield return new WaitForSeconds(_shootCooldown);

        _canShoot = true;
    }
    IEnumerator Dash()
    {
        _isDashing = true;

        yield return new WaitForSeconds(_dashTime);

        _isDashing = false;
    }
    IEnumerator Shield()
    {
        if (_canShield == true)
        {
            _ffcc.enabled = !_ffcc.enabled;
            _ffsr.enabled = !_ffsr.enabled;
            _shieldOn = true;

            yield return new WaitForSeconds(_shieldTime);

            _ffcc.enabled = !_ffcc.enabled;
            _ffsr.enabled = !_ffsr.enabled;
            _shieldOn = false;

            _canShield = false;
            yield return new WaitForSeconds(_shieldCooldown);
            _canShield = true;
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && (!_shieldOn == true))
        {
            GameManager.Instance.HP--;
        }
        if (other.gameObject.CompareTag("EnemyFF"))
        {
            GameManager.Instance.HP--;
        }
        if (other.gameObject.CompareTag("EnemyBullet") && (!_shieldOn == true))
        {
            GameManager.Instance.HP--;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SmallHealth") && GameManager.Instance.HP <= 2)
        {
            GameManager.Instance.HP += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("LargeHealth") && GameManager.Instance.HP == 2)
        {
            GameManager.Instance.HP += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("LargeHealth") && GameManager.Instance.HP == 1)
        {
            GameManager.Instance.HP += 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("EnemyBullet") && (!_shieldOn == true))
        {
            GameManager.Instance.HP--;
        }
    }
}