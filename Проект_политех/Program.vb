'Калькулятор систем счисления
Module Program
    Sub Main()

        Dim num As String
        Dim osn As Integer
        Dim osn2 As Integer

        Console.Write("Base of the original number system: ")
        osn = Console.ReadLine()

        Console.Write("Base of the result number system: ")
        osn2 = Console.ReadLine()

        Console.Write("Number: ")
        num = Console.ReadLine()

        Console.WriteLine("Result: " & Conversion(num, osn, osn2))

        Console.ReadKey()
    End Sub

    Function Conversion(num As String, osn As Integer, osn2 As Integer) As String
        Dim abc As String = "0123456789ABCDEFGHIJKLMNOPQRSTWVXYZ"
        Dim decimal_number = NumberToDecimal(num, osn, abc)

        Return NumberFromDecimal(decimal_number, osn2, abc)
    End Function
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

    Function NumberFromDecimal(decimal_number As Integer, osn2 As Integer, abc As String) As String
        Dim num2 As String = ""

        Do
            num2 += abc(decimal_number Mod osn2)
            decimal_number \= osn2
        Loop Until osn2 > decimal_number
        num2 += abc(decimal_number)

        Return StrReverse(num2)
    End Function
End Module

