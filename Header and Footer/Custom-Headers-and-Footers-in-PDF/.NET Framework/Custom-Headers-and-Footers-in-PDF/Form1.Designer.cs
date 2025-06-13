using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;

namespace Custom_Headers_and_Footers_in_PDF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            btnCreate = new Button();
            label = new Label();

            //Label
            label.Location = new System.Drawing.Point(0, 40);
            label.Size = new System.Drawing.Size(426, 35);
            label.Text = "Click the button to generate PDF document";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //Button
            btnCreate.Location = new System.Drawing.Point(180, 110);
            btnCreate.Size = new System.Drawing.Size(85, 26);
            btnCreate.Text = "Create PDF";
            btnCreate.Click += new EventHandler(btnCreate_Click);

            //Create PDF
            ClientSize = new System.Drawing.Size(450, 150);
            Controls.Add(label);
            Controls.Add(btnCreate);
            Text = "Create PDF";
        }
        private Button btnCreate;
        private Label label;

        #endregion
    }
}
