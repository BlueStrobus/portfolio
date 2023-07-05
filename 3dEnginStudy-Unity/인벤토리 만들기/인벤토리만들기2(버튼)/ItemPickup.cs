using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup(){
        InventoryManager.Instance.Add(Item);
        // 인벤토리 관리자에 액세스하여 항목을 추가
        Destroy(gameObject);
        // 추가한 항목 파괴(하이라키에서 지우기)
    }

    private void OnMouseDown(){
        Pickup();
    }

}
