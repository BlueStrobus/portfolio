using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// UI 글자 바꾸기

public class UIManager : MonoBehaviour
{
    public Text playerStateText;
    public void OnPlayerDead(){
        playerStateText.text = "You Die!";
    }
}
