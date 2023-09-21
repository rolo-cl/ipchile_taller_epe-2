using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeScript : MonoBehaviour
{

    public float velocidad;
    public float fuerzaSalto;
    private Rigidbody2D rigidbody;

    private bool mirandoDerecha = true;

    public AudioSource Jump_01;

    // Start is called before the first frame update
    void Start()
    {
        // --------------------------------------------------
        //this.Jump_01 = GetComponent<AudioSource>();
        //this.Jump_01 = new AudioSource();
        // --------------------------------------------------
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ProcesarMovimiento();
        this.ProcesarSalto();
    }

    void ProcesarSalto()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump_01.Play();
            this.rigidbody.AddForce(Vector2.up * this.fuerzaSalto , ForceMode2D.Impulse );
        }
    }

    void ProcesarMovimiento()
    {
        float inputPositionAxisX = Input.GetAxis("Horizontal");
        this.rigidbody.velocity = new Vector2(inputPositionAxisX * velocidad, this.rigidbody.velocity.y);
        this.GestionarOrientacion(inputPositionAxisX);
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        Debug.Log("valor this.mirandoDerecha -> " + this.mirandoDerecha);
        if (
            (this.mirandoDerecha == true && inputMovimiento < 0)
             ||
            (this.mirandoDerecha == false && inputMovimiento > 0)
           )
        {
            Debug.Log("------------------------");
            this.mirandoDerecha = !this.mirandoDerecha;
            Debug.Log("Nuevo valor this.mirandoDerecha -> " + this.mirandoDerecha);
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            Debug.Log("------------------------");
        }
    }

}
