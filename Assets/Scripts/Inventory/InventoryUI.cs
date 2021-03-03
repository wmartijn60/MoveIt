using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMesh ItemName;

    public void ShowItemName(string iName)
    {
        ItemName.text = iName;
    }
}
