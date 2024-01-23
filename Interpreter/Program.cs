using System;
using System.Collections.Generic;

// Interfaz de expresión
interface Expresion
{
    int Interpretar(Dictionary<string, int> contexto);
}

// Expresión terminal para números
class ExpresionNumero : Expresion
{
    private int numero;

    public ExpresionNumero(int numero)
    {
        this.numero = numero;
    }

    public int Interpretar(Dictionary<string, int> contexto)
    {
        return numero;
    }
}

// Expresión no terminal para sumar
class ExpresionSuma : Expresion
{
    private Expresion expresion1, expresion2;

    public ExpresionSuma(Expresion expresion1, Expresion expresion2)
    {
        this.expresion1 = expresion1;
        this.expresion2 = expresion2;
    }

    public int Interpretar(Dictionary<string, int> contexto)
    {
        return expresion1.Interpretar(contexto) + expresion2.Interpretar(contexto);
    }
}

// Cliente
class Program
{
    static void Main()
    {
        // Contexto con valores
        Dictionary<string, int> contexto = new Dictionary<string, int>();
        contexto.Add("a", 2);
        contexto.Add("b", 3);

        // Crear expresiones
        Expresion expresion = new ExpresionSuma(new ExpresionNumero(2), new ExpresionNumero(3));

        // Interpretar expresión
        int resultado = expresion.Interpretar(contexto);

        // Mostrar resultado
        Console.WriteLine("Resultado: " + resultado); // Salida esperada: 5
    }
}
