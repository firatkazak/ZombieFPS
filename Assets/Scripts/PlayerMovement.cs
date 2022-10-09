using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;//CharacterController class'�ndan controller tan�mlad�k.
    private Vector3 velocity;//velocity tan�mlad�k.
    public Transform groundCheck;//Yere de�ip de�medi�ini kontrol etmek i�in.
    public LayerMask groundMask;//LayerMask tan�mlad�k.
    public bool isOnGround = true;//Yerde olup olmad��� ile ilgili boolean de�i�ken.
    public float speed = 12.0f;//H�z.
    private float gravity = -9.81f;//Yer �ekimi.
    public float groundDistance = 0.4f;//Zemin mesafesi.Radius
    private float jumpHeight = 2.0f;//Z�plama y�ksekli�i.
    private void Update()
    {
        //isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        /*Yere de�ip de�medi�ini bu kod ile kontrol ettik.
        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }*/
        float x = Input.GetAxis("Horizontal");//Horizontal ��k��.
        float z = Input.GetAxis("Vertical");//Vertical ��k��.
        //hareket ��k��� a�a��da. z ileri geri, x sa� sol.
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        //Hareket ��k���na h�z ve deltaTime eklendi.
        velocity.y += gravity * Time.deltaTime;//Yer �ekimi kodu.
        controller.Move(velocity * Time.deltaTime);//delta time ve velocity eklendi.
        if (Input.GetButtonDown("Jump"))//Z�plama tu�una bas�lm��sa(Space)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);//Z�pla(gravity ile yere d��ecek.)
        }
    }
}
