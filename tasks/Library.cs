namespace MyLibrary{
    static public class Library{
    static public double[,] FillDoubleArray(int min, int max){
        Console.WriteLine("Введите количество строк в массиве.");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов в массиве.");
        int columns = Convert.ToInt32(Console.ReadLine());

        double[,] array = new double[rows, columns];

        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                array[i, j] = Math.Round(new Random().NextDouble() * (max + 1 - min) + min, 2);
            }
        }
        return array;
    }

    static public int[,] FillIntArray(int min, int max){
        Console.WriteLine("Введите количество строк в массиве.");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов в массиве.");
        int columns = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[rows, columns];

        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                array[i, j] = new Random().Next(min, max);
            }
        }
        return array;
    }

    static public void PrintArray(Array array){
        for (int i = 0; i < array.GetLength(0); i++){
            for (int j = 0; j < array.GetLength(1); j++){
                Console.Write(array.GetValue(i,j) + " ");
            }
            Console.WriteLine();
        }
        }
    } 

}
