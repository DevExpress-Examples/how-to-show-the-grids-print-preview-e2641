using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Printing.DataNodes;
using DevExpress.Xpf.Grid;
using DevExpress.Utils;

namespace PrintPreviewDialogSilverlight {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.ItemsSource = new ProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ShowPrintPreview(grid);
        }

        private void ShowPrintPreview(GridControl grid) {
            DocumentPreviewWindow preview = new DocumentPreviewWindow();
            PrintableControlLink link = new PrintableControlLink(grid.View as IPrintableControl);
            link.ExportServiceUri = "../ExportService1.svc";
            link.PrintingSystem.ExportOptions.Html.EmbedImagesInHTML = true;
            LinkPreviewModel model = new LinkPreviewModel(link);
            preview.Model = model;
            link.CreateDocument(true);
            preview.ShowDialog();
        }
    }
}
