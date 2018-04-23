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
            grid.DataSource = new ProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ShowPrintPreviewInNewTab(grid);
        }

        private void ShowPrintPreviewInNewTab(GridControl grid) {
            DocumentPreview preview = new DocumentPreview();
            VisualDataNodeLink link = new VisualDataNodeLink(grid.View as IRootDataNodeSource);
            link.ExportServiceUri = "../ExportService1.svc";
            link.PrintingSystem.ExportOptions.Html.EmbedImagesInHTML = true;
            LinkPreviewModel model = new LinkPreviewModel(link);
            preview.Model = model;

            DXTabItem tabItem = new DXTabItem() {
                AllowHide = DefaultBoolean.True,
                Content = preview,
                Header = "DXGrid Print Preview"
            };
            tabControl.Items.Add(tabItem);
            tabControl.SelectedItem = tabItem;

            link.CreateDocument(true);
        }

        private void tabControl_TabHidden(object sender, TabControlTabHiddenEventArgs e) {
            tabControl.Items.RemoveAt(e.TabIndex);
        }
    }
}
