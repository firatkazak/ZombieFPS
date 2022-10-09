using UnityEngine;
public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;//Oyuncu kameras�.
    public Animator playerAnimator;//Animasyon i�in.
    public float range = 100f;//Merminin gidece�i max mesafe.
    public float damage = 25f;//1 isabette verece�imiz hasar
    private void Update()
    {
        /*if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }*/
        if (Input.GetButtonDown("Fire1"))//Ate� tu�una bas�ld�ysa(sol t�k)
        {
            Shoot();//Ate� et.
        }
    }
    private void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);//Ate� animasyonunu oynat.
        RaycastHit hit;//
        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        //E�er G�r�nmez ���n, Player kameras�n�n pozisyonunda, ileri do�ru, 100 metre i�inde vuruyorsa
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            //D��man�n pozisyonunun raycastini atad�k.
            if (enemyManager != null)//E�er g�nderdi�imiz g�r�nmez ���n null de�il ise;
            {
                enemyManager.Hit(damage);//Hit fonksiyonunu damage kadar �al��t�r.
            }
            //Mant�k: Sol t�k ile ate� edince g�r�nmez ���n g�nderiyoruz.
            //Bu g�nderdi�imiz ���n bo�a(null) de�il de zombiye temas edince can� d��ecek.
        }
    }
}
