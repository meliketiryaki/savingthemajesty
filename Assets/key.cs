using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private bool isPickedUp = false; // Anahtarın alınıp alınmadığını takip etmek için flag
    private Transform playerHand; // Player'ın elini temsil eden transform

    private void Start()
    {
        // Player'ın elini temsil eden objenin transformini al
        playerHand = GameObject.FindGameObjectWithTag("PlayerHand").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            // Anahtarın pozisyonunu Player'ın elinin üzerine ata
            transform.SetParent(playerHand);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            isPickedUp = true;
        }
    }
}
