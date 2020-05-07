Module Program
    Sub Main()

        Dim InputNumber As String
        Dim InputBase As Integer
        Dim OutputBase As Integer

        Console.Write("Base of the original number system: ")
        InputBase = Console.ReadLine()

        Console.Write("Base of the result number system: ")
        OutputBase = Console.ReadLine()

        Console.Write("Number: ")
        InputNumber = Console.ReadLine()
        Console.WriteLine()

        Console.WriteLine("Result: " & Conversion(InputNumber, InputBase, OutputBase))

        Console.ReadKey()
    End Sub

    Function Conversion(InputNumber As String, InputBase As Integer, OutputBase As Integer) As String
        Dim CharDict As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim DecimalNumber = NumberToDecimal(InputNumber, InputBase, CharDict)

        Return NumberFromDecimal(DecimalNumber, OutputBase, CharDict)
    End Function
    Function NumberToDecimal(InputNumber As String, InputBase As Integer, CharDict As String) As Double
        Dim DecimalNumber As Double
        Dim DecimalIntPart As Integer
        Dim DecimalFractPart As Double


        If InputNumber.IndexOf(",") <> -1 Then
            Dim a() As String = Split(InputNumber, ",")
            DecimalIntPart = IntPartToDecimal(a(0), InputBase, CharDict)
            DecimalFractPart = FractParttoDecimal(a(1), InputBase, CharDict)
            DecimalNumber = DecimalIntPart + DecimalFractPart
        Else
            DecimalIntPart = IntPartToDecimal(InputNumber, InputBase, CharDict)
            DecimalNumber = DecimalIntPart
        End If

        Return DecimalNumber
    End Function
    Function IntPartToDecimal(InputNumber As String, InputBase As Integer, CharDict As String) As Integer
        Dim DecimalIntPart As Integer = 0
        Dim IntPartReverse(Len(InputNumber) - 1) As Integer

        For i = 0 To Len(InputNumber) - 1
            IntPartReverse(Len(InputNumber) - 1 - i) = CharDict.IndexOf(InputNumber(i))
        Next

        For i = 0 To UBound(IntPartReverse)
            DecimalIntPart += Val(IntPartReverse(i)) * (InputBase ^ i)
        Next

        Return DecimalIntPart
    End Function
    Function FractParttoDecimal(InputNumber As String, InputBase As Integer, CharDict As String) As Double
        Dim DecimalFractPart As Double
        For i = 1 To Len(InputNumber)
            DecimalFractPart += Convert.ToSingle(Str(CharDict.IndexOf(InputNumber(i - 1)))) * (InputBase ^ -i)
        Next

        Return DecimalFractPart
    End Function
    Function NumberFromDecimal(DecimalNumber As Double, OutputBase As Integer, CharDict As String) As String
        Dim OutputNumber As String
        Dim OtputIntPart As String
        Dim OutputFractPart As String

        If DecimalNumber - Fix(DecimalNumber) > 0 Then
            Dim temp As Single = DecimalNumber - Fix(DecimalNumber)
            OtputIntPart = IntPartFromDecimal(Fix(DecimalNumber), OutputBase, CharDict)
            OutputFractPart = FractPartFromDecimal(temp, OutputBase, CharDict)
            OutputNumber = OtputIntPart + "," + OutputFractPart
        Else
            OutputNumber = IntPartFromDecimal(Fix(DecimalNumber), OutputBase, CharDict)
        End If


        Return OutputNumber
    End Function
    Function IntPartFromDecimal(IntPartOfDecimal As Integer, OutputBase As Integer, CharDict As String) As String
        Dim OutputIntPart As String = ""

        Do
            OutputIntPart += CharDict(IntPartOfDecimal Mod OutputBase)
            IntPartOfDecimal \= OutputBase
        Loop Until OutputBase > IntPartOfDecimal
        OutputIntPart += CharDict(IntPartOfDecimal)

        Return StrReverse(OutputIntPart)
    End Function

    Function FractPartFromDecimal(FractPartOfDecimal As Double, OutputBase As Integer, CharDict As String) As String
        Dim OutputfractPart As String = ""
        Dim TempVar As Double = FractPartOfDecimal

        For i = 1 To 5
            TempVar *= OutputBase
            OutputfractPart += CharDict(Fix(TempVar))
            TempVar -= Fix(TempVar)
        Next

        Return OutputfractPart
    End Function
End Module

