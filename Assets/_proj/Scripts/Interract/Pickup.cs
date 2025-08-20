using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private Item item;

    public Item Item => item;

    private readonly float _rotationSpeed = 120f;

    private bool _canPickingUp = false;
    private readonly float _canPickingUpTime = 2f;

    private const string PLAYER = "Player";

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.Sprite;
    }

    private void OnEnable()
    {
        StartCoroutine(EnablePickup());
    }
    
    private void Update()
    {
        Rotating();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(PLAYER) || !_canPickingUp) return;
        item.Add(1);
        Destroy(gameObject);
    }

    private void Rotating()
    {
        transform.rotation *= Quaternion.Euler(0f, _rotationSpeed * Time.deltaTime, 0f);
    }
    
    private IEnumerator EnablePickup()
    {
        _canPickingUp = false;
        yield return new WaitForSeconds(_canPickingUpTime);
        _canPickingUp = true;
    }
}
