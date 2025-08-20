using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private InventoryItemText text;
    [SerializeField] private InventoryDescription description;
    [SerializeField] private InventoryItemImage image;

    private void Awake()
    {
        image.Init(item.Sprite);
        text.Init();
        description.Init();

        ChangeCount();
        ChangeDescription();
    }

    private void OnEnable()
    {
        item.OnCountChanged += ChangeCount;
        item.OnCountChanged += ChangeDescription;
        item.OnPriceChanged += ChangeDescription;
    }

    private void OnDisable()
    {
        item.OnCountChanged -= ChangeCount;
        item.OnCountChanged -= ChangeDescription;
        item.OnPriceChanged -= ChangeDescription;
    }

    private void OnMouseDown()
    {
        description.Show();
    }

    private void OnMouseUp()
    {
        description.Hide();
    }

    private void ChangeCount() => text.ChangeCount(item.Count);
    private void ChangeDescription() => description.ChangeDescription(item.GetInfo());
}
