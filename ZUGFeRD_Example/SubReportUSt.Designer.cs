namespace ZUGFeRD_Example
{
   partial class SubReportUSt
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo objectConstructorInfo1 = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo();
         this.Detail = new DevExpress.XtraReports.UI.DetailBand();
         this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
         this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
         this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
         this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
         this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // Detail
         // 
         this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
         this.Detail.Dpi = 100F;
         this.Detail.HeightF = 20.91669F;
         this.Detail.Name = "Detail";
         this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MwSt", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
         this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // xrPanel1
         // 
         this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
         this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel1});
         this.xrPanel1.Dpi = 100F;
         this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.xrPanel1.Name = "xrPanel1";
         this.xrPanel1.SizeF = new System.Drawing.SizeF(726.9999F, 20.91669F);
         this.xrPanel1.StylePriority.UseBorders = false;
         // 
         // xrLabel2
         // 
         this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
         this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Gesamtpreis", "{0:n2}")});
         this.xrLabel2.Dpi = 100F;
         this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(499.4583F, 0F);
         this.xrLabel2.Name = "xrLabel2";
         this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
         this.xrLabel2.StylePriority.UseBorders = false;
         this.xrLabel2.StylePriority.UseTextAlignment = false;
         this.xrLabel2.Text = "xrLabel2";
         this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
         // 
         // xrLabel3
         // 
         this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
         this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MwStBetrag", "{0:n2}")});
         this.xrLabel3.Dpi = 100F;
         this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(599.4583F, 0F);
         this.xrLabel3.Name = "xrLabel3";
         this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel3.SizeF = new System.Drawing.SizeF(75F, 23F);
         this.xrLabel3.StylePriority.UseBorders = false;
         this.xrLabel3.StylePriority.UseTextAlignment = false;
         this.xrLabel3.Text = "xrLabel3";
         this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
         // 
         // xrLabel1
         // 
         this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
         this.xrLabel1.Dpi = 100F;
         this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9F, 0F);
         this.xrLabel1.Name = "xrLabel1";
         this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel1.SizeF = new System.Drawing.SizeF(229.7918F, 23F);
         this.xrLabel1.StylePriority.UseBorders = false;
         this.xrLabel1.Text = "Steuerbasisbetrag USt. [MwSt]%";
         // 
         // TopMargin
         // 
         this.TopMargin.Dpi = 100F;
         this.TopMargin.HeightF = 0F;
         this.TopMargin.Name = "TopMargin";
         this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // BottomMargin
         // 
         this.BottomMargin.Dpi = 100F;
         this.BottomMargin.HeightF = 0F;
         this.BottomMargin.Name = "BottomMargin";
         this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // objectDataSource1
         // 
         this.objectDataSource1.Constructor = objectConstructorInfo1;
         this.objectDataSource1.DataMember = "posten";
         this.objectDataSource1.DataSource = typeof(ZUGFeRD_Example.Klassen.Ausgangsrechnung);
         this.objectDataSource1.Name = "objectDataSource1";
         // 
         // SubReportUSt
         // 
         this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
         this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
         this.DataSource = this.objectDataSource1;
         this.FilterString = "[Art] = \'MWST\'";
         this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margins = new System.Drawing.Printing.Margins(50, 50, 0, 0);
         this.PageHeight = 1169;
         this.PageWidth = 827;
         this.PaperKind = System.Drawing.Printing.PaperKind.A4;
         this.Version = "16.2";
         ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }

      #endregion

      private DevExpress.XtraReports.UI.DetailBand Detail;
      private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
      private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
      private DevExpress.XtraReports.UI.XRLabel xrLabel2;
      private DevExpress.XtraReports.UI.XRLabel xrLabel1;
      private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
      private DevExpress.XtraReports.UI.XRLabel xrLabel3;
      private DevExpress.XtraReports.UI.XRPanel xrPanel1;
   }
}
