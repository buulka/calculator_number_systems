'Калькулятор систем счисления
Module Program
    Sub Main()
        'для начала попробую написать перевод из любой в десятичную целого числа 
        '(потом будет и для дробного)

        Dim dv As String
        Dim sum As Integer
        Dim osn As Integer

        Console.Write("Введите основание системы счисления, из которой нужно перевести число: ")
        osn = Console.ReadLine()

        Console.Write("Number: ")
        dv = Console.ReadLine()

        Dim array(Len(dv) - 1) As Integer

        For i = 0 To Len(dv) - 1
            array(Len(dv) - 1 - i) = Val(dv(i))
        Next

        For i = 0 To UBound(array)
            sum += Val(array(i)) * (osn ^ i)
        Next

        Console.WriteLine("В десятичной: " & sum)


        Console.ReadKey()
    End Sub
End Module

