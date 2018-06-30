using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    Rigidbody2D rigidbody2D;
    public int speed;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    void Update () {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        
    }
    void   OnBecameInvisible()
    {
        
            Destroy(this.gameObject);
           // Debug.Log(" 消える ");
        
    }
    }
