using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalScript : MonoBehaviour
{
    public float hiz;
    public float sagEkranKenari;
    public float solEkranKenari;
    public GameManagerScript gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ekrandaki top sağa sola ve yukarıya çarptıgında ekranda kalır, ama aşağıya düşerse oyun biter.
        //bu fonksiyonda ekrandaki pedalın pozisyonu belirlenmiştir.
        if(gm.oyunBitti)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right*horizontal* Time.deltaTime*hiz);
        if (transform.position.x < solEkranKenari)
        {
            transform.position = new Vector2(solEkranKenari, transform.position.y);
        }
        if (transform.position.x > sagEkranKenari)
        {
            transform.position = new Vector2(sagEkranKenari, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //ekstra can toplandıgında toplam can sayısına 1 can eklenir.
        if (other.CompareTag("can"))
        {
            gm.CanlariGuncelle(1);
            Destroy(other.gameObject);
        }
    }
}
