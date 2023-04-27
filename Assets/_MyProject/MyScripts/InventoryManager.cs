using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _itemUI;
    public static InventoryManager Instance { get; private set; }

    private List<ItemSO> _itemSOList = new List<ItemSO>();



    private void Awake()
    {
        Instance = this;
    }

    public void SetItemSOInTheItemSOList(ItemSO itemSO)
    {
        _itemSOList.Add(itemSO);

        foreach (var item in _itemSOList)
        {
            Debug.Log(item.itemName);
        }
    }

    public void GenerateItems()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in _itemSOList)
        {
            GameObject obj = Instantiate(_itemUI, _content);
            obj.GetComponent<ItemUi>().SetMe(item.sprite, item.name);
        }
    }

}
