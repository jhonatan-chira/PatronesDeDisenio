// Abstracción: Forma
abstract class Forma
{
    protected IDispositivo dispositivo;

    public Forma(IDispositivo dispositivo)
    {
        this.dispositivo = dispositivo;
    }

    public abstract void Dibujar();
}

// Implementación: Dispositivo
interface IDispositivo
{
    void DibujarCirculo();
    void DibujarCuadrado();
    // ... otros métodos para dibujar diferentes formas
}

// Implementaciones Concretas: Dispositivo
class Pantalla : IDispositivo
{
    public void DibujarCirculo()
    {
        Console.WriteLine("Dibujando círculo en la pantalla.");
    }

    public void DibujarCuadrado()
    {
        Console.WriteLine("Dibujando cuadrado en la pantalla.");
    }
    // ... otros métodos para dibujar en pantalla
}

class Impresora : IDispositivo
{
    public void DibujarCirculo()
    {
        Console.WriteLine("Imprimiendo círculo.");
    }

    public void DibujarCuadrado()
    {
        Console.WriteLine("Imprimiendo cuadrado.");
    }
    // ... otros métodos para imprimir
}

// Formas Concretas
class Circulo : Forma
{
    public Circulo(IDispositivo dispositivo) : base(dispositivo) { }

    public override void Dibujar()
    {
        dispositivo.DibujarCirculo();
    }
}

class Cuadrado : Forma
{
    public Cuadrado(IDispositivo dispositivo) : base(dispositivo) { }

    public override void Dibujar()
    {
        dispositivo.DibujarCuadrado();
    }
}

// Uso del patrón Bridge
class Programa
{
    static void Main()
    {
        IDispositivo pantalla = new Pantalla();
        IDispositivo impresora = new Impresora();

        Forma circulo = new Circulo(pantalla);
        circulo.Dibujar();

        Console.WriteLine();

        Forma cuadrado = new Cuadrado(impresora);
        cuadrado.Dibujar();
    }
}
