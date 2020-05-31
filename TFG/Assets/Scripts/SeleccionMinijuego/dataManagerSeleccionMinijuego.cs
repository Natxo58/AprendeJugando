using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataManagerSeleccionMinijuego : MonoBehaviour
{
    public Text highScoreEmociones;
    public Text highScoreReflejos;
    public Text highScoreManzanas;
    public Text highScorePuzzles;
    public Text highScoreColorear;
    public Text highScoreConversaciones;
    public Text highScoreMemoria;
    public Text highScoreContar;
    public Text highScoreLaberinto;
    public Text highScoreOrdenar;
    public Text highScoreFiguras;
    public Text highScoreObjetos;
    public Text highScoreEmpatia;

    // Start is called before the first frame update
    void Start()
    {
        if (highScoreEmociones != null) highScoreEmociones.text = PlayerPrefs.GetInt("maxEmociones", 0).ToString();
        if (highScorePuzzles != null) highScorePuzzles.text = PlayerPrefs.GetInt("maxPuzzles", 0).ToString();
        if (highScoreReflejos != null) highScoreReflejos.text = PlayerPrefs.GetFloat("maxReflejos", 10f).ToString();
        if (highScoreManzanas != null) highScoreManzanas.text = PlayerPrefs.GetInt("maxManzanas", 0).ToString();
        if (highScoreColorear != null) highScoreColorear.text = PlayerPrefs.GetInt("maxColorear", 0).ToString();
        if (highScoreConversaciones != null) highScoreConversaciones.text = PlayerPrefs.GetInt("maxConversaciones", 50).ToString();
        if (highScoreMemoria != null) highScoreMemoria.text = PlayerPrefs.GetInt("maxMemoria", 0).ToString();
        if (highScoreContar != null) highScoreContar.text = PlayerPrefs.GetInt("maxContar", 0).ToString();
        if (highScoreLaberinto != null) highScoreLaberinto.text = PlayerPrefs.GetInt("maxLaberinto", 0).ToString();
        if (highScoreOrdenar != null) highScoreOrdenar.text = PlayerPrefs.GetInt("maxOrdenar", 0).ToString();
        if (highScoreFiguras != null) highScoreFiguras.text = PlayerPrefs.GetInt("maxFiguras", 0).ToString();
        if (highScoreObjetos != null) highScoreObjetos.text = PlayerPrefs.GetInt("maxObjetos", 0).ToString();
        if (highScoreEmpatia != null) highScoreEmpatia.text = PlayerPrefs.GetInt("maxEmpatia", 0).ToString();
    }

}
