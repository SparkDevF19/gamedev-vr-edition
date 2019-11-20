using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickBehavior : MonoBehaviour
{
    public InventoryObject inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Collider other = hit.collider as Collider;
                if ( other.GetComponent("Item") != null )
                {
                    AddItemOnClick(other);
                    Destroy(other.gameObject);
                    Debug.Log("Item successfully added");
                }
            }
        }
        
    }

    public void AddItemOnClick(Collider bc)
    {
        var item = bc.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
        }
    }

    // This resets the item count to zero upon closing the game.
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
