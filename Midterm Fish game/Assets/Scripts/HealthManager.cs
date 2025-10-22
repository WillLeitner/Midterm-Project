using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthUI;
    void Update()
    {
        _healthUI.text = GameManager.Instance.HP.ToString();
    }
}
