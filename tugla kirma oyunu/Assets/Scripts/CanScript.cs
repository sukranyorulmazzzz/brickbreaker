using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public float speed;//hız 
   
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime*speed);
        //ekstra can objesinin ekrandan silinmesi fonksiyonu
        if (transform.position.y < -5.45f)
        {
            Destroy(gameObject);
        }
    }
}
