Module Module1

    Sub Main()
        '  Dada la siguiente lista de datos: 21   5   3   12   65   9   36   7   2

        'Realizar los procedimientos y funciones que consideres necesarios para:

        '- Crear e inicializar el array

        Dim listaNumeros() As Integer = {21, 5, 3, 12, 65, 9, 36, 7, 2}
        Dim listanumeros2() As Integer
        Dim opcion As Integer
        Dim resp As String
        Dim sw As Boolean
        Do
            Do
                Console.Write("MENU" & vbNewLine &
                      "" & vbNewLine &
                      "1. Mostrar Array1" & vbNewLine &
                      "2. Mostrar numero menor de Array1" & vbNewLine &
                      "3. Mostrar numero mayor de Array1" & vbNewLine &
                      "4. Buscar en Array1 y mostrar si esta o no" & vbNewLine &
                      "5. Buscar numero en Array1 y mostrar su posicion" & vbNewLine &
                      "6. Ordenar de menor a mayor Array1" & vbNewLine &
                      "   61. Mostrar Array1" & vbNewLine &
                      "7. Copiar valores de Array1 a Array2" & vbNewLine &
                      "8. Ordenar de mayor a menor Array2" & vbNewLine &
                      "   81. Mostrar Array2" & vbNewLine &
                      "9. Añadir Valor 8 al Array2" & vbNewLine &
                      "" & vbNewLine &
                      "Introduce la opcion deseada: ")
                opcion = Console.ReadLine()
                If opcion <= 0 Or opcion >= 10 And opcion <> 61 And opcion <> 81 Then
                    Console.Write(vbNewLine & "Error, introduce una opcion del 1 al 10" & vbNewLine & "")
                End If
            Loop While opcion < 0 Or opcion > 9 And opcion <> 61 And opcion <> 81



            Select Case opcion
                Case 1
                    mostrar(listaNumeros)
                Case 2
                    Console.Write(vbNewLine & "El numero menor es: " & minimo(listaNumeros) & vbNewLine)
                Case 3
                    Console.Write(vbNewLine & "El numero mayor es: " & maximo(listaNumeros) & vbNewLine)
                Case 4
                    mostrar(buscar(listaNumeros))

                'V2. En caso de encontrar el dato, mostrar un mensaje por pantalla indicando en qué posición del array está
                Case 5
                    mostrar(buscarV2(listaNumeros), listaNumeros)
                Case 6
                    ordenarMenorMayor(listaNumeros)
                Case 61
                    mostrar(listaNumeros)
                Case 7
                    listanumeros2 = (copiarValores(listaNumeros))
                Case 8
                    ordenarMayorMenor(listanumeros2)
                Case 81
                    mostrar(listanumeros2)
                Case 9
                    Console.WriteLine("" & vbNewLine & "Añadido valor 8 a la ultima posicion del array2" & vbNewLine)
                    mostrar(insertarValor8(listanumeros2))

            End Select

            Console.Write("¿Deseas continuar? (Si/no): ")
            resp = Console.ReadLine.ToLower
            If resp = "si" Then
                sw = True
                Console.Clear()
            ElseIf resp = "no" Then
                sw = False
                Console.Write("Fin del programa")
            End If
        Loop While sw = True
        Console.ReadLine()

    End Sub

    '- Mostrar por pantalla los valores del array
    Sub mostrar(ParamArray lista() As Integer)
        For Each e In lista
            Console.WriteLine(e)
        Next
    End Sub

    '- Calcular el valor mínimo del array
    Function minimo(ParamArray lista() As Integer) As Integer
        Return lista.Min
    End Function

    '- Calcular el valor máximo del array
    Function maximo(ParamArray lista() As Integer) As Integer
        Return lista.Max
    End Function

    '- Solicitar un dato por teclado y buscarlo en el array:
    Function buscar(ParamArray lista() As Integer) As Boolean

        Dim num, cont As Integer
        Dim sw As Boolean = False

        Console.Write(vbNewLine & "Introduce la cifra que quieres encontrar: ")
        num = Console.ReadLine()

        cont = 0

        While sw = False And cont < lista.Length
            If lista(cont) = num Then
                sw = True
            Else
                cont = cont + 1
            End If
        End While

        Return sw
    End Function

    Function buscarV2(ParamArray lista() As Integer) As Integer

        Dim num, cont As Integer
        Dim sw As Boolean = False

        Console.Write(vbNewLine & "Introduce la cifra que quieres encontrar: ")
        num = Console.ReadLine()

        While sw = False And cont < lista.Length
            If lista(cont) = num Then
                sw = True
            Else
                sw = False
                cont = cont + 1
            End If
        End While

        Return cont
    End Function

    'V1. Mostrar en pantalla un mensaje indicando si el dato leído se encuentra en el array o no
    Sub mostrar(resp As Boolean)
        If resp = True Then
            Console.Write(vbNewLine & "El numero esta en el array" & vbNewLine)
        Else
            Console.Write(vbNewLine & "El numero no esta en el array" & vbNewLine)
        End If
    End Sub


    'V2. En caso de encontrar el dato, mostrar un mensaje por pantalla indicando en qué posición del array está

    Sub mostrar(posicion As Integer, lista() As Integer)
        If posicion < lista.Length Then
            Console.Write(vbNewLine & "El numero esta en la posicion: " & posicion & vbNewLine)
        End If
        Console.Write(vbNewLine & "El numero no esta en el array" & vbNewLine)

    End Sub

    '- Ordenar los valores del array de menor a mayor.
    Sub ordenarMenorMayor(ParamArray lista() As Integer)
        Console.Write(vbNewLine & "Ordenado de menor a mayor" & vbNewLine & "" & vbNewLine)
        Array.Sort(lista)

    End Sub

    '- Copiar los valores del array a uno nuevo.
    Function copiarValores(ParamArray lista() As Integer) As Integer()
        Dim lista2(lista.Length - 1) As Integer

        For i = 0 To lista2.Length - 1
            lista2(i) = lista(i)
        Next

        Return lista2
    End Function

    '- Ordenar los valores del array del punto anterior de mayor a menor.
    Sub ordenarMayorMenor(ParamArray lista2() As Integer)
        Console.Write(vbNewLine & "Ordenado de mayor a menor" & vbNewLine & "" & vbNewLine)
        Array.Sort(lista2)
        Array.Reverse(lista2)
    End Sub

    '- En el último array copiado, insertar el valor 8 manteniendo el orden correspondiente.
    Function insertarValor8(ParamArray lista() As Integer) As Integer()
        ReDim Preserve lista(lista.Length)
        lista(lista.Length - 1) = 8

        Return lista
    End Function
End Module
