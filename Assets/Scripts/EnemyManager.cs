using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
    public GameObject player;//Player'i takip edecek. Onun i�in.
    public Animator enemyAnimator;//Zombi animasyonu i�in.
    public GameManager gameManager;//GameManager scriptine eri�mek i�in.
    public float damage = 20f;//Bize her vurdu�unda verece�i hasar.
    public float health = 100f;//D��man can�.
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//Player'imizi atad�k.
    }
    public void Hit(float damage)
    {
        health -= damage;//Damage'i Health'ten d��.
        if (health <= 0)//E�er can 0 ya da 0'dan az ise;
        {
            gameManager.enemiesAlive--;//GameManager'da ya�ayan zombi say�s� diye bir de�i�ken var.
            //Diyelim ki ekranda 3 tane zombi var. 1 tanesi �l�nce o say� 2'ye d��ecek. 0 olunca yeni zombiler geliyor. Onun i�in.
            Destroy(gameObject);//Zombiyi yok et.
        }
    }
    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;//oyuncunun konumunu zombinin NavMeshAgent'ine ata.
        //destination d�nya �zerindeki konumunu almam�za yar�yor. Unutma.
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)//NavMesh'in mevcut h�z�n�n b�y�kl��� 1'den b�y�k ise;
        {
            enemyAnimator.SetBool("isRunning", true);//Ko�ma animasyonunu aktif et.
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);//Ko�ma animasyonunu iptal et.
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)//E�er zombi Player'a temas ederse
        {
            player.GetComponent<PlayerManager>().Hit(damage);//Player'a 20 can hasar verecek.
        }
    }
}
