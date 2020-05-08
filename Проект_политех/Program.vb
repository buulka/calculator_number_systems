Module Program
    Sub Main()

        Dim InputNumber As String
        Dim InputBase As Integer
        Dim OutputBase As Integer

        Do
            Try
                Console.Write("Base of the original number system: ")
                InputBase = Console.ReadLine()
            Catch InvalidCastException As Exception
                Console.WriteLine("Input base should be an integer number")
            End Try

            If SystemValidation(InputBase) = False Then
                Console.WriteLine("Number system is incorrect! Choose Number system from 2 to 36")
                Console.WriteLine()
            End If

        Loop Until SystemValidation(InputBase) = True

        Do
            Try
                Console.Write("Base of the result number system: ")
                OutputBase = Console.ReadLine()
            Catch InvalidCastException As Exception
                Console.WriteLine("Input base should be an integer number")
            End Try


            If SystemValidation(OutputBase) = False Then
                Console.WriteLine("Number system is incorrect! Choose Number system from 2 to 36")
            End If
            Console.WriteLine()
        Loop Until SystemValidation(OutputBase) = True

        Do
            Console.Write("Number: ")
            InputNumber = Console.ReadLine()
            Console.WriteLine()

            If NumberValidation(InputNumber, InputBase) = False Then
                Console.WriteLine("Input number is in the wrong format!")
            End If
        Loop Until NumberValidation(InputNumber, InputBase) = True

        Console.WriteLine("Result: " & Conversion(InputNumber, InputBase, OutputBase))

        Console.ReadKey()
    End Sub
    Function SystemValidation(Base As Integer) As Boolean

        If Base < 2 Or Base > 36 Then
            Return False
        End If
        Return True
    End Function
    Function NumberValidation(InputNumber As String, InputBase As Integer) As Boolean

        Dim CharDict As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Replace(InputNumber, ",", "")
        For i = 0 To Len(InputNumber) - 1
            If CharDict.IndexOf(InputNumber(i)) >= InputBase Then
                Return False
            End If
        Next
        Return True
    End Function
    Function Conversion(InputNumber As String, InputBase As Integer, OutputBase As Integer) As String

        Dim IsNegativ As Boolean

        If InputNumber < 0 Then
            IsNegativ = True
            InputNumber = Replace(InputNumber, "-", "")
        End If

        Try
            Dim CharDict As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim DecimalNumber As Double = NumberToDecimal(InputNumber, InputBase, CharDict)
            If IsNegativ Then
                Return "-" + NumberFromDecimal(DecimalNumber, OutputBase, CharDict)
            End If
            Return NumberFromDecimal(DecimalNumber, OutputBase, CharDict)
        Catch OverflowException As Exception
            Return "Input number is too big"
        End Try
    End Function
    Function NumberToDecimal(InputNumber As String, InputBase As Integer, CharDict As String) As Double

        Dim DecimalNumber As Double
        Dim DecimalIntPart As Decimal
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
    Function IntPartToDecimal(InputNumber As String, InputBase As Integer, CharDict As String) As Decimal

        Dim DecimalIntPart As Decimal = 0
        Dim IntPartReverse(Len(InputNumber) - 1) As Decimal

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
            Dim TempVar As Double = DecimalNumber - Fix(DecimalNumber)
            OtputIntPart = IntPartFromDecimal(Fix(DecimalNumber), OutputBase, CharDict)
            OutputFractPart = FractPartFromDecimal(TempVar, OutputBase, CharDict)
            OutputNumber = OtputIntPart + "," + OutputFractPart
        Else
            OutputNumber = IntPartFromDecimal(Fix(DecimalNumber), OutputBase, CharDict)
        End If


        Return OutputNumber
    End Function
    Function IntPartFromDecimal(IntPartOfDecimal As Decimal, OutputBase As Integer, CharDict As String) As String

        Dim OutputIntPart As String = ""

        Do Until OutputBase > IntPartOfDecimal
            OutputIntPart += CharDict(IntPartOfDecimal Mod OutputBase)
            IntPartOfDecimal \= OutputBase

        Loop
        OutputIntPart += CharDict(IntPartOfDecimal)

        Return StrReverse(OutputIntPart)
    End Function

    Function FractPartFromDecimal(FractPartOfDecimal As Double, OutputBase As Integer, CharDict As String) As String

        Dim OutputfractPart As String = ""
        Dim TempVar As Double = FractPartOfDecimal

        For i = 1 To 5
            If TempVar < 0.00001 Then
                Exit For
            End If
            TempVar *= OutputBase
            OutputfractPart += CharDict(Fix(TempVar))
            TempVar -= Fix(TempVar)
        Next

        Return OutputfractPart
    End Function
End Module

