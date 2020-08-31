using System.Collections.Generic;

public class Dialogo20 : Dialogo
{
    private void Awake()
    {
        dialogo = new List<string>();
        dialogo.Add(DIALOGO1);
        dialogo.Add(DIALOGO2);
        dialogo.Add(DIALOGO3);
        dialogo.Add(DIALOGO4);
        dialogo.Add(DIALOGO5);
        dialogo.Add(DIALOGO6);
        dialogo.Add(DIALOGO7);
        dialogo.Add(DIALOGO8);
        /*GameObject.Instantiate(masculino);
        GameObject.Instantiate(femenino);*/
    }

    public override void Opcion1(ref PersonajeBuilder factoriaDeDialogos)
    {
        factoriaDeDialogos.ConGenero(referencia.masculino);
    }

    public override void Opcion2(ref PersonajeBuilder factoriaDeDialogos)
    {
        factoriaDeDialogos.ConGenero(referencia.femenino);
    }

    //Constantes de los dialogos
    public const string DIALOGO1 = "Barman: Buenas noches mi querido cliente, en qué le puedo colaborar.";
    public const string DIALOGO2 = "Buenas noches mi nombre es Arturo, vengo desde muy lejos buscando a Alba me dijo que estuvo aquí estas últimas noches.|Buenas noches soy Alba, Solo paso por aquí buscando a alguien. Se llama Arturo, la ultima vez que hable con el me dijo que estaba aquí, eso fue hace unas noches.";
    public const string DIALOGO3 = "Barman: Quien es es usted para la persona que busca, es uno de mis mejores clientes, y uno muy apreciado por mi.";
    public const string DIALOGO4 = "Barman: También estoy preocupado por el, pero mi situación me impide hacer algo.";
    public const string DIALOGO5 = "Barman: Tengo poco mas de 3 días que no pasa por aquí, no tengo mas información.";
    public const string DIALOGO6 = "Player: Me gustaría que me ayudará con información de la ultima noche en la que estuvo aquí.";
    public const string DIALOGO7 = "Barman: Claro, estuvo aquí la noche de hace 3 días, pero por políticas del lugar no puedo decir mas sobre ello, si es que me entiende.";
    public const string DIALOGO8 = "Barman: Lamento no ser de mucha ayuda en mis condiciones.";

}
