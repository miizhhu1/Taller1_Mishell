using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //referencia al componente Rigidbody2D del jugador
    private Rigidbody2D rb;
    //velocidad del jugador
    public float moveSpeed = 5f;
    //fuerza de salto del jugador
    public float jumpForce = 7f;
    
    //variable para saber si el jugador esta en el suelo    
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>(); //obtiene el componente Rigidbody2D del objeto al que está adjunto este script
    }

    // Update is called once per frame
    void Update()
    {
        //velocidad del jugador al moverse horizontalmente
        //obtener la locacion
        float move=Input.GetAxis("Horizontal");
        rb.velocity=new Vector2(move*moveSpeed,rb.velocity.y); //mueve el jugador en la direccion horizontal, se ocupa v2, porque es dos dimeniones
        //cotrol de salto del jugador y colision por Tags 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)//si se presiona la tecla espacio y el jugador esta en el suelo
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//agrega una fuerza hacia arriba al jugador para que salte
            isGrounded = false; //el jugador ya no esta en el suelo
        }
    }

    void OnCollisionEnter2D(Collision2D colision){
        if(colision.gameObject.CompareTag("Ground")){
            isGrounded = true; // el jugador esta en el suelo
        }
    }
}
