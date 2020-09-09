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
    public const string DIALOGO1 = "Entrás al bar y ves al barman, un joven atractivo que no se esfuerza en interpretar la tematica del lugar.";
    public const string DIALOGO2 = "Hay algunas mesas ocupadas por borrachos casi desmayados, una musica de laúd y una iluminación con focos que imitan velas ayudan a tu ánimo.";
    public const string DIALOGO3 = "Soy arturo|Soy Alba";
    public const string DIALOGO4 = "Barman: Quien es usted para la persona que busca, es uno de mis mejores clientes, y uno muy apreciado por mi.";
    public const string DIALOGO5 = "Barman: Tambien estoy preocupado por el, pero mi situación me impide hacer algo. Tengo poco más de tres días que no pasa por aquí, no tengo más información.";
    public const string DIALOGO6 = "Player: Me gustaría que me ayudara con información de la ultima noche en la que estuvo aquí.";
    public const string DIALOGO7 = "Barman: Claro, estuvo aquí la noche de hace tres días, pero por políticas del lugar no puedo decir más sobre ello, si es que me entiende. ";
    public const string DIALOGO8 = "Barman: Lamento no ser de mucha ayuda en mis condiciones.";

}
