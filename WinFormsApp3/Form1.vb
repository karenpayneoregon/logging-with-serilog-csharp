Imports System.Runtime.CompilerServices

Public Class Form1
    Private Sub GetCheckBoxesInGroupBox1Button_Click(sender As Object, e As EventArgs) _ 
        Handles GetCheckBoxesInGroupBox1Button.Click

        ' get all CheckBoxes in GroupBox1
        Dim list As List(Of CheckBox) = GroupBox1.CheckBoxList

        For Each checkBox As CheckBox In list
            checkBox.Checked = Not checkBox.Checked
        Next

        ' get all CheckBoxes in GroupBox1 that are checked
        Dim checked As List(Of CheckBox) = GroupBox1.CheckBoxList().Where(Function(c) c.Checked).ToList()

    End Sub

End Class


' Belongs in a separate file
Public Module ControlExtensions
    <Extension> _
    Public Iterator Function Descendants(Of T As Class)(control As Control) As IEnumerable(Of T)

        For Each child As Control In control.Controls
            Dim tempVar As Boolean = TypeOf child Is T
            Dim thisControl As T = If(tempVar, TryCast(child, T), Nothing)
            If tempVar Then
                Yield thisControl
            End If

            If child.HasChildren Then
                For Each descendant As T In child.Descendants(Of T)()
                    Yield descendant
                Next descendant
            End If
        Next 
    End Function

    <Extension> _
    Public Function CheckBoxList(control As Control) As List(Of CheckBox)
        Return control.Descendants(Of CheckBox)().ToList()
    End Function

    <Extension> _
    Public Function ButtonList(ByVal control As Control) As List(Of Button)
        Return control.Descendants(Of Button)().ToList()
    End Function

End Module