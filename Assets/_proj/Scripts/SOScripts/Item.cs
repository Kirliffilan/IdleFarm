using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")] 
public class Item : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string itemName;
    [SerializeField] private int price;
    [SerializeField] private int growDuration;

    public event Action OnCountChanged;
    public event Action OnPriceChanged;

    private int _count;

    private int _updateCount;

    public string Name => itemName;
    public int Count => _count;
    public int GrowDuration => growDuration;
    public Sprite Sprite => sprite;

    private float PriceMultiplier => (float) Math.Pow(1.5, _updateCount);
    private int Price => (int) (price * PriceMultiplier);
    private int TotalPrice => Price * _count;

    public void Update()
    {
        _updateCount++;
        OnPriceChanged?.Invoke();
    }

    public void ResetGame()
    {
        _updateCount = 0;
        _count = 0;
        OnPriceChanged?.Invoke();
        OnCountChanged?.Invoke();
    }

    public void Add(int count)
    {
        _count += count;
        OnCountChanged?.Invoke();
    }

    public int Sell(int count)
    {
        if (count > _count) return -1;

        _count -= count;
        OnCountChanged?.Invoke();
        return count * Price;
    }

    public string GetInfo() =>
        $"{itemName} - {_count} шт.\nВырастает за {growDuration} с.\nЦена за 1 - {price} м.\nЦена за {_count} - {TotalPrice} м.";
}
