using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuList : MonoBehaviour
{
    [SerializeField] private RectTransform _listParent;
    [SerializeField] private float _margin;
    private float _currentOffset = 0f;
    private List<RectTransform> _items;

    public GameObject AddItem(GameObject itemPrefab)
    {
        GameObject newItem = Instantiate(itemPrefab, _listParent);
        RectTransform newItemRectTransform = newItem.GetComponent<RectTransform>();
        newItemRectTransform.anchoredPosition = new Vector2(_currentOffset, 0);
        _currentOffset += newItemRectTransform.sizeDelta.x + _margin;
        _items.Add(newItemRectTransform);
        return newItem;
    }

    public void ClearItems()
    {
        if(_items != null)
            foreach (RectTransform item in _items)
            {
                Destroy(item.gameObject);
            }

        _currentOffset = 0f;
        _items = new List<RectTransform>();
    }
}
