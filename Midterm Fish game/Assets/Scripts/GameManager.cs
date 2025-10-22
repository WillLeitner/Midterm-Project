using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int _playerHealth = 3;
    public int _score = 0;
    [SerializeField] private KeyCode _enter;
    [SerializeField] private KeyCode _pauseButton;
    public bool _gotWeapon = false;
    public bool _gotDash = false;
    public bool _gotShield = false;
    public bool _shootRight = false;
    public bool _wave1Over = false;
    public bool _wave2Over = false;
    public bool _wave3Over = false;
    public bool _gameWin = false;
    public int _doorID;
    public bool _gameOver = false;
    public Utilities.GameState State;
    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
        }
    }
    public int HP
    {
        get
        {
            return _playerHealth;
        }

        set
        {
            _playerHealth = value;
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        HP = 3;
        Score = 0;
    }
    void Update()
    {
        if (HP == 0)
        {
            State = Utilities.GameState.GameOver;
            _gameOver = true;
            HP--;
        }
        if (_gameOver == true)
        {
            StartCoroutine(GameOver());
            _gameOver = false;
        }
        if (_gameWin == true)
        {
            _gameWin = false;
        }
        if (Input.GetKeyDown(_pauseButton))
        {
            State = State == Utilities.GameState.Play ? Utilities.GameState.Pause : Utilities.GameState.Play;
            Debug.Log("play/pause has changed");
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene("GameOver");
        yield return new WaitForSeconds(5.0f);
        Application.Quit();
    }

}
