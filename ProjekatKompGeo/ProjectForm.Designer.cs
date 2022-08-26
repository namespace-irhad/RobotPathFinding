namespace ProjekatKompGeo
{
    partial class ProjectForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.screenPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.destRadio = new System.Windows.Forms.RadioButton();
            this.velicinaNo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generisiNo = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.quadtreeButton = new System.Windows.Forms.Button();
            this.grafVidButton = new System.Windows.Forms.Button();
            this.trapezDekom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.putButton = new System.Windows.Forms.Button();
            this.dfsButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bfsButton = new System.Windows.Forms.RadioButton();
            this.generisiPoligone = new System.Windows.Forms.Button();
            this.dodajLabel = new System.Windows.Forms.Label();
            this.poligonRadio = new System.Windows.Forms.RadioButton();
            this.screenPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.velicinaNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generisiNo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // screenPanel
            // 
            this.screenPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.screenPanel.Controls.Add(this.panel1);
            this.screenPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.screenPanel.Location = new System.Drawing.Point(0, 0);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(848, 628);
            this.screenPanel.TabIndex = 0;
            this.screenPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            this.screenPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.screenPanel_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 0);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.destRadio);
            this.panel2.Controls.Add(this.velicinaNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.generisiNo);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.generisiPoligone);
            this.panel2.Controls.Add(this.dodajLabel);
            this.panel2.Controls.Add(this.poligonRadio);
            this.panel2.Location = new System.Drawing.Point(854, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 628);
            this.panel2.TabIndex = 1;
            // 
            // destRadio
            // 
            this.destRadio.AutoSize = true;
            this.destRadio.BackColor = System.Drawing.SystemColors.Control;
            this.destRadio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destRadio.Location = new System.Drawing.Point(3, 54);
            this.destRadio.Name = "destRadio";
            this.destRadio.Size = new System.Drawing.Size(71, 19);
            this.destRadio.TabIndex = 18;
            this.destRadio.TabStop = true;
            this.destRadio.Text = "Poc/Kraj";
            this.destRadio.UseVisualStyleBackColor = false;
            this.destRadio.CheckedChanged += new System.EventHandler(this.destRadio_CheckedChanged);
            // 
            // velicinaNo
            // 
            this.velicinaNo.AutoSize = true;
            this.velicinaNo.Location = new System.Drawing.Point(48, 542);
            this.velicinaNo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.velicinaNo.Name = "velicinaNo";
            this.velicinaNo.Size = new System.Drawing.Size(47, 20);
            this.velicinaNo.TabIndex = 17;
            this.velicinaNo.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Vel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Broj:";
            // 
            // generisiNo
            // 
            this.generisiNo.AutoSize = true;
            this.generisiNo.Location = new System.Drawing.Point(48, 516);
            this.generisiNo.Name = "generisiNo";
            this.generisiNo.Size = new System.Drawing.Size(47, 20);
            this.generisiNo.TabIndex = 14;
            this.generisiNo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.quadtreeButton);
            this.groupBox2.Controls.Add(this.grafVidButton);
            this.groupBox2.Controls.Add(this.trapezDekom);
            this.groupBox2.Location = new System.Drawing.Point(134, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 131);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "PF Algoritmi:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quadtreeButton
            // 
            this.quadtreeButton.Location = new System.Drawing.Point(7, 39);
            this.quadtreeButton.Name = "quadtreeButton";
            this.quadtreeButton.Size = new System.Drawing.Size(98, 23);
            this.quadtreeButton.TabIndex = 12;
            this.quadtreeButton.Text = "QuadTree";
            this.quadtreeButton.UseVisualStyleBackColor = true;
            this.quadtreeButton.Click += new System.EventHandler(this.quadtreeButton_Click);
            // 
            // grafVidButton
            // 
            this.grafVidButton.Location = new System.Drawing.Point(7, 68);
            this.grafVidButton.Name = "grafVidButton";
            this.grafVidButton.Size = new System.Drawing.Size(98, 23);
            this.grafVidButton.TabIndex = 11;
            this.grafVidButton.Text = "Graf Vidljivosti";
            this.grafVidButton.UseVisualStyleBackColor = true;
            this.grafVidButton.Click += new System.EventHandler(this.grafVidButton_Click);
            // 
            // trapezDekom
            // 
            this.trapezDekom.Location = new System.Drawing.Point(6, 97);
            this.trapezDekom.Name = "trapezDekom";
            this.trapezDekom.Size = new System.Drawing.Size(98, 23);
            this.trapezDekom.TabIndex = 3;
            this.trapezDekom.Text = "Trapez. Dekom.";
            this.trapezDekom.UseVisualStyleBackColor = true;
            this.trapezDekom.Click += new System.EventHandler(this.trapezDekom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.putButton);
            this.groupBox1.Controls.Add(this.dfsButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bfsButton);
            this.groupBox1.Location = new System.Drawing.Point(134, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 136);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // putButton
            // 
            this.putButton.Location = new System.Drawing.Point(17, 107);
            this.putButton.Name = "putButton";
            this.putButton.Size = new System.Drawing.Size(75, 23);
            this.putButton.TabIndex = 10;
            this.putButton.Text = "Nadji put";
            this.putButton.UseVisualStyleBackColor = true;
            this.putButton.Click += new System.EventHandler(this.nadjiPut_click);
            // 
            // dfsButton
            // 
            this.dfsButton.AutoSize = true;
            this.dfsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dfsButton.Location = new System.Drawing.Point(7, 63);
            this.dfsButton.Name = "dfsButton";
            this.dfsButton.Size = new System.Drawing.Size(46, 17);
            this.dfsButton.TabIndex = 9;
            this.dfsButton.Text = "DFS";
            this.dfsButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Algoritmi Pretrage:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bfsButton
            // 
            this.bfsButton.AutoSize = true;
            this.bfsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bfsButton.Checked = true;
            this.bfsButton.Location = new System.Drawing.Point(6, 40);
            this.bfsButton.Name = "bfsButton";
            this.bfsButton.Size = new System.Drawing.Size(45, 17);
            this.bfsButton.TabIndex = 8;
            this.bfsButton.TabStop = true;
            this.bfsButton.Text = "BFS";
            this.bfsButton.UseVisualStyleBackColor = false;
            // 
            // generisiPoligone
            // 
            this.generisiPoligone.Location = new System.Drawing.Point(7, 490);
            this.generisiPoligone.Name = "generisiPoligone";
            this.generisiPoligone.Size = new System.Drawing.Size(75, 20);
            this.generisiPoligone.TabIndex = 2;
            this.generisiPoligone.Text = "Generisi";
            this.generisiPoligone.UseVisualStyleBackColor = true;
            this.generisiPoligone.Click += new System.EventHandler(this.generisiPoligone_Click);
            // 
            // dodajLabel
            // 
            this.dodajLabel.AutoSize = true;
            this.dodajLabel.BackColor = System.Drawing.SystemColors.Control;
            this.dodajLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajLabel.Location = new System.Drawing.Point(4, 9);
            this.dodajLabel.Name = "dodajLabel";
            this.dodajLabel.Size = new System.Drawing.Size(51, 17);
            this.dodajLabel.TabIndex = 1;
            this.dodajLabel.Text = "Dodaj:";
            // 
            // poligonRadio
            // 
            this.poligonRadio.AutoSize = true;
            this.poligonRadio.BackColor = System.Drawing.SystemColors.Control;
            this.poligonRadio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poligonRadio.Location = new System.Drawing.Point(3, 29);
            this.poligonRadio.Name = "poligonRadio";
            this.poligonRadio.Size = new System.Drawing.Size(66, 19);
            this.poligonRadio.TabIndex = 0;
            this.poligonRadio.TabStop = true;
            this.poligonRadio.Text = "Poligon";
            this.poligonRadio.UseVisualStyleBackColor = false;
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.screenPanel);
            this.Name = "ProjectForm";
            this.Text = "Kretanje Robota";
            this.screenPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.velicinaNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generisiNo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel screenPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton poligonRadio;
        private System.Windows.Forms.Label dodajLabel;
        private System.Windows.Forms.Button generisiPoligone;
        private System.Windows.Forms.Button trapezDekom;
        private System.Windows.Forms.RadioButton dfsButton;
        private System.Windows.Forms.RadioButton bfsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button grafVidButton;
        private System.Windows.Forms.Button quadtreeButton;
        private System.Windows.Forms.NumericUpDown generisiNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown velicinaNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button putButton;
        private System.Windows.Forms.RadioButton destRadio;
    }
}

