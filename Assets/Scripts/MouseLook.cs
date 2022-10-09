using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public Transform playerBody;//Player'�n Transformu i�in.
    private float xRotation = 0.0f;//X rotasyonu.
    private float mouseSensitivity = 500f;//Mouse hassasiyeti.
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Mouse'u kilitleme i�in.
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;//Mouse'un X ��k���.
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;//Mouse'un Y ��k���.
        //Alttaki sat�rlar mouse a�a�� yukar� hareket etti�inde ayn� y�nde bedenin de hareket etmesi i�in.
        xRotation -= mouseY;//Buray� art� yaparsan Mouse'u ileri itince Player a�a�� bakar. - yap�nca istedi�imiz �ekilde bakar. 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//yukar� ve a�a�� 90 derece ile bak�yor o y�zden bu fonksiyonu kulland�k.
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);//Bu x a��s�n� mevcut konuma atad�k.
        playerBody.Rotate(Vector3.up * mouseX);//Player ile birlikte Yukar� a�a�� bedenin de hareket etmesi i�in.
    }
}
