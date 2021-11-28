using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFurniture : MonoBehaviour
{
    [SerializeField] private List<GameObject> _furniture;
    [SerializeField] private GameObject _listItemPrefab;
    [SerializeField] private MenuList _menuList;

    public void UpdateList()
    {
        _menuList.ClearItems();
        foreach (GameObject item in _furniture)
        {
            GameObject newListItem = _menuList.AddItem(_listItemPrefab);
            newListItem.GetComponentInChildren<Text>().text = item.name;
            newListItem.GetComponent<Button>().onClick.AddListener(delegate { SpawnFurniture(_furniture.IndexOf(item)); });
        }
    }

    private void SpawnFurniture(int index)
    {
        Instantiate(_furniture[index], new Vector3(transform.position.x, 0, transform.position.z), _furniture[index].transform.rotation);
    }
}
