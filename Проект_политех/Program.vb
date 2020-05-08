Module Program
    Sub pause(ByVal z As Double)
        'Задержка на заданное время
        Dim t As Single
        t = Timer()
        Do Until Timer() - t > z
        Loop
    End Sub

    Sub screensaver()
        'Вывод заставки случайным порядком цветов
        Dim name() As String = {"  ######################################################################################## ",
                                "                                                                                           ",
                                "  #######   ##   ##   ##    ##  #######     ##     #######  ########    ######    ######   ",
                                "  ##        ##   ##   ##   ###  ##         #  #    ##   ##     ##       #    #    ##   ##  ",
                                "  ##        ##   ##   ##  ####  ##        ##  ##   ##   ##     ##      ##    ##   ##    #  ",
                                "  ##        ##   ##   ##  # ##  ##        #    #   ##   ##     ##      ##    ##   ##   ##  ",
                                "  ##        #######   ## ## ##  ##       ##    ##  #######     ##      #      #   ######   ",
                                "  ##             ##   ## #  ##  ##       ##    ##     ####     ##      ##    ##   ##       ",
                                "  ##             ##   ####  ##  ##       ##    ##    ## ##     ##      ##    ##   ##       ",
                                "  ##             ##   ###   ##  ##       ##    ##   ##  ##     ##       #    #    ##       ",
                                "  #######        ##   ##    ##  #######  ##    ##  ##   ##     ##       ######    ##       ",
                                "                                                                                           ",
                                "  ######################################################################################## "}
        Dim colours() = {ConsoleColor.Green, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen, ConsoleColor.Yellow}
        Console.BackgroundColor = ConsoleColor.Gray
        Console.Clear()
        Randomize()
        For i = 1 To 7
            Console.WriteLine()
        Next
        For i = 0 To UBound(name)
            For j = 0 To Len(name(i)) - 1
                If name(i)(j) = "#" Then
                    Console.BackgroundColor = colours(Int(3) * Rnd())
                Else
                    Console.BackgroundColor = ConsoleColor.Gray
                End If
                Console.Write(" ")
                pause(0.002)
            Next
            pause(0.001)
            Console.WriteLine()
        Next
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.DarkGray
        Console.BackgroundColor = ConsoleColor.Gray
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Press any key to continue")
        Console.ReadKey()
    End Sub

    Sub Main()
        Console.SetWindowSize(95, 30)
        Console.SetBufferSize(95, 30)
        Console.BackgroundColor = ConsoleColor.Gray
        Console.ForegroundColor = ConsoleColor.Black
        screensaver()
        Console.Clear()
        Body()
    End Sub
    Sub Body()
        Dim InputNumber As String
        Dim InputBase As Single
        Dim OutputBase As Single

        Do
            Try
                Console.Write("Base of the original number system: ")
                Console.ForegroundColor = ConsoleColor.DarkGreen
                InputBase = Console.ReadLine()
                Console.ForegroundColor = ConsoleColor.Black
                Replace(InputBase, " ", "")
            Catch InvalidCastException As Exception
            End Try

            If SystemValidation(InputBase) = False Then
                Console.WriteLine()
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.WriteLine("Input base should be an integer number")
                Console.WriteLine("Choose number system from 2 to 36. Input base should be an integer number!")
                Console.ForegroundColor = ConsoleColor.Black

                Console.WriteLine()
            End If

        Loop Until SystemValidation(InputBase) = True

        Do
            Try
                Console.Write("Base of the result number system: ")
                Console.ForegroundColor = ConsoleColor.DarkGreen
                OutputBase = Console.ReadLine()
                Console.ForegroundColor = ConsoleColor.Black
                Replace(OutputBase, " ", "")
            Catch InvalidCastException As Exception
            End Try


            If SystemValidation(OutputBase) = False Then
                Console.WriteLine()
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.WriteLine("Input base should be an integer number")
                Console.WriteLine("Choose number system from 2 to 36. Input base should be an integer number!")
                Console.ForegroundColor = ConsoleColor.Black
            End If
            Console.WriteLine()
        Loop Until SystemValidation(OutputBase) = True

        Do
            Console.Write("Number: ")
            Console.ForegroundColor = ConsoleColor.DarkGreen
            InputNumber = Console.ReadLine()
            Console.ForegroundColor = ConsoleColor.Black
            InputNumber = Replace(InputNumber, " ", "")
            InputNumber = Replace(InputNumber, ".", ",")
            InputNumber = UCase(InputNumber)
            Console.WriteLine()
            If NumberValidation(InputNumber, InputBase) = False Then
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Input number is in the wrong format!")
                Console.ForegroundColor = ConsoleColor.Black
                Console.WriteLine()
            End If
        Loop Until NumberValidation(InputNumber, InputBase) = True

        Convert.ToInt32(InputBase)
        Convert.ToInt32(OutputBase)

        Console.Clear()

        Console.Write("Base of the original number system: ")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(InputBase)
        Console.ForegroundColor = ConsoleColor.Black

        Console.Write("Base of the result number system: ")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(OutputBase)
        Console.ForegroundColor = ConsoleColor.Black

        Console.Write("Number: ")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(InputNumber)
        Console.ForegroundColor = ConsoleColor.Black

        Console.WriteLine()


        Console.Write("Result: ")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(Conversion(InputNumber, InputBase, OutputBase))
        Console.ForegroundColor = ConsoleColor.Black

        Console.WriteLine()
        Console.WriteLine("Select option:")
        Console.WriteLine("1 - new conversion")
        Console.WriteLine("2 - EXIT")

        Dim IsTrueAnswer As Boolean

        Do
            Console.Write("Your choice: ")
            Console.ForegroundColor = ConsoleColor.DarkGreen
            Dim UsersAnswer As String = Console.ReadLine()
            Console.ForegroundColor = ConsoleColor.Black
            If UsersAnswer = "1" Then
                IsTrueAnswer = True
                Console.Clear()
                Body()
            ElseIf UsersAnswer = "2" Then
                IsTrueAnswer = True
                Exit Sub

            Else
                IsTrueAnswer = False
                Console.ForegroundColor = ConsoleColor.DarkRed
                Console.WriteLine("There is no such answer option")
                Console.ForegroundColor = ConsoleColor.Black
                Console.WriteLine()
            End If
        Loop Until IsTrueAnswer = True
    End Sub

    Function SystemValidation(Base As Single) As Boolean

        If Base < 2 Or Base > 36 Or (Base - Fix(Base) > 0) Then
            Return False
        End If
        Return True
    End Function
    Function NumberValidation(InputNumber As String, InputBase As Integer) As Boolean

        Dim CharDict As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        If InputNumber = "" Then
            Return False
        End If
        InputNumber = Replace(InputNumber, ",", "")
        For i = 0 To Len(InputNumber) - 1
            If CharDict.IndexOf(InputNumber(i)) >= InputBase Or CharDict.IndexOf(InputNumber(i)) < 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function Conversion(InputNumber As String, InputBase As Integer, OutputBase As Integer) As String

        Dim IsNegativ As Boolean

        If InputNumber(0) = "-" Then
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
            Console.ForegroundColor = ConsoleColor.DarkRed
            Return "Input number is too big"
            Console.ForegroundColor = ConsoleColor.Black
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

