﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public GameObject PlayerBulletGO;//player bullet prefab
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;
    public GameObject Exp; 

    public float speed; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //fire bullet if spacebar is pressed 
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = BulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = BulletPosition02.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed / 2;
        } else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed * 2; 
        } 

        
        Move(direction); 

    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos; 

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {         
            Destroy(gameObject);
            PlayExplosion();
        }
    }

    //boom function 

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Exp);

        explosion.transform.position = transform.position; 

    }


}
