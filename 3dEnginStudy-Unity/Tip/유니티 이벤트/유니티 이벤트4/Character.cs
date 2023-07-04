using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public delegate void Boost(Character target);

    public event Boost playerBoost;

    public string playerName = "Jemin";
    public float hp = 100;
    public float defense = 50;
    public float damage = 30;

    void Start(){
        playerBoost(this);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            playerBoost(this);
        }
    }
}
