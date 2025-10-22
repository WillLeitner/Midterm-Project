using UnityEngine;
using System.Collections;

public class BossBehavior : MonoBehaviour
{
    private SpriteRenderer _sr;
    public Sprite _regular;
    public Sprite _stunSprite;
    private bool _stun;
    private SpriteRenderer _heartsr;
    private CapsuleCollider2D _heartc;
    public GameObject _bossBullet;
    public GameObject _bulletOrigin;
    private bool _lightDead;
    private int _lightHealth;
    private EdgeCollider2D _collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = _regular;
        _heartsr = GameObject.Find("AnglerHeart").GetComponent<SpriteRenderer>();
        _heartc = GameObject.Find("AnglerHeart").GetComponent<CapsuleCollider2D>();
        _collider = GetComponent<EdgeCollider2D>();
        StartCoroutine(Boss());
    }
    IEnumerator Boss()
    {
        Debug.Log("restarting loop");
        if (BossManager.Instance._bossOver == true)
        {
            _sr.sprite = _stunSprite;
            _collider.enabled = !_collider.enabled;
        }
        else
        {
            if (_stun == false)
            {
                Debug.Log("I am not stunned");
                yield return new WaitForSeconds(5.0f);
                GameObject _bulletOrigin = Instantiate(_bossBullet, transform.position,
                                                         transform.rotation);
                StartCoroutine(Boss());
            }
            if (_stun == true)
            {
                _stun = false;
                Debug.Log("i am stunned");
                yield return new WaitForSeconds(7.0f);
                BossManager.Instance._stunPhase = false;
                BossManager.Instance._lightHealth = 10;
                StartCoroutine(Boss());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BossManager.Instance._stunPhase == true)
        {
            Debug.Log("I am going to be stunned");
            _sr.sprite = _stunSprite;
            _stun = true;
        }
        else if (BossManager.Instance._stunPhase == false && BossManager.Instance._bossOver == false)
            _sr.sprite = _regular;
    }
}
