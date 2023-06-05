using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canavar3 : MonoBehaviour
{
    public float hareketHizi = 1f; // Canavarın hareket hızı
    public float sinirlamaSol = 5f; // Sol sınır koordinatı
    public float sinirlamaSag = 10f; // Sağ sınır koordinatı

    private Rigidbody2D rb;
    private int hareketYonu = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // X ekseni sınırlarını kontrol et
        if (transform.position.x >= sinirlamaSag && hareketYonu == 1)
        {
            hareketYonu = -1;
            transform.localScale = new Vector3(3f, 3f, 3f); // Canavarı sola döndür
        }
        else if (transform.position.x <= sinirlamaSol && hareketYonu == -1)
        {
            hareketYonu = 1;
            transform.localScale = new Vector3(-3f, 3f, 3f); // Canavarı sağa döndür
        }

        // Hareketi uygula
        rb.velocity = new Vector2(hareketHizi * hareketYonu, rb.velocity.y);
    }
}
