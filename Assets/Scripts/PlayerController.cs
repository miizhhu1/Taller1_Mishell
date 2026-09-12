using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //velocidad del jugador
    public float moveSpeed = 5f;
    //fuerza de salto del jugador
    public float jumpForce = 10f;
    //referencia al componente Rigidbody2D del jugador
    private Rigidbody2D rb;
    //variable para saber si el jugador esta en el suelo    
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd=GetComponent<Rigidbody2D>(); //obtiene el componente Rigidbody2D del objeto al que está adjunto este script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
