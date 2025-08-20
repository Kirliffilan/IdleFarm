using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InventoryDescription : MonoBehaviour
{
    [SerializeField] private GameObject fullDescription;
    private Text _text;

    public void Init()
    {
        _text = GetComponent<Text>();
    }

    public void ChangeDescription(string description) => _text.text = description;

    public void Show() => fullDescription.SetActive(true);
    public void Hide() => fullDescription.SetActive(false);
}
