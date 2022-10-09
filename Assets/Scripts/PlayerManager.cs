using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;//Game Manager'da iþlem yapacaðýz.
    public Text healthText;//Can göstergesi
    public float health = 100;//Can
    public void Hit(float damage)//EnemyManager'daki damage
    {
        health -= damage;//damage'i health'ten çýkartacak. 100 ise vurunca 80 olacak.
        healthText.text = "Health: " + health.ToString();//string'e çevirecek.
        if (health <= 0)//Canýmýz 0 ya da daha az olursa(mantýken ölürüz.)
        {
            gameManager.EndGame();//GameManager class'ýndaki EndGame fonksiyonunu çalýþtýr.
        }
    }
}
