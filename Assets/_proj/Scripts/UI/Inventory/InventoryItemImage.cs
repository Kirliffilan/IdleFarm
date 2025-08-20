using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItemImage : MonoBehaviour
{
    public void Init(Sprite sprite)
    {
        Image image = GetComponent<Image>();
        image.sprite = sprite;
    }
}
