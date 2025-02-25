using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private InventoryItem selectedItem;

    public List<InventoryItem> playerInventory = new List<InventoryItem>();
    public List<InventoryItem> shopInventory = new List<InventoryItem>();

    private void Awake()
    {
        Instance = this;
    }

    public void SelectItem(InventoryItem newItem)
    {
        if (selectedItem != null)
        {
            selectedItem.SelectItem(false); // Desseleccionar el anterior
        }

        selectedItem = newItem;
        selectedItem.SelectItem(true); // Seleccionar el nuevo
    }

    public void BuyItem()
    {
        if (selectedItem != null && shopInventory.Contains(selectedItem))
        {
            shopInventory.Remove(selectedItem);
            playerInventory.Add(selectedItem);
            selectedItem.SelectItem(false);
            selectedItem = null;
            UpdateUI();
        }
    }

    public void SellItem()
    {
        if (selectedItem != null && playerInventory.Contains(selectedItem))
        {
            playerInventory.Remove(selectedItem);
            shopInventory.Add(selectedItem);
            selectedItem.SelectItem(false);
            selectedItem = null;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        // Aquí actualizarías la interfaz gráfica según cómo estén implementados los inventarios en tu juego.
    }
}
