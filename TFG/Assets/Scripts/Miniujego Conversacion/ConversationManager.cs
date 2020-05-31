using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    [Header("Conversaciones")]
    [Space]
    public Conversacion[] conversaciones;
    public int indexConversacion;

    [Space]
    [Header("UI Atributes")]
    public Text Conversacion;
    public Text opcion1;
    public Text opcion2;
    public Text opcion3;
    public Text felicidadText;
    public Image barraBackground;
    public Image barraTiempo;
    public GameObject finalPanel;
    public GameObject tutorial;

    [Header("Felicidad Atributos")]
    public float felicidad = 5f;
    private float maxFelicidad = 10f;
    public Color colorRojo;
    public Color colorAmarillo;
    public Color colorVerde;
    public Image caraActual;
    public Sprite caraFeliz;
    public Sprite caraNeutra;
    public Sprite caraTriste;

    List<Contestacion> contestacionesActuales = new List<Contestacion>();
    Color colorBarra;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(true);
        actualizarBarras();
        newConversacion();
    }

    void newConversacion()
    {
        if (indexConversacion >= conversaciones.Length)
        {
            displayGameOver();
            return;
        }

        contestacionesActuales.Clear();
        Conversacion conversacionActual = conversaciones[indexConversacion];
        indexConversacion++;

        Conversacion.text = conversacionActual.texto;

        while (contestacionesActuales.Count < 3)
        {
            Contestacion contestacion = conversacionActual.contestacionRandom();
            if (!contestacionesActuales.Contains(contestacion))
            {
                contestacionesActuales.Add(contestacion);
            }
        }

        opcion1.text = contestacionesActuales[0].text;
        opcion2.text = contestacionesActuales[1].text;
        opcion3.text = contestacionesActuales[2].text;
    }

    public void pressOpcion1()
    {
        felicidad += contestacionesActuales[0].felicidadChanger;
        felicidad = Mathf.Clamp(felicidad, 0, 10);
        actualizarBarras();
        felicidadScore();
        newConversacion();
        doButtonSound();
    }

    public void pressOpcion2()
    {
        felicidad += contestacionesActuales[1].felicidadChanger;
        felicidad = Mathf.Clamp(felicidad, 0, 10);
        actualizarBarras();
        felicidadScore();
        newConversacion();
        doButtonSound();
    }

    public void pressOpcion3()
    {
        felicidad += contestacionesActuales[2].felicidadChanger;
        felicidad = Mathf.Clamp(felicidad, 0, 10);
        actualizarBarras();
        felicidadScore();
        newConversacion();
        doButtonSound();
    }

    private void actualizarBarras()
    {
        if (felicidad < 4)
        {
            colorBarra = colorRojo;
            caraActual.sprite = caraTriste;
        }
        else if (felicidad >= 4 && felicidad <= 6)
        {
            colorBarra = colorAmarillo;
            caraActual.sprite = caraNeutra;
        }
        else
        {
            colorBarra = colorVerde;
            caraActual.sprite = caraFeliz;
        }

        barraBackground.color = colorBarra;
        barraTiempo.color = colorBarra;
        barraTiempo.fillAmount = (felicidad / maxFelicidad);
    }

    private void felicidadScore()
    {
        if (felicidad > PlayerPrefs.GetInt("maxConversaciones", 0))
        {
            PlayerPrefs.SetInt("maxConversaciones", (int)felicidad);
        }
    }

    public void cerrarTutorial()
    {
        ButtonSoundManager.Instance.playButtonSound();
        tutorial.SetActive(false);
        Time.timeScale = 1f;
    }

    private void displayGameOver()
    {
        if(felicidad < 4)
            felicidadText.text = "Has enfadado a la otra persona!";
        else
            if(felicidad <= 6)
                felicidadText.text = "La otra persona se siente normal";
            else
                felicidadText.text = "Has hecho feliz a la otra persona!";

        finalPanel.SetActive(true);
    }

    private void doButtonSound()
    {
        audioManagerConversaciones.Instance.sonidoButtonAnswer();
    }

}
