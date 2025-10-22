using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip _loseStinger;
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.loop = true;
        source.Play();
    }
    void Update()
    {
        if (GameManager.Instance.HP == 0)
        {
            source.Stop();
            source.PlayOneShot(_loseStinger);
        }
    }
}
