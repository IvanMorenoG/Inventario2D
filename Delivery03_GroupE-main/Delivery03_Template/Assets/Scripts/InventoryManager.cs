using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private InventoryItem selectedItem;

    //public List<InventoryItem> playerInventory = new List<InventoryItem>();
    //public List<InventoryItem> shopInventory = new List<InventoryItem>();

    public Inventory playerInventory; // Inventario del jugador (ScriptableObject)
    public Inventory shopInventory;   // Inventario de la tienda (ScriptableObject)

    public int playerCoins = 100;
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        Instance = this;
        UpdateUI();
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
        if (selectedItem != null && shopInventory.ContainsItem(selectedItem.Item))
        {
            int itemCost = selectedItem.Item.Cost;

            if (playerCoins >= itemCost)
            {
                // Restar el costo del �tem de las monedas del jugador
                playerCoins -= itemCost;

                // Restar una unidad del �tem en el inventario de la tienda
                shopInventory.RemoveItem(selectedItem.Item);

                // A�adir el �tem al inventario del jugador
                playerInventory.AddItem(selectedItem.Item);

                // Deseleccionar el �tem y actualizar la UI
                selectedItem.SelectItem(false);
                selectedItem = null;
                UpdateUI();
                UpdateUI();

                Debug.Log("Item bought! Remaining coins: " + playerCoins);
            }
            else
            {
                Debug.Log("Not enough coins to buy this item!");
            }
        }
    }

    public void SellItem()
    {
        if (selectedItem != null && playerInventory.ContainsItem(selectedItem.Item))
        {
            // Sumar el valor del �tem a las monedas del jugador
            playerCoins += selectedItem.Item.Cost;

            // Eliminar el �tem del inventario del jugador
            playerInventory.RemoveItem(selectedItem.Item);

            // A�adir el �tem al inventario de la tienda
            shopInventory.AddItem(selectedItem.Item);

            // Deseleccionar el �tem y actualizar la UI
            selectedItem.SelectItem(false);
            selectedItem = null;
            UpdateUI();
            UpdateUI();

            Debug.Log("Item sold! Current coins: " + playerCoins);
        }
    }

    private void UpdateUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + playerCoins;
        }
        // Aqu� actualizar�as la interfaz gr�fica seg�n c�mo est�n implementados los inventarios en tu juego.
    }
}
