// La interfaz Command declara un método para ejecutar un comando.
public interface ICommand
{
    void Ejecutar();
}

// Algunos comandos pueden implementar operaciones simples por sí mismos.
class ComandoSimple : ICommand
{
    private string _cargaUtil = string.Empty;

    public ComandoSimple(string cargaUtil)
    {
        this._cargaUtil = cargaUtil;
    }

    public void Ejecutar()
    {
        Console.WriteLine($"ComandoSimple: Mira, puedo hacer cosas simples como imprimir ({this._cargaUtil})");
    }
}

// Sin embargo, algunos comandos pueden delegar operaciones más complejas a otros
// objetos, llamados "receptores".
class ComandoComplejo : ICommand
{
    private Receptor _receptor;

    // Datos de contexto, necesarios para lanzar los métodos del receptor.
    private string _a;

    private string _b;

    // Los comandos complejos pueden aceptar uno o varios objetos receptores junto con
    // cualquier dato de contexto a través del constructor.
    public ComandoComplejo(Receptor receptor, string a, string b)
    {
        this._receptor = receptor;
        this._a = a;
        this._b = b;
    }

    // Los comandos pueden delegar a cualquier método de un receptor.
    public void Ejecutar()
    {
        Console.WriteLine("ComandoComplejo: Las cosas complejas deberían ser realizadas por un objeto receptor.");
        this._receptor.HacerAlgo(this._a);
        this._receptor.HacerAlgoMas(this._b);
    }
}

// Las clases Receptor contienen lógica empresarial importante. Saben cómo
// realizar todo tipo de operaciones asociadas con la realización de una
// solicitud. De hecho, cualquier clase puede servir como receptor.
class Receptor
{
    public void HacerAlgo(string a)
    {
        Console.WriteLine($"Receptor: Haciendo algo con {a}");
    }

    public void HacerAlgoMas(string b)
    {
        Console.WriteLine($"Receptor: Haciendo algo más con {b}");
    }
}

// El cliente puede configurar objetos de comando simples y complejos.
class Cliente
{
    public void Configurar()
    {
        var receptor = new Receptor();
        var comandoSimple = new ComandoSimple("Hola mundo!");
        var comandoComplejo = new ComandoComplejo(receptor, "hacer", "algo");

        // El cliente debe configurar los objetos receptores para trabajar con los comandos.
        comandoSimple.Ejecutar();
        comandoComplejo.Ejecutar();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cliente = new Cliente();
        cliente.Configurar();
    }
}
