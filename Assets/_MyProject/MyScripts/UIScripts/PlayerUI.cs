using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messagePrompText;

    public void WriteMessgePrommp(string message)
    {
        _messagePrompText.text = message;
    }
}
