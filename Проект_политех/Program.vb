'����������� ������ ���������
Module Program
    Sub Main()
        '��� ������ �������� �������� ������� �� ����� � ���������� ������ ����� 
        '(����� ����� � ��� ��������)

        Dim dv As String
        Dim sum As Integer
        Dim osn As Integer

        Console.Write("������� ��������� ������� ���������, �� ������� ����� ��������� �����: ")
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

        Console.WriteLine("� ����������: " & sum)


        Console.ReadKey()
    End Sub
End Module

