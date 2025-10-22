using UnityEngine;

public class BossLayerBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource _layerSource;
    [SerializeField] private AudioSource _mainSource;
    void Start()
    {
        _layerSource = GameObject.Find("LayerManager").GetComponent<AudioSource>();
        _layerSource.volume = 0;
        _mainSource = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (BossManager.Instance._stunPhase == true)
        {
            while (_layerSource.volume < 1.0f)
            {
                _layerSource.volume += 0.1f;
            }
        }
        else if (BossManager.Instance._stunPhase == false)
        {
            while (_layerSource.volume > 0)
            {
                _layerSource.volume -= 0.1f;
            }
        }
        if (BossManager.Instance._bossOver == true)
        {
            _layerSource.Stop();
            _mainSource.Stop();

        }
    }
}
