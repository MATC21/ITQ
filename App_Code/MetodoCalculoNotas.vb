Imports Microsoft.VisualBasic

Public Class MetodoCalculoNotas
    '------------------------------------------------
    ' Atributos para el cálulo de cuatro notas
    '------------------------------------------------
    Public Nota1, Nota2, Nota3 As Double
    Public PesoNota1, PesoNota2, PesoNota3 As Double
    Public NotaProyecto, NotaRecuperacion As Double
    Public PesoProyecto As Double
    Public AporteNota1, AporteNota2, AporteNota3, AporteNotas123 As Double
    Public AporteProyecto, AporteRecuperacion As Double
    Public Aportes123Minimo, AporteProyectoMinimo As Double
    Public NotaFinalMinimo As Double
    Public Asistencia, AsistenciaMinima As Double
    Public TipoCalculoNotas As String
    ' Resultado de los cálculos
    Public NotaFinal, Resultado, Explicacion As String

    Public Sub MetodoCalculoNotas()
        ' Inicializa
        AporteNotas123 = 0.0
        AporteProyecto = 0.0
        AporteRecuperacion = 0.0
        NotaFinal = 0.0
    End Sub

    Public Sub Calc4Notas()
        '------------------------------------------------
        ' Cálculo de cuatro notas
        '------------------------------------------------
        ' Inicializa
        AporteNotas123 = 0.0
        AporteProyecto = 0.0
        AporteRecuperacion = 0.0
        NotaFinal = 0.0
        ' Calculos de los aportes
        AporteNota1 = Nota1 * PesoNota1
        AporteNota2 = Nota2 * PesoNota2
        AporteNota3 = Nota3 * PesoNota3
        AporteNotas123 = AporteNota1 + AporteNota2 + AporteNota3
        AporteProyecto = NotaProyecto * PesoProyecto
        AporteRecuperacion = NotaRecuperacion * PesoProyecto
        ' Lógica de las 4 notas
        If AporteNotas123 < Aportes123Minimo Then  ' Si las tres notas NO superan el mínimo
            NotaFinal = Math.Round(AporteNotas123, 2)
            Resultado = "Reprueba"
            Explicacion = "Las notas sumativas 1, 2 y 3 (" & AporteNotas123 & ") no superan el mínimo de: " & Aportes123Minimo
        Else ' Si las tres notas SI superan el mínimo
            NotaFinal = Math.Round(AporteNotas123 + AporteProyecto, 2)
            'Verifica la asistencia
            If Asistencia < AsistenciaMinima Then
                Resultado = "Reprueba"
                Explicacion = "La asistencia (" & Asistencia & ") no supera el mínimo de " & AsistenciaMinima
            Else ' Si tiene la asistencia mínima
                If AporteProyecto < AporteProyectoMinimo Then ' Si el aporte del proyecto NO supera el mínimo
                    Resultado = "Reprueba"
                    Explicacion = "El aporte del proyecto (" & AporteProyecto & ") no supera el mínimo de: " & AporteProyectoMinimo
                Else ' El aporte del proyecto SI supera el mínimo
                    If NotaFinal < NotaFinalMinimo Then ' Necesita de recuperación
                        NotaFinal = Math.Round(AporteNotas123 + AporteRecuperacion, 2)
                        If NotaFinal < NotaFinalMinimo Then
                            NotaFinal = Math.Round(AporteNotas123 + AporteProyecto, 2)
                            Resultado = "Reprueba"
                            Explicacion = "La nota final incluyendo el aporte de recuperación (" & NotaFinal & ") no supera el mínimo de: " & NotaFinalMinimo
                        Else
                            Resultado = "Aprueba"
                            Explicacion = "Aprueba con proyecto y con recuperación"
                        End If
                    Else
                        Resultado = "Aprueba"
                        Explicacion = "Aprueba con proyecto"
                    End If
                End If
            End If
        End If
    End Sub

End Class
