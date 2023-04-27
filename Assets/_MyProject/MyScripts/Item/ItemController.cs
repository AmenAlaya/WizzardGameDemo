using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Interactable
{
    public static ItemController Instance { get;private set; }
    [SerializeField] private ItemSO _item;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        prompMessage = _item.name;
    }

    public override void Interact()
    {
        Destroy(this.gameObject);
    }

    public ItemSO GetItemSO()
    {
        return _item;
    }

}
