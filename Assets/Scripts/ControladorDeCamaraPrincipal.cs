using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorDeCamaraPrincipal : MonoBehaviour
{
    public List<GameObject> referenciasDePantalla;
    public int referenciaInicial;
    public GameObject panelIzquierdo, panelDerecho, panelDeDialogo, botonSiguiente, botonCerrar;
    public Image blooPower;
    private float deltaTimeLocalParaBloodPower;
    [SerializeField]
    private float tiempoQuePuedeUsarElBloodPower;
    private bool comenzarContarTiempoDeBloodPower;
    private Button botonDeBloodPower;
    public bool corutinaParametrizable = true;

    private void Start()
    {
        //buscamos la mitad de la lista
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<Rigidbody2D>().MovePosition(referenciasDePantalla[referenciaInicial].transform.position);

    }

    private void Update()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Rigidbody2D>().velocity = referenciasDePantalla[referenciaInicial].transform.position - GameObject.FindGameObjectWithTag("GameController").transform.position;
        if (comenzarContarTiempoDeBloodPower)
        {
            deltaTimeLocalParaBloodPower += Time.deltaTime;
            botonDeBloodPower.gameObject.GetComponent<Image>().fillAmount = (deltaTimeLocalParaBloodPower / tiempoQuePuedeUsarElBloodPower);
            if (deltaTimeLocalParaBloodPower >= tiempoQuePuedeUsarElBloodPower)
            {
                StartCoroutine(FadeOut());
                deltaTimeLocalParaBloodPower = 0;
                comenzarContarTiempoDeBloodPower = false;
            }
        }
    }


    public void ClickIzquierda()
    {
        panelDerecho.SetActive(true);
        referenciaInicial--;
        if (referenciaInicial <= 0)
        {
            //ocultar panel
            panelIzquierdo.SetActive(false);
        }
        DesactivarDialogo();
    }

    public void ClickDerecha()
    {
        panelIzquierdo.SetActive(true);
        referenciaInicial++;
        if (referenciaInicial >= referenciasDePantalla.Count - 1)
        {
            //ocultar panel
            panelDerecho.SetActive(false);
        }
        DesactivarDialogo();
    }

    public void ActivarDialogo()
    {
        panelDeDialogo.SetActive(true);
        botonSiguiente.SetActive(false);
        botonCerrar.SetActive(true);
    }


    public void DesactivarDialogo()
    {
        panelDeDialogo.SetActive(false);
    }

    public void StartBloodPower(Button boton)
    {
        botonDeBloodPower = boton;
        blooPower.gameObject.SetActive(true);
        comenzarContarTiempoDeBloodPower = true;
        boton.interactable = false;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 0.5; f += 0.05f)
        {
            Color c = blooPower.GetComponent<Image>().color;
            c.a = f;
            blooPower.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(.05f);
        }
        //Buscamos al vertice final y su imagen tambien la FadeIn
        GameObject verticeFinal = GetComponent<TeoriaDeGrafos>().verticeFinal.gameObject;
        //Debug.Log("Ahora el objeto clave");
        //buscamos su componente de imagen y la fadeamos
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            Color c = verticeFinal.GetComponent<Image>().color;
            c.a = f;
            verticeFinal.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(.1f);
        }
        StartCoroutine(PalpitarCliceable(verticeFinal.GetComponent<Image>()));
    }

    IEnumerator FadeOut()
    {
        corutinaParametrizable = false;
        //Buscamos al vertice final y su imagen tambien la FadeIn
        GameObject verticeFinal = GetComponent<TeoriaDeGrafos>().verticeFinal.gameObject;
        //Debug.Log("Ahora el objeto clave");
        //buscamos su componente de imagen y la fadeamos
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = verticeFinal.GetComponent<Image>().color;
            Color c2 = blooPower.GetComponent<Image>().color;
            c.a = f;
            c2.a = f / 2;
            verticeFinal.GetComponent<Image>().color = c;
            blooPower.GetComponent<Image>().color = c2;
            yield return new WaitForSeconds(.1f);
        }
        Color cx = verticeFinal.GetComponent<Image>().color;
        cx.a = 0;
        verticeFinal.GetComponent<Image>().color = cx;

        botonDeBloodPower.interactable = true;
        corutinaParametrizable = true;
        botonDeBloodPower.gameObject.GetComponent<Image>().fillAmount = 1;
    }

    IEnumerator FadeOut(Image imagen, float valorMinimo, float valorMaximo, float tiempo, float salto)
    {
        for (float f = valorMaximo; f >= valorMinimo; f -= salto)
        {
            Color c = imagen.color;
            c.a = f;
            imagen.color = c;
            yield return new WaitForSeconds(tiempo);
        }
    }

    IEnumerator PalpitarCliceable(Image imagen)
    {
        while (corutinaParametrizable)
        {
            for (float f = 1f; f >= 0; f -= 0.2f)
            {
                Color c = imagen.color;
                c.a = f;
                imagen.color = c;
                yield return new WaitForSeconds(.1f);
                if (!corutinaParametrizable)
                    break;
            }
            for (float f = 0f; f <= 1; f += 0.2f)
            {
                Color c = imagen.color;
                c.a = f;
                imagen.color = c;
                yield return new WaitForSeconds(.1f);
                if (!corutinaParametrizable)
                    break;
            }
        }
    }

    public void SalirAlMapaGeneral()
    {
        SceneManager.LoadScene("MapaGeneral");
    }
}
