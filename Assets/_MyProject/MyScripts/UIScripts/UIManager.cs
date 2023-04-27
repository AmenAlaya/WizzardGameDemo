using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool openInventory;
    private void Update()
    {
        if (StarterAssetsInputs.Instance.inventory)
        {
            openInventory = true;
            StarterAssetsInputs.Instance.cursorInputForLook = false;
            StarterAssetsInputs.Instance.cursorLocked = false;
            Cursor.visible = true;
            InventoryUI.Instance.Show();
        }
        else
        {
            StarterAssetsInputs.Instance.cursorInputForLook = true;
            StarterAssetsInputs.Instance.cursorLocked = true;
            Cursor.visible = false;
            InventoryUI.Instance.Hide();
        }

        if(openInventory)
        {
            openInventory=false;
            InventoryManager.Instance.GenerateItems();
        }
    }
}

