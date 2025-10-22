using UnityEngine;

public class LayerBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource _layerSource;
    void Start()
    {
        _layerSource = GameObject.Find("LayerManager").GetComponent<AudioSource>();
        _layerSource.volume = 0;
        _layerSource.loop = true;
        _layerSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            while (_layerSource.volume < 0.7f)
            {
                _layerSource.volume += 0.1f;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            while (_layerSource.volume > 0)
            {
                _layerSource.volume -= 0.1f;
            }
        }
    }
}
