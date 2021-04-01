    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool oyunBitti;
    public GameObject oyunBittiPaneli;
    public GameObject loadLevelPaneli;
    public int blokSayisi;
    public Transform[] levels;
    public int currentLevelIndex=0;
    


   
    void Start()
    {
        livesText.text = "❤:" + lives;
        scoreText.text = "score:" + score;
        blokSayisi = GameObject.FindGameObjectsWithTag("blok").Length;
        //ekrana toplam can sayısının yazdırılması fonksiyonu
    }

    
    void Update()
    {
        
    }
    //can sayısının güncellenmesi ve tamamen bitince oyunun sonlanması
    public void CanlariGuncelle(int changeInLives)
    {
        lives += changeInLives;
        if(lives<=0)
        {
            lives = 0;
            OyunBitti();
        }

        livesText.text = "❤:" + lives;
    }
    //ekrana toplam skorun yazılması
    public void SkoruGuncelle(int points)
    {
        score += points;
        scoreText.text = "score:" + score;
    }
    
    public void BlokSayilariniGuncelle()
    {
        //blok sayılarının güncellenmesi, blok sayısı bittiğinde yeni bir level varsa
        //ona geçilir yoksa oyun biter.
        blokSayisi--;
        if (blokSayisi <= 0)
        {
            if (currentLevelIndex >= levels.Length - 1)
            {
                OyunBitti();
            }
            else
            {
                loadLevelPaneli.SetActive(true);
                     oyunBitti = true;
                Invoke("LoadLevel",3f);
                }
        }
       
    }
    void LoadLevel()
    {
        //levellerin yüklenmesi fonksiyonu
        
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        blokSayisi = GameObject.FindGameObjectsWithTag("blok").Length;
        oyunBitti = false;
        loadLevelPaneli.SetActive(false);
    }
    //oyun bittiğinde oyun bitti paneli aktif olur.
    void OyunBitti()
    {
        oyunBitti = true;
        oyunBittiPaneli.SetActive(true);
    }
    //tekrar oyna fonksiyonuna tıklandıgında aynı bölüm yeniden yüklenir.
    public void TekrarOyna()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //çıkış fonksiyonunda oyundan çıkılır.
    public void Cikis()
    {
        Application.Quit();
        Debug.Log("Oyundan cikildi");
    }
}
