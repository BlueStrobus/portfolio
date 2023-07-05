using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    // 정적 인벤토리 관리자 만들고 'Instance'로 선언

    public List<Item> items = new List<Item>();
    // 이이템 리스트 만들기

    private void Awake(){
        Instance = this;
    }

    public void Add(Item item){ 
        // 파라미터(매게변수)의 형태를 item으로 지정
        items.Add(item);
    }
    public void Remove(Item item){ 
        // 파라미터(매게변수)의 형태를 item으로 지정
        items.Remove(item);
    }
}