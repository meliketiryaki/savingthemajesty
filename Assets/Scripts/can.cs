using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class can : MonoBehaviour
{
    
    public GameObject[] canGorselleri;
    public int canSayisi = 3;
    public string gameOverSceneName = "GameOver";

    private Vector3 startPosition; // Karakterin başlangıç konumu

    private void Start()
    {
        startPosition = transform.position; // Başlangıç konumunu kaydet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            canSayisi--;

            if (canSayisi <= 0)
            {
                GameOverScene();
            }

            
            
            else
            {
                
                transform.position = startPosition; 
                
            }
            UpdateCanGorselleri();
            
        }
    }

    private void UpdateCanGorselleri()
    {
        for (int i = 0; i < canGorselleri.Length; i++)
        {
            if (i < canSayisi)
            {
                canGorselleri[i].SetActive(true);
            }
            else
            {
                canGorselleri[i].SetActive(false);
            }
        }
    }

    private void GameOverScene()
    {
        SceneManager.LoadScene(5);
    }
}


