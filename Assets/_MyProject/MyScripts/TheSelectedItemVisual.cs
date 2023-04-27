using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSelectedItemVisual : MonoBehaviour
{
    [SerializeField] private Interactable _interactable;

    [SerializeField] private GameObject[] _visualGameObjectArray;

    private void Start()
    {
        PlayerInteract.Instance.OnSelectedChanged += Player_OnSelectedChanged;
    }

    private void OnDisable()
    {
        PlayerInteract.Instance.OnSelectedChanged -= Player_OnSelectedChanged;
    }

    private void Player_OnAnyPlayerSpawned(object sender, System.EventArgs e)
    {
        if (PlayerInteract.Instance != null)
        {
            PlayerInteract.Instance.OnSelectedChanged -= Player_OnSelectedChanged;
            PlayerInteract.Instance.OnSelectedChanged += Player_OnSelectedChanged;
        }
    }

    private void Player_OnSelectedChanged(object sender, PlayerInteract.OnSelectedChangedEventArgs e)
    {
        
        if (e.interactable == _interactable)
        {
           
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        
        foreach (var visualGameObject in _visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (var visualGameObject in _visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}