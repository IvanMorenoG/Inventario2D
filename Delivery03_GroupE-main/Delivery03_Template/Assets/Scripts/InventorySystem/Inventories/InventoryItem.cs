using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public Image selectionHighlight; // Borde o efecto de selecci�n
    public Color selectedColor = Color.red;   // Color cuando est� seleccionado
    public Color deselectedColor = Color.white; // Color cuando no est� seleccionado

    private bool isSelected = false;

    public ItemBase Item { get;  set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.SelectItem(this);
    }

    public void SelectItem(bool select)
    {
        isSelected = select; // Asignar directamente el estado

        // Cambiar el color seg�n el estado de selecci�n
        selectionHighlight.color = isSelected ? selectedColor : deselectedColor;
    }
}
