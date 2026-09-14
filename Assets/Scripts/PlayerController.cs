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
    //variable para almacenar el componente Animator del jugador
    private Animator animator;
    //variable para saber si el jugador esta mirando a la derecha o a la izquierda
    private bool facingRight = true; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>(); //obtiene el componente Rigidbody2D del objeto al que está adjunto este script
        animator = GetComponent<Animator>(); //obtiene el componente Animator del objeto al que está adjunto este script

    }

    // Update is called once per frame
    void Update()
    {
        //velocidad del jugador al moverse horizontalmente
        //obtener la locacion
        float move=Input.GetAxis("Horizontal");  //obtiene el valor de la entrada horizontal (teclas A y D o flechas izquierda y derecha)
        float speedAnimation = Mathf.Abs(move); //obtiene el valor absoluto de la velocidad del jugador para la animacion

        animator.SetFloat("Speed", speedAnimation); //asigna el valor de la velocidad del jugador a la variable Speed del Animator


        rb.velocity=new Vector2(move*moveSpeed,rb.velocity.y); //mueve el jugador en la direccion horizontal, se ocupa v2, porque es dos dimeniones

        //lado en el que esta viendo el jugador
        if(move>0 && !facingRight){
            Flip();//metodo que voltea al jugador
        }else if(move < 0 && facingRight){
            Flip();
        }


        //cotrol de salto del jugador y colision por Tags 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)//si se presiona la tecla espacio y el jugador esta en el suelo
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//agrega una fuerza hacia arriba al jugador para que salte
            isGrounded = false; //el jugador ya no esta en el suelo
            animator.SetBool("isJumping",true); //cambia el valor de la variable isJumping del Animator a true para que se reproduzca la animacion de salto
        }
    }

    void OnCollisionEnter2D(Collision2D colision){
        if(colision.gameObject.CompareTag("Ground")){
            isGrounded = true; // el jugador esta en el suelo
            animator.SetBool("isJumping",false); //cambia el valor de la variable isJumping del Animator a false para que se reproduzca la animacion de caminar
        }
    }

    //metodo que se llama cuando el jugador deja de colisionar con otro objeto
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Groud")){
            isGrounded=false;
        }
    }

    //creamos la funcion 
    void Flip(){
        //cambiamos el estado de orientacion
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        //volteamos 
        scale.x *=-1;
        transform.localScale = scale;
    }
}
