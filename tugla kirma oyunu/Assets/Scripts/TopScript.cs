using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform pedal;
    public float hiz;
    public Transform patlama;
    public Transform can;
    public GameManagerScript gm;
    AudioSource audio;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        
        
    }

  
    void Update()
    {
        
        if(gm.oyunBitti)
        {
            return;
        }
        //oyunda değilse pedal sabit kalır
        if(!inPlay)
        {
            transform.position = pedal.position;
        }
       if (Input.GetButtonDown("Jump")&&!inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * hiz);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("asagi"))
        {
            Debug.Log("Top yere çarptı");
            rb.velocity = Vector2.zero;
            inPlay = false;

            gm.CanlariGuncelle(-1);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.CompareTag("blok"))
        {
            //blokların içinden rastgele ekstra can aşağıya doğru iner.
            
                int randChance = Random.Range(1, 101);
                if (randChance <= 50)
                {
                    Instantiate(can, other.transform.position, other.transform.rotation);
                }

                Transform newExplosion = Instantiate(patlama, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.SkoruGuncelle(other.gameObject.GetComponent<BlokScript>().points);
                gm.BlokSayilariniGuncelle();
                Destroy(other.gameObject);
            
        }
        audio.Play();
    }
}
