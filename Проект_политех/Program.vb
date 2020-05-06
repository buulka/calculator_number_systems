'Калькулятор систем счисления
Module Program
    Sub Main()

        Dim num As String
        Dim sum As Integer
        Dim osn As Integer
        Dim abc As String = "0123456789ABCDEFGHIJKLMNOPQRSTWVXYZ"
        Dim osn2 As Integer
        Console.Write("Enter the base of the number system from which you want to translate the number: ")
        osn = Console.ReadLine()

        Console.Write("Number: ")
        num = Console.ReadLine()

        Console.Write("В какую:")
        osn2 = Console.ReadLine()

        Console.WriteLine("В десятичной: " & NumberToDecimal(num, osn, abc))


        Console.ReadKey()
    End Sub
    Function NumberToDecimal(num As String, osn As Integer, abc As String) As Integer
        Dim sum As Integer = 0
        Dim array(Len(num) - 1) As Integer

        For i = 0 To Len(num) - 1
            array(Len(num) - 1 - i) = abc.IndexOf(num(i))
        Next

        For i = 0 To UBound(array)
            sum += Val(array(i)) * (osn ^ i)
        Next

        Return sum
    End Function

End Module

