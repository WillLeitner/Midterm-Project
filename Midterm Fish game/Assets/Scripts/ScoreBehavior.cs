using UnityEngine;
using TMPro;

public class ScoreBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreUI;
    void Update()
    {
        _scoreUI.text = GameManager.Instance.Score.ToString();
    }
}
