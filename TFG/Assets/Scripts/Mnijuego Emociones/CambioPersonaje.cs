using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioPersonaje : MonoBehaviour
{
    [Header("Atributos sprite")]
    public List<Emocion> emociones = new List<Emocion>();
    public List<Emocion> emocionesN2 = new List<Emocion>();
    public List<Emocion> emocionesN3 = new List<Emocion>();
    private List<Emocion> listaEmocionesActual = new List<Emocion>();

    public Emocion emocionActual;

    [Header("Atributos cambio sprite")]
    private float tiempoLimite;
    public int puntuacionParaPasarN2;
    public int puntuacionParaPasarN3;
    public Image barraTiempo;

    [Header("Puntuacion")]
    public int scoreDisminuir;
    public int scoreAumentar;

    [Header("Sprites emociones Nivel 1")]
    public Sprite alegriaSprite;
    public Sprite tristezaSprite;
    public Sprite enfadoSprite;
    public Sprite ascoSprite;
    public Sprite sorpresaSprite;
    public Sprite miedoSprite;

    [Header("Sprites emociones Nivel 2")]
    public Sprite alegriaSpriteN2;
    public Sprite tristezaSpriteN2;
    public Sprite enfadoSpriteN2;
    public Sprite ascoSpriteN2;
    public Sprite sorpresaSpriteN2;
    public Sprite miedoSpriteN2;

    [Header("Sprites emociones Nivel 3")]
    public Sprite alegriaSpriteN3;
    public Sprite tristezaSpriteN3;
    public Sprite enfadoSpriteN3;
    public Sprite ascoSpriteN3;
    public Sprite sorpresaSpriteN3;
    public Sprite miedoSpriteN3;


    [Header("Particle Systems")]
    public GameObject exitParticles;
    public GameObject failParticles;

    private float tiempoActual;
    private int indexEmocionActual;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        añadirEmociones();
        listaEmocionesActual = emociones;
        emocionActual = listaEmocionesActual[Random.Range(0, listaEmocionesActual.Count)];

        actualizarSprite();
        tiempoLimite = GameManager.Instance.maxTime;
        tiempoActual = tiempoLimite;

        Debug.Log(emocionActual.GetName());

    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoActual <= 0f) {
            GameManager.Instance.finish();
        }
        else
        {
            tiempoActual -= Time.deltaTime;
            barraTiempo.fillAmount = tiempoActual / tiempoLimite;
        }
    }

    void cambioEmocion() {

        if(GameManager.Instance.getScore() >= puntuacionParaPasarN2)
        {
            if(GameManager.Instance.getScore() >= puntuacionParaPasarN3)
            {
                listaEmocionesActual = emocionesN3;
            }
            else
            {
                listaEmocionesActual = emocionesN2;
            }
        }
        else
        {
            listaEmocionesActual = emociones;
        }

        Emocion nuevaEmocion = listaEmocionesActual[Random.Range(0, emociones.Count)];
        if(nuevaEmocion.GetName() != emocionActual.GetName())
        {
            emocionActual = nuevaEmocion;
            Debug.Log(emocionActual.GetName());
        }
        else{
            cambioEmocion();
        }

        GameManager.Instance.addRound();

        actualizarSprite();
    }

    public void comprobarEmocion(string emocion) {
        if (emocion == emocionActual.GetName()) {
            GameManager.Instance.aumentarScore(scoreAumentar);
            playParticles("exito");
        }
        else{
            GameManager.Instance.disminuirScore(scoreDisminuir);
            playParticles("fail");
        }
        
        cambioEmocion();
    }

    public void añadirEmociones() {
        emociones.Add(new Emocion("Alegria", alegriaSprite));
        emociones.Add(new Emocion("Asco", ascoSprite));
        emociones.Add(new Emocion("Tristeza", tristezaSprite));
        emociones.Add(new Emocion("Enfado", enfadoSprite));
        emociones.Add(new Emocion("Miedo", miedoSprite));
        emociones.Add(new Emocion("Sorpresa", sorpresaSprite));

        emocionesN2.Add(new Emocion("Alegria", alegriaSpriteN2));
        emocionesN2.Add(new Emocion("Asco", ascoSpriteN2));
        emocionesN2.Add(new Emocion("Tristeza", tristezaSpriteN2));
        emocionesN2.Add(new Emocion("Enfado", enfadoSpriteN2));
        emocionesN2.Add(new Emocion("Miedo", miedoSpriteN2));
        emocionesN2.Add(new Emocion("Sorpresa", sorpresaSpriteN2));

        emocionesN3.Add(new Emocion("Alegria", alegriaSpriteN3));
        emocionesN3.Add(new Emocion("Asco", ascoSpriteN3));
        emocionesN3.Add(new Emocion("Tristeza", tristezaSpriteN3));
        emocionesN3.Add(new Emocion("Enfado", enfadoSpriteN3));
        emocionesN3.Add(new Emocion("Miedo", miedoSpriteN3));
        emocionesN3.Add(new Emocion("Sorpresa", sorpresaSpriteN3));
    }

    void actualizarSprite()
    {
        renderer.sprite = emocionActual.GetSprite();
    }
    
    void resetTimer()
    {
        tiempoActual = tiempoLimite;
    }

    void playParticles(string type)
    {
        switch (type)
        {
            case "exito":
                GameObject particlesExit = Instantiate(exitParticles, transform);
                Destroy(particlesExit, 2f);
                break;
            case "fail":
                GameObject particlesFail = Instantiate(failParticles, transform);
                Destroy(particlesFail, 2f);
                break;
        }

    }

}
