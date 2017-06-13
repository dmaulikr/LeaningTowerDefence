using UnityEngine;
using System.Collections;

public class controll : MonoBehaviour {


    public float szybkoscx;
    public float skoksY;

    bool facingright, jumping;
    float szybkosc;

    Animator anim;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingright = true;
	}
	
	// Update is called once per frame
	void Update () {
       ruchpostaci(szybkosc);

        if (Input.GetKeyDown(KeyCode.A))
        {
            szybkosc = -szybkoscx;
        }
 

        if (Input.GetKeyDown(KeyCode.D))
        {
            szybkosc = szybkoscx;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            szybkosc = 0;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            szybkosc = 0;
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            szybkosc = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x, skoksY));
        } */
	}
    void ruchpostaci(float sz)
    {
        if (szybkosc > 0 || szybkosc < 0)
        {
            anim.SetInteger("Run", 1);
        }
        if(szybkosc == 0) {
            anim.SetInteger("Run", 0);
        }
        rb.velocity = new Vector3(szybkosc, rb.velocity.y, 0); 
    }
}
