using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToThrow : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType;
    public ObjectType objectType { get => _objectType; private set => _objectType = value; }


    /// <summary>
    /// When entering the Barrel Bottom Trigger, register this object to the list and send a processItem Event
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            BarrelBottomTrigger trigger = other.gameObject.GetComponent<BarrelBottomTrigger>();
            trigger?.RegisterGameObject(this);
            EventHandler.CallToProcessItems();
        }
    }

    /// <summary>
    /// Change the position of an item that gets out of bound to a valid position
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundaries")
        {
            ThrowableSpawner.Instance.PositionObject(gameObject);
        }
    }

}


public enum ObjectType
{
    flatware,
    food
}
