using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance { get; private set; }

    public event EventHandler<OnSelectedChangedEventArgs> OnSelectedChanged;

    public class OnSelectedChangedEventArgs : EventArgs
    {
        public Interactable interactable;
    }


    [SerializeField]
    private float _distance = 10f;

    [SerializeField]
    private LayerMask _mask;

    private Interactable _interactable;

    private PlayerUI _playerUi;

    private StarterAssetsInputs _startInput;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _playerUi = GetComponent<PlayerUI>();
        _startInput = GetComponent<StarterAssetsInputs>();
    }



    private void Update()
    {
        _playerUi.WriteMessgePrommp(string.Empty);
        //Create a ray at the center of the camera, shooting outwards
        RaycastHit hitInfo;
        if (Physics.SphereCast(Camera.main.transform.position,1f, Camera.main.transform.forward, out hitInfo, _distance, _mask))
        {
            Interactable intercatable = hitInfo.collider.GetComponent<Interactable>();
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                _playerUi.WriteMessgePrommp(intercatable.prompMessage);
                SetSelectedItem(intercatable);
                if (_startInput.interact)
                {
                    _startInput.interact = false;
                    InventoryManager.Instance.SetItemSOInTheItemSOList(ItemController.Instance.GetItemSO());
                    intercatable.BaseInteract();
                }
            }
            else
            {
                SetSelectedItem(null);
            }
        }
        else
        {
            SetSelectedItem(null);
        }
    }

    private void SetSelectedItem(Interactable interactable)
    {
        this._interactable = interactable;

        OnSelectedChanged?.Invoke(this, new OnSelectedChangedEventArgs
        {
            interactable = _interactable,
        });
    }
}