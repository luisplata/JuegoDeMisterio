using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeDialogos : MonoBehaviour
{
    private string genero, piel, ropa;
    public GameObject UIDeTexto, imagenBarman, imagenBarmanColor, panelDeOpciones, panelDerecha, panelIzquierda, panelUI, canvasBloodPower, panelDeFondoBarman, botonMapaGeneral;
    public TextMeshProUGUI textoParaMostrar, textoOpcion1, textoOpcion2;
    public Button botonSiguiente;
    private int indiceDeDialogo = 0;
    private Queue<Dialogo> colaDeDialogo;
    private Dialogo dialogoAndante;
    public DialogoFactory factoriaDeDialogos;
    public SpriteRenderer fondo;
    public PersonajeBuilder personajeBuilder;
    public Genero masculino, femenino;
    public Piel blanca, negra;
    public Ropa azul, roja;
    // Start is called before the first frame update
    void Start()
    {
        //creamos la fila
        colaDeDialogo = new Queue<Dialogo>();
        foreach(Dialogo encontrado in factoriaDeDialogos.dialogosFactory)
        {
            colaDeDialogo.Enqueue(encontrado);
        }
        
        //oscurecemos el fondo
        fondo.color = Color.black;
        //colocarleEventoAlBoton
        botonSiguiente.onClick.AddListener(DialogoSiguiente);
        DialogoSiguiente();
        //desactivamos los botones


        textoOpcion1.gameObject.GetComponent<Button>().onClick.AddListener(Opcion1Precionado);
        textoOpcion2.gameObject.GetComponent<Button>().onClick.AddListener(Opcion2Precionado);

        //seteamos todos los PlayerPref
        PlayerPrefs.DeleteAll();
    }

    private void DialogoSiguiente()
    {
        //Preguntamos si hay o no mas dialogos para terminar esta parte
        if (colaDeDialogo.Count <= 0)
        {
            //apagar todo de los dialgos
            panelDeFondoBarman.SetActive(false);
            UIDeTexto.SetActive(false);
            //encender todo de la mecanica principal
            panelDerecha.SetActive(true);
            panelIzquierda.SetActive(true);
            panelUI.SetActive(true);
            canvasBloodPower.SetActive(true);

            //mostramos el build del personaje
            personajeBuilder.Build();

            //desactiva los botones de mapa general, y power blood
            botonMapaGeneral.SetActive(false);



            return;
        }
        UIDeTexto.SetActive(true);
        dialogoAndante = factoriaDeDialogos.Create(colaDeDialogo.Peek().Id);
        dialogoAndante.referencia = this;

        switch (dialogoAndante.Id)
        {
            case ConstantesDelProyecto.DIALOGO10:
                //crear el datetime
                PlayerPrefs.SetString("tiempo", DateTime.Now.Hour + ":" + DateTime.Now.Minute);
                Debug.LogWarning(PlayerPrefs.GetString("tiempo"));
                break;
            case ConstantesDelProyecto.DIALOGO20:
                fondo.color = Color.white;
                imagenBarman.SetActive(true);
                break;
            case ConstantesDelProyecto.DIALOGO21:
                imagenBarman.SetActive(false);
                imagenBarmanColor.SetActive(true);
                break;
        }

        //cuando sean iguales cambiamos de dialogo
        if (indiceDeDialogo >= dialogoAndante.Dialogos.Count)
        {
            colaDeDialogo.Dequeue();
            indiceDeDialogo = 0;
            DialogoSiguiente();
        }
        else
        {
            if(dialogoAndante.Dialogos[indiceDeDialogo].Split('|').Length > 1)
            {
                //ocultamos boton de siguiente
                botonSiguiente.gameObject.SetActive(false);
                //mostramos las opciones
                textoParaMostrar.text = "";
                panelDeOpciones.SetActive(true);
                textoOpcion1.text = dialogoAndante.Dialogos[indiceDeDialogo].Split('|')[0];
                textoOpcion2.text = dialogoAndante.Dialogos[indiceDeDialogo].Split('|')[1];
            }
            else
            {
                textoParaMostrar.text = dialogoAndante.Dialogos[indiceDeDialogo];
            }
            indiceDeDialogo++;
        }
    }

    private void Opcion1Precionado()
    {
        //dejarlo todo como estaba
        panelDeOpciones.SetActive(false);
        botonSiguiente.gameObject.SetActive(true);
        dialogoAndante.Opcion1(ref personajeBuilder);
        DialogoSiguiente();
    }

    private void Opcion2Precionado()
    {
        panelDeOpciones.SetActive(false);
        botonSiguiente.gameObject.SetActive(true);
        dialogoAndante.Opcion2(ref personajeBuilder);
        DialogoSiguiente();
    }
}
