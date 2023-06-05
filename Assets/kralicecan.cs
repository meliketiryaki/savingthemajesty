using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kralicecan : MonoBehaviour
{
    
    public GameObject[] canGorselleri;
    public int canSayisi = 5;
    public string youwinSceneName = "YouWin";

    private Vector3 startPosition; // Karakterin başlangıç konumu

    private void Start()
    {
        startPosition = transform.position; // Başlangıç konumunu kaydet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("prensesates"))
        {
            canSayisi--;

            if (canSayisi <= 0)
            {
                YouWinScene();
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

    private void YouWinScene()
    {
        SceneManager.LoadScene(4);
    }
}


