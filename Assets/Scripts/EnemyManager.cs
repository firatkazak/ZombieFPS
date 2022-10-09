using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    public GameObject player;//Player'i takip edecek. Onun için.
    public Animator enemyAnimator;//Zombi animasyonu için.
    public GameManager gameManager;//GameManager scriptine eriþmek için.
    public float damage = 20f;//Bize her vurduðunda vereceði hasar.
    public float health = 100f;//Düþman caný.
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//Player'imizi atadýk.
    }
    public void Hit(float damage)
    {
        health -= damage;//Damage'i Health'ten düþ.
        if (health <= 0)//Eðer can 0 ya da 0'dan az ise;
        {
            gameManager.enemiesAlive--;//GameManager'da yaþayan zombi sayýsý diye bir deðiþken var.
            //Diyelim ki ekranda 3 tane zombi var. 1 tanesi ölünce o sayý 2'ye düþecek. 0 olunca yeni zombiler geliyor. Onun için.
            Destroy(gameObject);//Zombiyi yok et.
        }
    }
    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;//oyuncunun konumunu zombinin NavMeshAgent'ine ata.
        //destination dünya üzerindeki konumunu almamýza yarýyor. Unutma.
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)//NavMesh'in mevcut hýzýnýn büyüklüðü 1'den büyük ise;
        {
            enemyAnimator.SetBool("isRunning", true);//Koþma animasyonunu aktif et.
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);//Koþma animasyonunu iptal et.
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)//Eðer zombi Player'a temas ederse
        {
            player.GetComponent<PlayerManager>().Hit(damage);//Player'a 20 can hasar verecek.
        }
    }
}
