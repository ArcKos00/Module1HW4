/*Создать массив на N элементов, где N указывается с консольной строки. Заполнить его случайными числами от 1 до 26 включительно.
 * Создать 2 массива, где в 1 массиве будут значение только четных значений, а во втором нечетных.
 * Заменить числа в 1 и 2 массиве  на буквы английского алфавита. Значения ячеек этих массивов равны порядковому номеру каждой буквы в алфавите.
 * Если же буква является одной из списка (a, e, i, d, h, j) то она должна быть в верхнем регистре.
 * Вывести на экран результат того, в каком из массивов будет больше букв в верхнем регистре.
 * Вывести оба массива на экран. Каждый из массивов должен быть выведен 1 строкой, где его значения будут разделены пробелом.
 */
using System.Text;

int[] arr = new int[int.Parse(Console.ReadLine())];
int[] arr1 = new int[0];
int[] arr2 = new int[0];

RandToArray(arr);
SortArray(arr, ref arr1, ref arr2);

var counter1 = 0;
var counter2 = 0;

string[] evenCharArray = new string[arr1.Length];
evenCharArray = UpperRegister(arr1, ref counter1);
string[] oddCharArray = new string[arr2.Length];
oddCharArray = UpperRegister(arr2, ref counter2);

if (counter1 > counter2)
{
    Console.WriteLine("Из массива нечётных чисел вышло больше букв в верхнем регистре");
    Writer();
}
else
{
    Console.WriteLine("Из массива чётных чисел вышло больше букв в верхнем регистре");
    Writer();
}

void Writer()
{
    Console.WriteLine("Массив чётных чисел: ");
    WriteArray(evenCharArray);
    Console.WriteLine("Массив нечётных чисел: ");
    WriteArray(oddCharArray);
    Console.ReadLine();
}

string[] UpperRegister(int[] array, ref int counter)
{
    string[] arr = new string[array.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        string symbol = Convert.ToChar(97 + array[i]).ToString();
        if (symbol == "a" ||
            symbol == "e" ||
            symbol == "i" ||
            symbol == "d" ||
            symbol == "h" ||
            symbol == "j")
        {
            arr[i] = symbol.ToUpperInvariant();
            counter++;
        }
        else
        {
            arr[i] = symbol;
        }
    }

    return arr;
}

void ArrayAdd(ref int[] array, int value)
{
    int[] arr = new int[array.Length + 1];
    for (int i = 0; i < arr.Length; i++)
    {
        if (i == arr.Length - 1)
        {
            arr[i] = value;
        }
        else
        {
            arr[i] = array[i];
        }
    }

    array = arr;
}

int[] RandToArray(int[] arr)
{
    Random rand = new Random();

    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rand.Next(1, 26);
    }

    return arr;
}

void SortArray(in int[] arr, ref int[] arr1, ref int[] arr2)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] % 2 == 0)
        {
            ArrayAdd(ref arr1, arr[i]);
        }
        else
        {
            ArrayAdd(ref arr2, arr[i]);
        }
    }
}

void WriteArray(string[] array)
{
    var sb = new StringBuilder();
    for (int i = 0; i < array.Length; i++)
    {
        sb.Append(array[i] + " ");
    }

    Console.WriteLine(sb.ToString());
}