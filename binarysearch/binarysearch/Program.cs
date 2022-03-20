
Console.WriteLine($"\n{nameof(BinarySearch)}");
Console.WriteLine($"Insert the length of your list (type \"exit\" to close the App):");
/*NB:
 * usare una lista è più comodo al run dinamico utente dei numeri, ma ha il difetto di essere
 * meno efficiente delle array. In quanto il saltare da un suo elemento ad un altro comporta la rilettura
 * dell'intera lista, perché solo l'elemento precedente di una lista sa dove si trova il successivo
 * nella memoria del pc.
 * D'altro canto le array hanno dimensioni fisse che renderebbero noiosa tale compilazione
*/

List<int> list = new List<int>();
//int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int.TryParse(Console.ReadLine(), out int length);
for (int i = 0; i < length; i++)
{
    list.Add(i + 1);
}
/*NB:
 * non serve ordinarla in quanto la lita viene generata in automatico dal ciclo "for",
 * sarà sicuramente ordinata
 */
Console.WriteLine($"Insert the number to guess:");
while (true)
{
    string userInput = Console.ReadLine();
    if (userInput.ToUpper().Contains("EXIT"))
    {
        break;
    }
    else if (int.TryParse(userInput, out int itemToGuess))
    {
        int result = BinarySearch(list, itemToGuess, out int counter);

        if (result == -1)
        {
            Console.WriteLine("Item NOT found, or not in the list");
        }
        else
        {
            Console.WriteLine($"Item found in the position: {result}" +
                              $"\nGuesses: {counter}");
        }
    }
    else
    {
        Console.WriteLine("Error on parsing your input");
    }

    Console.WriteLine("Retry...");
}

static int BinarySearch(List<int> list, int itemToGuess, out int counter)
{
    //prendo la dimensione della "list"
    //mi serviranno come indici per uscire dal ciclo
    int low = 0;
    int high = list.Count - 1;

    counter = 0;
    while (low <= high)
    {
        counter++;
        int mid = (low + high) / 2;
        int guess = list[mid];

        if (guess == itemToGuess)
        {
            return mid;
        }
        else if (guess > itemToGuess)
        {
            high = mid - 1;
        }
        else
        {
            low = mid + 1;
        }
    }

    return -1;
}