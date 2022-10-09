using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;//Zombilerin spawnlanacaðý yerler.
    public GameObject enemyPrefab;//Zombi prefabý.
    public GameObject endScreen;//Oyun bittiðinde ekranda çýkacak butonlar, textler vs'ler için game objesi oluþturduk.
    public Text roundNumber;//Kaçýncý roundda olduðumuzu sol üst köþede gösterecek.
    public Text roundsSurvived;//Hayatta kaldýðýmýz Round sayýsýný tutuyor. Oyun bitince örn; "2 rounds survived" yazacak.
    public int enemiesAlive = 0;//Hayattaki zombi sayýsý.
    private int round = 0;//Round
    private void Update()
    {
        if (enemiesAlive == 0)//Zombi sayýsý 0 ise(O rounddaki bütün zombiler öldüyse)
        {
            round++;//Round sayýsýný 1 arttýr.
            NextWave(round);//Round sayýsý kadar NextWave fonksiyonunu çalýþtýr.
            //Mantýk: 1. Roundda 1, 2. roundda 2 vb. gibi her dalgada +1 zombi ile oyun zorlaþacak.
            roundNumber.text = "Round: " + round.ToString();//Round sayýsýný yazdýr.
        }
    }
    public void Restart()
    {
        Time.timeScale = 1;//Zamanýn gerçek hayattaki gibi olmasý için. Bunu 10 yaparsak aþýrý hýzlanýyor oyun mesela.
        SceneManager.LoadScene(0);//Ana ekrana geç.
    }
    public void NextWave(int round)//Dalga fonksiyonu. Her dalgada +1 düþman gelecek. 1. roundda 1, 2. roundda 2... þeklinde.
    {
        for (var x = 0; x < round; x++)//Döngüyü sýfýrdan baþlatýyoruz. Round sayýsýndan küçük olduðu sürece döngüyü 1 arttýrýyoruz.
        //Mantýk: Döngü round sayýsýndan daha büyük olamayacak, her düþman sýfýrlandýðýnda tekrar döngü çalýþacak.
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];//5 tane spawn noktamýz var. onlarý atadýk.
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            //5 spawn noktasýnýn her hangi 1 tanesinden spawn noktasýnýn pozisyonu ve açýsýnda enemy spawn edecek.
            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            //GameManager'da Instantiate ettiðimiz nesnenin komponentini EnemyManager'a atýyoruz.
            enemiesAlive++;//Her dalgada hayattaki zombi sayýsýný 1 arttýracak.
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;//Zamanýn gerçek hayattaki gibi olmasý için. Bunu 10 yaparsak aþýrý hýzlanýyor oyun mesela.
        SceneManager.LoadScene(1);//Game sahnesi 0, Menü sahnesi 1. Burada Menü sahnesini çaðýrýyoruz.
    }
    public void EndGame()
    {
        Time.timeScale = 0;//Yukarýda 1 yapmýþtýk. Oyun duracaðý için þimdi 0 yaptýk haliyle.
        Cursor.lockState = CursorLockMode.None;//Cursor'u kilitlemiþtik. Kaldýrdýk þimdi rahatça mouse'u oynatmak için.
        endScreen.SetActive(true);//Butonlarý, textleri attýðýmýz endscreen'i aktif ettik.
        roundsSurvived.text = round.ToString();//Hayatta kaldýðýmýz round sayýsýný string'e çevirdik.
    }
}
