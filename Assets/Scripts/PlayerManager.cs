using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;//Game Manager'da i�lem yapaca��z.
    public Text healthText;//Can g�stergesi
    public float health = 100;//Can
    public void Hit(float damage)//EnemyManager'daki damage
    {
        health -= damage;//damage'i health'ten ��kartacak. 100 ise vurunca 80 olacak.
        healthText.text = "Health: " + health.ToString();//string'e �evirecek.
        if (health <= 0)//Can�m�z 0 ya da daha az olursa(mant�ken �l�r�z.)
        {
            gameManager.EndGame();//GameManager class'�ndaki EndGame fonksiyonunu �al��t�r.
        }
    }
}
