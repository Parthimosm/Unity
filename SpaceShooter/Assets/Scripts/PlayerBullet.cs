using UnityEngine;
using System.Collections;

public class PlayerBullet: MonoBehaviour {

    float speed; 

	// Use this for initialization
	void Start ()
    {
        speed = 8f; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;

        //compute the bullets new position
        position = new Vector2 (position.x, position.y  +speed * Time.deltaTime);

        //update bullets position
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if bullet reaches end of screen then destroy
        if(transform.position.y > max.y)
        {
            Destroy(gameObject); 
        }
	}
}
