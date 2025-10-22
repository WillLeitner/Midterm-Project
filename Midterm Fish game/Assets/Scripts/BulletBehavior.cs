using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 7.0f;
    private Rigidbody2D _rb;
    private SpriteRenderer _psr;
    private bool _launchRight;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _psr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        if (_psr.flipX == false)
            _launchRight = true;
        else if (_psr.flipX == true)
            _launchRight = false;
    }

    void FixedUpdate()
    {
        if (_launchRight == true)
            _rb.linearVelocityX = 1.0f * _bulletSpeed;
        else if (_launchRight == false)
            _rb.linearVelocityX = -1.0f * _bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("CombatZone"))
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
