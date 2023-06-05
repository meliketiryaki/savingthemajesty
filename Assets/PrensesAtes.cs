using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrensesAtes : MonoBehaviour
{
    public GameObject mermiPrefab; // Mermi prefabı
    public Transform atisNoktasi; // Mermi atış noktası
    
    private GameObject atilanMermi; // Son atılan mermi
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AtisYap();
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
        mermiRigidbody.velocity = new Vector2(15f, 0f);

        // Atılan mermiyi kaydet
        atilanMermi = yeniMermi;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("kralice"))
        {
            // Çarpışma durumunda mermiyi yok et
            Destroy(gameObject);
        }
    }
}
