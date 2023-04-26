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

    //private PlayerUi _playerUi;

    private StarterAssetsInputs _startInput;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //_playerUi = GetComponent<PlayerUi>();
        _startInput = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        
        //Create a ray at the center of the camera, shooting outwards
        RaycastHit hitInfo;
        if (Physics.SphereCast(Camera.main.transform.position,1f, Camera.main.transform.forward, out hitInfo, _distance, _mask))
        {
            Interactable intercatable = hitInfo.collider.GetComponent<Interactable>();
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                SetSelectedCounter(intercatable);
                if (_startInput.interact)
                {
                    _startInput.interact = false;   
                    Debug.Log(intercatable.prompMessage);
                    intercatable.BaseInteract();
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }


    private void SetSelectedCounter(Interactable interactable)
    {
        this._interactable = interactable;

        OnSelectedChanged?.Invoke(this, new OnSelectedChangedEventArgs
        {
            interactable = _interactable,
        });
    }
}