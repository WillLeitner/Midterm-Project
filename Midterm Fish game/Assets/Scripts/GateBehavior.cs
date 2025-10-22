using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    private SpriteRenderer _sr;
    private int _gateHealth = 3;
    [SerializeField] private Sprite[] _gateLevels;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_gateHealth == 3)
        {
            _sr.sprite = _gateLevels[0];
        }
        else if (_gateHealth == 2)
        {
            _sr.sprite = _gateLevels[1];
        }
        else if (_gateHealth == 1)
        {
            _sr.sprite = _gateLevels[2];
        }
        else if (_gateHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            _gateHealth -= 1;
            Destroy(other.gameObject);
        }       
    }
}
