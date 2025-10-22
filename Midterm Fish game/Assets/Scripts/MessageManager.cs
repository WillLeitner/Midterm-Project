using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _messagesUI;

    void Start()
    {
        _messagesUI.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _messagesUI.text = "PAUSED";
            _messagesUI.enabled = !_messagesUI.enabled;
        }
        if (GameManager.Instance.HP == 0)
        {
            _messagesUI.text = "UH OH...";
            _messagesUI.enabled = !_messagesUI.enabled;
        }
    }
}
