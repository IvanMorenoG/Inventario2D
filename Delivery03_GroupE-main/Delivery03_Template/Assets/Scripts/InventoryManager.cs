using UnityEngine;
using UnityEngine.UI;  // Si trabajas con elementos de UI como Image
using UnityEngine.EventSystems;  // Si trabajas con eventos como OnPointerClick

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private InventoryItem selectedItem;

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
}