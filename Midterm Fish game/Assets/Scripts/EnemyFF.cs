using UnityEngine;
using System.Collections;

public class EnemyFF : MonoBehaviour
{
    [SerializeField] private float _pathTime = 0.5f;
    private SpriteRenderer _sr;
    private CircleCollider2D _cc;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _cc = GetComponent<CircleCollider2D>();
        StartCoroutine(LifeCycle());
    }
    IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(_pathTime);
        _sr.enabled = !_sr.enabled;
        _cc.enabled = !_cc.enabled;
        yield return new WaitForSeconds(1.0f);
        _sr.enabled = !_sr.enabled;
        _cc.enabled = !_cc.enabled;
        yield return new WaitForSeconds(_pathTime * 2);
        StartCoroutine(LifeCycle());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Debug.Log("I have collided with the player.");
    }
}
