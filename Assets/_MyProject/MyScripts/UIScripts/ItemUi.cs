using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _container;

    public void SetMe(Sprite sprite , string name)
    {
        _image.sprite = sprite;
        _container.text = name;
    }
}
