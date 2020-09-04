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

    public const string DIALOGO9 = "Pensamiento: Lográs distinguir codicia en la mirada del barman, pero no sabes si su interés es el dinero, las mujeres, u otra cosa.";
    public const string DIALOGO10 = "Le compras una bebida de $10 y le ofreces el cambio de $90|Le compras una bebida de $40 y le ofreces el cambio de $60";
    public const string DIALOGO11 = "Pensamiento: En la cara del cantinero aparece una sonrisa avariciosa, sentís que atinaste a lo que quería.";
    public const string DIALOGO12 = "Barman: Gracias por entender las políticas del lugar, lo invito a sentarse.";
    public const string DIALOGO13 = "(debes tocar en la silla de la barra)";
}
