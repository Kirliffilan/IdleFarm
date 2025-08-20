using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class InventoryItemText : MonoBehaviour
{
    private Text _text;

    public void Init()
    {
        _text = GetComponent<Text>();
    }

    public void ChangeCount(int count) => _text.text = count.ToString();
}
