using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BarrelBottomTrigger : MonoBehaviour
{
    [SerializeField] private ObjectType _correctType;

    [SerializeField] private List<ItemToThrow> _items;

    private void OnEnable()
    {
        EventHandler.ProcessItems += ProcessItems;
    }
    private void OnDisable()
    {
        EventHandler.ProcessItems -= ProcessItems;
    }

    private void Awake()
    {
        _items = new List<ItemToThrow>();
    }

    /// <summary>
    /// Loop through all Items in the _items list and check if their type is correct before destroying them and sending the correct Event.
    /// </summary>
    private void ProcessItems()
    {
        foreach (ItemToThrow item in _items)
        {
            if (CheckItemType(item.objectType))
            {
                EventHandler.CallCorrectItemType();
            }
            else
            {
                EventHandler.CallInvalidItemType();
            }
            int index = _items.IndexOf(item);
            Destroy(item.gameObject);
            _items.RemoveAt(index);
            if (_items.Count == 0)
            {
                break;
            }
        }
    }

    private bool CheckItemType(ObjectType objectType)
    {
        return _correctType == objectType;
    }

    public void RegisterGameObject(ItemToThrow item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
        }
    }
}
