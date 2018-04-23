Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Printing
Imports DevExpress.Xpf.Printing.DataNodes
Imports DevExpress.Xpf.Grid
Imports DevExpress.Utils

Namespace PrintPreviewDialogSilverlight
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = New ProductList()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ShowPrintPreview(grid)
		End Sub

		Private Sub ShowPrintPreview(ByVal grid As GridControl)
			Dim preview As New DocumentPreviewWindow()
			Dim link As New PrintableControlLink(TryCast(grid.View, IPrintableControl))
			link.ExportServiceUri = "../ExportService1.svc"
			link.PrintingSystem.ExportOptions.Html.EmbedImagesInHTML = True
			Dim model As New LinkPreviewModel(link)
			preview.Model = model
			link.CreateDocument(True)
			preview.ShowDialog()
		End Sub
	End Class
End Namespace
