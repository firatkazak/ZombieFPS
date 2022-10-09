using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public Transform playerBody;//Player'ýn Transformu için.
    private float xRotation = 0.0f;//X rotasyonu.
    private float mouseSensitivity = 500f;//Mouse hassasiyeti.
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Mouse'u kilitleme için.
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;//Mouse'un X çýkýþý.
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;//Mouse'un Y çýkýþý.
        //Alttaki satýrlar mouse aþaðý yukarý hareket ettiðinde ayný yönde bedenin de hareket etmesi için.
        xRotation -= mouseY;//Burayý artý yaparsan Mouse'u ileri itince Player aþaðý bakar. - yapýnca istediðimiz þekilde bakar. 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//yukarý ve aþaðý 90 derece ile bakýyor o yüzden bu fonksiyonu kullandýk.
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);//Bu x açýsýný mevcut konuma atadýk.
        playerBody.Rotate(Vector3.up * mouseX);//Player ile birlikte Yukarý aþaðý bedenin de hareket etmesi için.
    }
}
