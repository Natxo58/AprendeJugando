using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboBajar : MonoBehaviour
{
    [Header("Cubo atributes")]
    public GameObject boton;
    public float maxSpeed;
    public float aceleracion;
    public GameObject stopPoint;
    public bool enMeta;


    [Header("Bocadillo atributes")]
    public GameObject bocadillo;
    public Text textoBocadillo;


    private float currentVelocity;
    private bool activado;
    private bool parado;
    private Vector3 posInicial;
    private Color colorInicial;


    private void Start()
    {
        enMeta = false;
        bocadillo.SetActive(false);
        posInicial = transform.position;
        colorInicial = boton.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (activado)
        {
            currentVelocity = currentVelocity + (aceleracion * Time.deltaTime);
            currentVelocity = Mathf.Clamp(currentVelocity, 0, maxSpeed);

            transform.Translate(currentVelocity, 0, 0);
        }
    }

    void resetPosition()
    {
        boton.GetComponentInChildren<Text>().text = "Activar";
        transform.position = posInicial;
        currentVelocity = 0;
        activado = false;
        parado = false;
        enMeta = false;
        randomAccelerationSpeed();
        bocadillo.SetActive(false);
    }


    public void activarBoton()
    {
        gameManagerCubo.Instance.playSoundStartAumDificultad();

        boton.GetComponentInChildren<Text>().text = "Reset";
        if (parado)
        {
            resetPosition();
            return;
        }

        activado = true;
    }

    public void pararCubo()
    {
        gameManagerCubo.Instance.playSoundStopDismDificultad();

        if(parado != true)
        {
            activado = false;
            parado = true;
            calcularDistancia();
        }
    }

    public void calcularDistancia()
    {
        float distancia = Vector2.Distance(stopPoint.transform.position, transform.position);
        var resultado = (Mathf.Round(distancia * 1000)) / 1000.0;

        string chatString = "";
        string color = "";

        if (enMeta)
        {
            chatString = "Muy bien! Lo has conseguido!";
            color = "verde";
        }
        else
        {
            if (distancia > 3)
            {
                chatString = "Intentalo de nuevo!";
                color = "rojo";
            }else
            {
                chatString = "Casi lo tienes! Prueba de nuevo!";
                color = "amarillo";
            }
        }

        textoBocadillo.text = chatString;

        switch (color)
        {
            case "verde":
                textoBocadillo.color = Color.green;
                break;
            case "amarillo":
                textoBocadillo.color = Color.yellow;
                break;
            case "rojo":
                textoBocadillo.color = Color.red;
                break;
        }

        bocadillo.SetActive(true);

        if(resultado < PlayerPrefs.GetFloat("maxReflejos", 10f))
        {
            PlayerPrefs.SetFloat("maxReflejos", (float)resultado);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meta")
        {
            enMeta = true;
        }

        if (collision.tag == "Reset")
        {
            resetPosition();

            bocadillo.SetActive(true);
            Invoke("quitarBocadillo", 1f);
            desactivarBotonActivar();
            textoBocadillo.text = "Te has pasado!";
            textoBocadillo.color = Color.grey;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Meta")
        {
            enMeta = false;
        }
    }

    private void quitarBocadillo()
    {
        bocadillo.SetActive(false);
    }

    private void desactivarBotonActivar()
    {
        boton.GetComponent<Button>().interactable = false;
        boton.GetComponent<Image>().color = Color.grey;
        Invoke("activarBotonActivar", 1f);
    }

    private void activarBotonActivar()
    {
        boton.GetComponent<Button>().interactable = true;
        boton.GetComponent<Image>().color = colorInicial;
    }


    public void randomAccelerationSpeed()
    {
        aceleracion = Random.Range(0.25f, 0.45f);
        maxSpeed = Random.Range(7f, 10f);
    }
}
