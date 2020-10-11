using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour {

    public Inventory inventory;
	// Update is called once per frame
	void Awake ()
    {
		for(int i = 0; i<inventory.items.Length; i++)
        {
            Debug.Log(inventory.items[i].Name);
        }
	}
}
