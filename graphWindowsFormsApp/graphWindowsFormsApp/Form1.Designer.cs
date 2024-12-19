using System.Windows.Forms;

namespace graphWindowsFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnCountTops;
        private Button btnAddTop;
        private Button btnAddArc;
        private Button btnRemove;
        private TextBox txtTopNumber;
        private TextBox txtArcNumber;
        private TextBox txtArcStart;
        private TextBox txtArcEnd;
        private TextBox txtRemoveNumber;
        private ListBox listBox;
        private System.Windows.Forms.Panel drawingPanel;
        private Button btnFindAdjacentArcs;
        private TextBox TextBoxVertexNumber;
        private Label lblVertexNumber;

        private void InitializeComponent()
        {
            this.btnCountTops = new System.Windows.Forms.Button();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.btnAddTop = new System.Windows.Forms.Button();
            this.btnAddArc = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtTopNumber = new System.Windows.Forms.TextBox();
            this.txtArcNumber = new System.Windows.Forms.TextBox();
            this.txtArcStart = new System.Windows.Forms.TextBox();
            this.txtArcEnd = new System.Windows.Forms.TextBox();
            this.txtRemoveNumber = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnFindAdjacentArcs = new System.Windows.Forms.Button();
            this.TextBoxVertexNumber = new System.Windows.Forms.TextBox();
            this.lblVertexNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCountTops
            // 
            this.btnCountTops.Location = new System.Drawing.Point(149, 404);
            this.btnCountTops.Name = "btnCountTops";
            this.btnCountTops.Size = new System.Drawing.Size(120, 30);
            this.btnCountTops.TabIndex = 9;
            this.btnCountTops.Text = "Count Tops";
            this.btnCountTops.UseVisualStyleBackColor = true;
            this.btnCountTops.Click += new System.EventHandler(this.btnCountTops_Click);
            // 
            // drawingPanel
            // 
            this.drawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawingPanel.Location = new System.Drawing.Point(560, 62);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(393, 303);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            // 
            // btnAddTop
            // 
            this.btnAddTop.Location = new System.Drawing.Point(12, 78);
            this.btnAddTop.Name = "btnAddTop";
            this.btnAddTop.Size = new System.Drawing.Size(120, 30);
            this.btnAddTop.TabIndex = 0;
            this.btnAddTop.Text = "Add Top";
            this.btnAddTop.UseVisualStyleBackColor = true;
            this.btnAddTop.Click += new System.EventHandler(this.btnAddTop_Click);
            // 
            // btnAddArc
            // 
            this.btnAddArc.Location = new System.Drawing.Point(12, 142);
            this.btnAddArc.Name = "btnAddArc";
            this.btnAddArc.Size = new System.Drawing.Size(120, 30);
            this.btnAddArc.TabIndex = 1;
            this.btnAddArc.Text = "Add Arc";
            this.btnAddArc.UseVisualStyleBackColor = true;
            this.btnAddArc.Click += new System.EventHandler(this.btnAddArc_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 243);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove Element";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtTopNumber
            // 
            this.txtTopNumber.Location = new System.Drawing.Point(149, 86);
            this.txtTopNumber.Name = "txtTopNumber";
            this.txtTopNumber.Size = new System.Drawing.Size(120, 22);
            this.txtTopNumber.TabIndex = 3;
            // 
            // txtArcNumber
            // 
            this.txtArcNumber.Location = new System.Drawing.Point(149, 146);
            this.txtArcNumber.Name = "txtArcNumber";
            this.txtArcNumber.Size = new System.Drawing.Size(120, 22);
            this.txtArcNumber.TabIndex = 4;
            // 
            // txtArcStart
            // 
            this.txtArcStart.Location = new System.Drawing.Point(12, 197);
            this.txtArcStart.Name = "txtArcStart";
            this.txtArcStart.Size = new System.Drawing.Size(120, 22);
            this.txtArcStart.TabIndex = 5;
            // 
            // txtArcEnd
            // 
            this.txtArcEnd.Location = new System.Drawing.Point(149, 197);
            this.txtArcEnd.Name = "txtArcEnd";
            this.txtArcEnd.Size = new System.Drawing.Size(120, 22);
            this.txtArcEnd.TabIndex = 6;
            // 
            // txtRemoveNumber
            // 
            this.txtRemoveNumber.Location = new System.Drawing.Point(149, 251);
            this.txtRemoveNumber.Name = "txtRemoveNumber";
            this.txtRemoveNumber.Size = new System.Drawing.Size(120, 22);
            this.txtRemoveNumber.TabIndex = 7;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(287, 82);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(255, 244);
            this.listBox.TabIndex = 8;
            // 
            // btnFindAdjacentArcs
            // 
            this.btnFindAdjacentArcs.Location = new System.Drawing.Point(296, 341);
            this.btnFindAdjacentArcs.Name = "btnFindAdjacentArcs";
            this.btnFindAdjacentArcs.Size = new System.Drawing.Size(150, 25);
            this.btnFindAdjacentArcs.TabIndex = 12;
            this.btnFindAdjacentArcs.Text = "Find Adjacent Arcs";
            this.btnFindAdjacentArcs.UseVisualStyleBackColor = true;
            this.btnFindAdjacentArcs.Click += new System.EventHandler(this.ButtonFindAdjacentArcs_Click);
            // 
            // TextBoxVertexNumber
            // 
            this.TextBoxVertexNumber.Location = new System.Drawing.Point(149, 341);
            this.TextBoxVertexNumber.Name = "TextBoxVertexNumber";
            this.TextBoxVertexNumber.Size = new System.Drawing.Size(120, 22);
            this.TextBoxVertexNumber.TabIndex = 11;
            // 
            // lblVertexNumber
            // 
            this.lblVertexNumber.AutoSize = true;
            this.lblVertexNumber.Location = new System.Drawing.Point(12, 340);
            this.lblVertexNumber.Name = "lblVertexNumber";
            this.lblVertexNumber.Size = new System.Drawing.Size(111, 16);
            this.lblVertexNumber.TabIndex = 10;
            this.lblVertexNumber.Text = "Enter top number:";
            this.lblVertexNumber.Click += new System.EventHandler(this.lblVertexNumber_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1142, 482);
            this.Controls.Add(this.btnFindAdjacentArcs);
            this.Controls.Add(this.TextBoxVertexNumber);
            this.Controls.Add(this.lblVertexNumber);
            this.Controls.Add(this.btnCountTops);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.btnAddTop);
            this.Controls.Add(this.btnAddArc);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtTopNumber);
            this.Controls.Add(this.txtArcNumber);
            this.Controls.Add(this.txtArcStart);
            this.Controls.Add(this.txtArcEnd);
            this.Controls.Add(this.txtRemoveNumber);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Graph Visualization App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
