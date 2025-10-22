using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float _parallaxEffect;
    [SerializeField] bool _distanceBased;
    [SerializeField] float _parallaxScaling = 0.1f;
    private GameObject _cam;
    float _spriteLength;
    float _startPosX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cam = GameObject.Find("Main Camera");
        _startPosX = transform.position.x;

        if (_distanceBased)
            _parallaxEffect = transform.position.z * _parallaxScaling;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.tileMode = SpriteTileMode.Continuous;
        _spriteLength = spriteRenderer.bounds.size.x;

        Vector2 scaleSprite = new(3, 1);
        spriteRenderer.size *= scaleSprite;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = _cam.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(
            _startPosX + distance,
            transform.position.y,
            transform.position.z
        );

        float deltaX = _cam.transform.position.x - transform.position.x;
        if (Mathf.Abs(deltaX) >= _spriteLength)
            _startPosX += deltaX > 0 ? _spriteLength : -_spriteLength;
    }
}
