using MyLibrary;
Console.WriteLine(@"Введите номер задачи:
1 - задача47;
2 - задача50;
3 - задача53;
4 - дополнительная задача1;
5 - дополнительная задача2");
string answer = Console.ReadLine();
switch(answer){
    case "1": Task47(); break;
    case "2": Task50(); break;
    case "3": Task52(); break;
    case "4": starTask(); break;
    case "5": doubleStarTask(); break;
    default: Console.WriteLine("Вы ввели неверное значение."); break;
} 

void Task47(){
    double[,] doubleArray = Library.FillDoubleArray(1, 10);
    Library.PrintArray(doubleArray);
}

void Task50(){
    double[,] doubleArray = Library.FillDoubleArray(1, 10);
    Library.PrintArray(doubleArray);
    Console.WriteLine("Введите номер строки для поиска числа.");
    int dim1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите номер столбца для поиска числа.");
    int dim2 = Convert.ToInt32(Console.ReadLine());
    (double, bool) ans = FindElement(doubleArray, dim1, dim2);
    if(ans.Item2) Console.WriteLine($"На позиции [{dim1},{dim2}] в массиве находится число равное {ans.Item1}");
    else Console.WriteLine($"На позиции [{dim1},{dim2}] в массиве числа нет");

    (double, bool) FindElement(double[,] array, int dimension1, int dimension2){
        (double, bool) answer = (0, false);
        if (dimension1 < array.GetLength(0) && dimension2 < array.GetLength(1)){
            answer.Item1 = array[dimension1, dimension2];
            answer.Item2 = true;
        } 
        return answer;
    }
        
}

void Task52(){
    double[,] doubleArray = Library.FillDoubleArray(1, 10);
    Library.PrintArray(doubleArray);
    Console.Write("Среднее арифметическое элементов в каждом столбце:");
    for (int i = 0; i < doubleArray.GetLength(1); i++){
        double avg = 0;
        for (int j = 0; j < doubleArray.GetLength(0); j++){
            avg += doubleArray[j,i]; 
        }
        Console.Write(Math.Round(avg/doubleArray.GetLength(0), 2) + " ");
    }
}

void starTask(){
    int[,] intArray = Library.FillIntArray(1, 10);
    Library.PrintArray(intArray);
    if (intArray.GetLength(0) == 1 || intArray.GetLength(1) == 1){
        Console.WriteLine("Ваш массив не прямоугольный, введите другие параметры размера массива.");
        return;
    }
    int sumOfFourCorner = intArray[0,0] + intArray[intArray.GetLength(0) - 1, 0] + 
    intArray[0, intArray.GetLength(1) - 1] + intArray[intArray.GetLength(0) - 1, intArray.GetLength(1) - 1];
    Console.WriteLine($"Сумма элементов расположенных в четырех углах двумерного массива равна {sumOfFourCorner}");
    for (int i = 0; i < intArray.GetLength(1); i++){
        int sum = 0;
        for (int j = 0; j < intArray.GetLength(0); j++){
            sum += intArray[j,i]; 
        }
        if (sum > sumOfFourCorner){
            Console.WriteLine($"Сумма элементов в {i + 1} столбце равна {sum}");
            Console.WriteLine("Да");
            return;
        }
    }
    Console.WriteLine("Нет");
}

void doubleStarTask(){
    Console.WriteLine("Введите количество строк");
    int rows = Convert.ToInt32(Console.ReadLine());
    int[,] triangle = new int[rows, (rows - 1) * 2 + 1];
    int center = triangle.GetLength(1) / 2;
    triangle[0, center] = 1;
    triangle[triangle.GetLength(0) - 1, 0] = 1;
    triangle[triangle.GetLength(0) - 1, triangle.GetLength(1) - 1] = 1;
    int j, k;
    for (int i = 1; i < triangle.GetLength(0); i++)
    {
        if (i % 2 != 0)
        {
            j = center + 1;
            k = center - 1;
        }
        else
        {
            triangle[i, center] = triangle[i - 1, center - 1] + triangle[i - 1, center + 1];
            j = center + 2;
            k = center - 2;
        }
        for (;
            j < triangle.GetLength(1) - 1; j += 2, k -= 2)
        {
            triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j + 1];
            triangle[i, k] = triangle[i - 1, k - 1] + triangle[i - 1, k + 1];
        }
    }
    PrintTriangle(triangle);

    void PrintTriangle(int[,] array){
        for(int i = 0; i < array.GetLength(0); i++){
            for (int j = 0; j < array.GetLength(1); j++){
                if (array[i, j] == 0) Console.Write("  ");
                else Console.Write(" " + array[i, j]);
            }
            Console.WriteLine();
        }
    }
}
