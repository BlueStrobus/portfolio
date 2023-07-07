using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;



    void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        // Destroy the arrow if it goes below a certain y position
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        /*
        // 충돌 판정
        Vector2 p1 = transform.position;                // 화살 중심 좌표
        Vector2 p2 = this.player.transform.position;    // 플레이어 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;    // 화살 반경
        float r2 = 1.0f;    // 플레이어 반경
        */

        //if(d < r1 + r2)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name =="player")
        {
            // Collided with the player
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject); // Destroy the arrow
        }
    }

}
