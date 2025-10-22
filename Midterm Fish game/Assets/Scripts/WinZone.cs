using UnityEngine;
using TMPro;

public class WinZone : MonoBehaviour
{
    [SerializeField] private TMP_Text _winUI;
    private AudioSource source;
    public AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("you win");
            GameManager.Instance.State = Utilities.GameState.Win;
            GameManager.Instance._gameWin = true;
            source.clip = clip;
            source.Play();
            _winUI.text = "YOU WIN!\nYOUR SCORE IS: \n" + GameManager.Instance.Score.ToString();
            _winUI.enabled = !_winUI.enabled;
        }    
    }
}
