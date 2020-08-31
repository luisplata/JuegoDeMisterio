using System.Collections.Generic;

public class Dialogo21 : Dialogo
{
    private void Awake()
    {
        dialogo = new List<string>();
        dialogo.Add(DIALOGO9);
        dialogo.Add(DIALOGO10);
        dialogo.Add(DIALOGO11);
        dialogo.Add(DIALOGO12);
        dialogo.Add(DIALOGO13);
    }
    public override void Opcion1(ref PersonajeBuilder factoriaDeDialogos)
    {
        factoriaDeDialogos.ConPiel(referencia.negra);
        factoriaDeDialogos.ConRopa(referencia.azul);
    }

    public override void Opcion2(ref PersonajeBuilder factoriaDeDialogos)
    {
        factoriaDeDialogos.ConPiel(referencia.blanca);
        factoriaDeDialogos.ConRopa(referencia.roja);
    }

    public const string DIALOGO9 = "Pensamiento: El barman me mira con una mirada codiciosa y no se si es posible adivinar lo que le guste al barman: dinero, mujeres, u otra cosa.";
    public const string DIALOGO10 = "Disculpe mi buen barman, quisiera pedir una cerveza fría por favor, y te quedas con el cambio. (le entregas un billete de $100 y la bebida cuesta $10)|Disculpe mi buen barman, quisiera pedir un Martini por favor, y te quedas con el cambio. (le entregas un billete de $100 y la bebida cuesta $40)";
    public const string DIALOGO11 = "Player: En la cara del cantinero aparece una sonrisa avariciosa, menos mal atine a lo que quería.";
    public const string DIALOGO12 = "Barman: Gracias por entender las políticas del lugar, lo invito a sentarse.";
    public const string DIALOGO13 = "(debes tocar en la silla de la barra)";
}
