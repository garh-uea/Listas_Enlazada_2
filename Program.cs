public class Primos_Armstrong
{
    public int Valor;
    public Primos_Armstrong? Siguiente;

    public Primos_Armstrong(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Primos_Armstrong? cabeza;
    private int contador;

    public ListaEnlazada()
    {
        cabeza = null;
        contador = 0;
    }

    // Agregar al final de la lista
    public void AgregarAlFinal(int valor)
    {
        Primos_Armstrong nuevo = new Primos_Armstrong(valor);

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Primos_Armstrong actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }

        contador++;
    }

    // Agregar al inicio de la lista
    public void AgregarAlInicio(int valor)
    {
        Primos_Armstrong nuevo = new Primos_Armstrong(valor);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;

        contador++;
    }

    // Mostrar todos los elementos
    public void Mostrar(string titulo)
    {
        Console.WriteLine($"\n{titulo}:");
        Primos_Armstrong? actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    public int Contar()
    {
        return contador;
    }
}

public class Validar_Numeros
{
    public static bool EsPrimo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    public static bool EsArmstrong(int n)
    {
        int suma = 0, original = n, digitos = n.ToString().Length;

        while (n > 0)
        {
            int dig = n % 10;
            suma += (int)Math.Pow(dig, digitos);
            n /= 10;
        }

        return suma == original;
    }
}

class Programa_Prinicipal
{
    static void Main()
    {
        ListaEnlazada listaPrimos = new ListaEnlazada();
        ListaEnlazada listaArmstrong = new ListaEnlazada();

        // Recorre del 1 al 200 para agregar datos
        for (int i = 1; i <= 200; i++)
        {
            if (Validar_Numeros.EsPrimo(i))
            {
                listaPrimos.AgregarAlFinal(i);
            }

            if (Validar_Numeros.EsArmstrong(i))
            {
                listaArmstrong.AgregarAlInicio(i);
            }
        }

        // a. Mostrar número de datos en cada lista
        int totalPrimos = listaPrimos.Contar();
        int totalArmstrong = listaArmstrong.Contar();

        Console.WriteLine($"Total de números primos insertados: {totalPrimos}");
        Console.WriteLine($"Total de números Armstrong insertados: {totalArmstrong}");

        // b. Indicar cuál lista tiene más elementos
        if (totalPrimos > totalArmstrong)
            Console.WriteLine("La lista de números primos tiene más elementos.");
        else if (totalPrimos < totalArmstrong)
            Console.WriteLine("La lista de números Armstrong tiene más elementos.");
        else
            Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");

        // c. Mostrar todos los datos de cada lista
        listaPrimos.Mostrar("Lista de números primos");
        listaArmstrong.Mostrar("Lista de números Armstrong");
    }
}
