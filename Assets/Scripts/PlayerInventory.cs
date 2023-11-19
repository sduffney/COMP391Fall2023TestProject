using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add PlayerInventory.cs to dewy

public class PlayerInventory : MonoBehaviour, InventoryInterface
{
    public int Key { get => _key; set => _key = value; }

    private int _key = 0;
}