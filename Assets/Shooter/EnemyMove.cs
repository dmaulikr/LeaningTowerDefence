using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    public Transform damage;
    public Transform track;
    public float szybkoscporuszania = 3;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float ruch = szybkoscporuszania * Time.deltaTime;
        anim.SetInteger("Run", 1);
        transform.position = Vector2.MoveTowards(transform.position, track.position, ruch);
       
    }
    void OnCollsionEnter(Collision collsion)
    {

    }
}
