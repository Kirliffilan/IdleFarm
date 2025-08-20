using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Garden : MonoBehaviour
{
    [Header("Pickup setting")]
    [SerializeField] private PullObject pullPickups;
    [SerializeField] private Pickup pickup;
    [SerializeField] private float spawnRadius = 0.5f;
    [SerializeField] private Vector2 offset = new(0, 0.5f);
    [Header("Sprites settings")]
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _growSprite;
    
    private SpriteRenderer _spriteRenderer;

    private bool _isDone = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Grow());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (_isDone)
        {
            Drop();
            SetSprite(_defaultSprite);
            StartCoroutine(Grow());
        }
    }


    private IEnumerator Grow()
    {
        _isDone = false;
        yield return new WaitForSeconds(pickup.Item.GrowDuration);
        SetSprite(_growSprite);
        _isDone = true;
    }

    private void Drop()
    {
        Vector2 randomPosition = (Vector2)transform.position + offset + Random.insideUnitCircle * spawnRadius;

        var pickup = pullPickups.Get();
        if (pickup != null)
        {
            pickup.transform.position = randomPosition;
        }
    }

    private void SetSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere((Vector2)transform.position + offset, spawnRadius);
    }
}
