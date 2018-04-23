Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Printing
Imports System.ComponentModel
Imports System.Collections.ObjectModel


Namespace E2641_CS
    Partial Public Class MainPage
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ShowPrintPreview(grid)
        End Sub

        Private Sub ShowPrintPreview(ByVal grid As GridControl)
            Dim preview As New DocumentPreviewWindow()
            Dim link As New PrintableControlLink(TryCast(grid.View, DevExpress.Xpf.Printing.IPrintableControl))
            link.ExportServiceUri = "../ExportService1.svc"
            Dim model As New LinkPreviewModel(link)
            preview.Model = model
            link.CreateDocument(False)
            preview.ShowDialog()
        End Sub
    End Class
End Namespace
