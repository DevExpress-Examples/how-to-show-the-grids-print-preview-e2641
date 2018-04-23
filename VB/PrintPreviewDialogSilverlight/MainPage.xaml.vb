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
			grid.DataSource = New ProductList()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ShowPrintPreviewInNewTab(grid)
		End Sub

		Private Sub ShowPrintPreviewInNewTab(ByVal grid As GridControl)
			Dim preview As New DocumentPreview()
			Dim link As New VisualDataNodeLink(TryCast(grid.View, IRootDataNodeSource))
			link.ExportServiceUri = "../ExportService1.svc"
			link.PrintingSystem.ExportOptions.Html.EmbedImagesInHTML = True
			Dim model As New LinkPreviewModel(link)
			preview.Model = model

			Dim tabItem As New DXTabItem() With {.AllowHide = DefaultBoolean.True, .Content = preview, .Header = "DXGrid Print Preview"}
			tabControl.Items.Add(tabItem)
			tabControl.SelectedItem = tabItem

			link.CreateDocument(True)
		End Sub

		Private Sub tabControl_TabHidden(ByVal sender As Object, ByVal e As TabControlTabHiddenEventArgs)
			tabControl.Items.RemoveAt(e.TabIndex)
		End Sub
	End Class
End Namespace
