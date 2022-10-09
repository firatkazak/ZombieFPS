using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;//CharacterController class'ýndan controller tanýmladýk.
    private Vector3 velocity;//velocity tanýmladýk.
    public Transform groundCheck;//Yere deðip deðmediðini kontrol etmek için.
    public LayerMask groundMask;//LayerMask tanýmladýk.
    public bool isOnGround = true;//Yerde olup olmadýðý ile ilgili boolean deðiþken.
    public float speed = 12.0f;//Hýz.
    private float gravity = -9.81f;//Yer çekimi.
    public float groundDistance = 0.4f;//Zemin mesafesi.Radius
    private float jumpHeight = 2.0f;//Zýplama yüksekliði.
    private void Update()
    {
        //isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        /*Yere deðip deðmediðini bu kod ile kontrol ettik.
        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }*/
        float x = Input.GetAxis("Horizontal");//Horizontal çýkýþ.
        float z = Input.GetAxis("Vertical");//Vertical çýkýþ.
        //hareket çýkýþý aþaðýda. z ileri geri, x sað sol.
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        //Hareket çýkýþýna hýz ve deltaTime eklendi.
        velocity.y += gravity * Time.deltaTime;//Yer çekimi kodu.
        controller.Move(velocity * Time.deltaTime);//delta time ve velocity eklendi.
        if (Input.GetButtonDown("Jump"))//Zýplama tuþuna basýlmýþsa(Space)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);//Zýpla(gravity ile yere düþecek.)
        }
    }
}
