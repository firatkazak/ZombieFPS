using UnityEngine;
public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;//Oyuncu kamerasý.
    public Animator playerAnimator;//Animasyon için.
    public float range = 100f;//Merminin gideceði max mesafe.
    public float damage = 25f;//1 isabette vereceðimiz hasar
    private void Update()
    {
        /*if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }*/
        if (Input.GetButtonDown("Fire1"))//Ateþ tuþuna basýldýysa(sol týk)
        {
            Shoot();//Ateþ et.
        }
    }
    private void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);//Ateþ animasyonunu oynat.
        RaycastHit hit;//
        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        //Eðer Görünmez ýþýn, Player kamerasýnýn pozisyonunda, ileri doðru, 100 metre içinde vuruyorsa
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            //Düþmanýn pozisyonunun raycastini atadýk.
            if (enemyManager != null)//Eðer gönderdiðimiz görünmez ýþýn null deðil ise;
            {
                enemyManager.Hit(damage);//Hit fonksiyonunu damage kadar çalýþtýr.
            }
            //Mantýk: Sol týk ile ateþ edince görünmez ýþýn gönderiyoruz.
            //Bu gönderdiðimiz ýþýn boþa(null) deðil de zombiye temas edince caný düþecek.
        }
    }
}
