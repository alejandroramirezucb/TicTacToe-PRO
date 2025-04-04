public class jugador
{
    private string nombreDeUsuario;
    public jugador(string nombreDeUsuario)
    {
        this.nombreDeUsuario = nombreDeUsuario;
    }
    public string getNombreDeUsuario()
    {
        return nombreDeUsuario;
    }
    public void setNombreDeUsuario(string nombreDeUsuario)
    {
        this.nombreDeUsuario = nombreDeUsuario;
    }
}