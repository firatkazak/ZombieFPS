using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;//Zombilerin spawnlanaca�� yerler.
    public GameObject enemyPrefab;//Zombi prefab�.
    public GameObject endScreen;//Oyun bitti�inde ekranda ��kacak butonlar, textler vs'ler i�in game objesi olu�turduk.
    public Text roundNumber;//Ka��nc� roundda oldu�umuzu sol �st k��ede g�sterecek.
    public Text roundsSurvived;//Hayatta kald���m�z Round say�s�n� tutuyor. Oyun bitince �rn; "2 rounds survived" yazacak.
    public int enemiesAlive = 0;//Hayattaki zombi say�s�.
    private int round = 0;//Round
    private void Update()
    {
        if (enemiesAlive == 0)//Zombi say�s� 0 ise(O rounddaki b�t�n zombiler �ld�yse)
        {
            round++;//Round say�s�n� 1 artt�r.
            NextWave(round);//Round say�s� kadar NextWave fonksiyonunu �al��t�r.
            //Mant�k: 1. Roundda 1, 2. roundda 2 vb. gibi her dalgada +1 zombi ile oyun zorla�acak.
            roundNumber.text = "Round: " + round.ToString();//Round say�s�n� yazd�r.
        }
    }
    public void Restart()
    {
        Time.timeScale = 1;//Zaman�n ger�ek hayattaki gibi olmas� i�in. Bunu 10 yaparsak a��r� h�zlan�yor oyun mesela.
        SceneManager.LoadScene(0);//Ana ekrana ge�.
    }
    public void NextWave(int round)//Dalga fonksiyonu. Her dalgada +1 d��man gelecek. 1. roundda 1, 2. roundda 2... �eklinde.
    {
        for (var x = 0; x < round; x++)//D�ng�y� s�f�rdan ba�lat�yoruz. Round say�s�ndan k���k oldu�u s�rece d�ng�y� 1 artt�r�yoruz.
        //Mant�k: D�ng� round say�s�ndan daha b�y�k olamayacak, her d��man s�f�rland���nda tekrar d�ng� �al��acak.
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];//5 tane spawn noktam�z var. onlar� atad�k.
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            //5 spawn noktas�n�n her hangi 1 tanesinden spawn noktas�n�n pozisyonu ve a��s�nda enemy spawn edecek.
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            //GameManager'da Instantiate etti�imiz nesnenin komponentini EnemyManager'a at�yoruz.
            enemiesAlive++;//Her dalgada hayattaki zombi say�s�n� 1 artt�racak.
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;//Zaman�n ger�ek hayattaki gibi olmas� i�in. Bunu 10 yaparsak a��r� h�zlan�yor oyun mesela.
        SceneManager.LoadScene(1);//Game sahnesi 0, Men� sahnesi 1. Burada Men� sahnesini �a��r�yoruz.
    }
    public void EndGame()
    {
        Time.timeScale = 0;//Yukar�da 1 yapm��t�k. Oyun duraca�� i�in �imdi 0 yapt�k haliyle.
        Cursor.lockState = CursorLockMode.None;//Cursor'u kilitlemi�tik. Kald�rd�k �imdi rahat�a mouse'u oynatmak i�in.
        endScreen.SetActive(true);//Butonlar�, textleri att���m�z endscreen'i aktif ettik.
        roundsSurvived.text = round.ToString();//Hayatta kald���m�z round say�s�n� string'e �evirdik.
    }
}
