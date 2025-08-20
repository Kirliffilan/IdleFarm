using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] private int count = 10;

    private readonly Queue<GameObject> _prefabs = new();

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var p = Instantiate(prefab, transform);
            p.SetActive(false);
            _prefabs.Enqueue(p);
        }
    }

    public GameObject Get()
    {
        var gO = _prefabs.Dequeue();
        _prefabs.Enqueue(gO);
        if (!gO.activeInHierarchy)
        {
                gO.SetActive(true);
                return gO;
        }
        return null;
    }
}
