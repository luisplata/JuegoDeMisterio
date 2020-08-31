using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoInteractuable : MonoBehaviour
{
    [TextArea]
    [Tooltip("A string using the TextArea attribute")]
    public string dialogoBueno, dialogoMalo, dialogoFinal;
    public List<ObjetoInteractuable> aristas;
    private TeoriaDeGrafos padre;
    private Button boton;
    public int distancia;
    public bool visitado = false;
    public GameObject botonMapaGeneral;
    private void Start()
    {
        padre = GameObject.Find("ControladorDeEscenario").GetComponent<TeoriaDeGrafos>();
        //gameObject.AddComponent<Button>();
        //GetComponent<Button>().onClick.AddListener(delegate { EventoDeClickAgregado(); });
    }

    //preguntar si es el objeto final
    //si no mostar dialogos
    public void GenerarDialogosDeAristas()
    {
        List<string> dialogos = new List<string>();
        //Debug.Log(padre.verticeFinal.gameObject.name + " - " + this.name+ " son iguales -> "+ padre.verticeFinal.Equals(this));
        if (padre.verticeFinal.Equals(this))
        {
            if (PlayerPrefs.GetString("escenaSeleccionada").Equals(ConstantesDelProyecto.ESCENA_MAPA_IGLESIA))
            {
                dialogos.Add(padre.dialogoSegunElTiempoTranscurrido());
            }
            else
            {
                dialogos.Add(dialogoFinal);
            }
            botonMapaGeneral.SetActive(true);
            
        }
        else
        {
            dialogos = padre.DialogosDeEsteObjeto(this);   
        }
        TextMeshProUGUI texto = GameObject.Find("CajaDeDialogos").GetComponent<TextMeshProUGUI>();
        texto.text = string.Empty;
        foreach(string s in dialogos)
        {
            texto.text += s + "\n";
        }
    }
}
