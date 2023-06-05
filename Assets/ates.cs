using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ates : MonoBehaviour
{
    public GameObject mermiPrefab; // Merminin prefabı
    public Transform atisNoktasi; // Merminin atılacağı nokta
    public float atisSuresi = 5f; // Atış aralığı

    private float zamanSayaci = 0f;
    private GameObject atilanMermi; // Son atılan mermi

    private void Update()
    {
        zamanSayaci += Time.deltaTime;

        if (zamanSayaci >= atisSuresi)
        {
            AtisYap();
            zamanSayaci = 0f;
        }
    }

    private void AtisYap()
    {
        // Daha önce atılan mermiyi yok et
        if (atilanMermi != null)
        {
            Destroy(atilanMermi);
        }

        // Merminin prefabından yeni bir mermi oluştur
        GameObject yeniMermi = Instantiate(mermiPrefab, atisNoktasi.position, Quaternion.identity);

        // Mermiye hız vermek için Rigidbody bileşenini al
        Rigidbody2D mermiRigidbody = yeniMermi.GetComponent<Rigidbody2D>();

        // Mermiyi hareket ettir (örneğin sadece x ekseni üzerinde hareket ettirme)
        mermiRigidbody.velocity = new Vector2(-8f, 0f);

        // Atılan mermiyi kaydet
        atilanMermi = yeniMermi;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Çarpışma durumunda mermiyi yok et
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Çarpışma durumunda mermiyi yok et
            Destroy(gameObject);
        }
    }
}
