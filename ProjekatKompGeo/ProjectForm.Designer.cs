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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.velicinaNo = new System.Windows.Forms.NumericUpDown();
            this.generisiNo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.generisiPoligone = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dodatnoBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.graneBox = new System.Windows.Forms.CheckBox();
            this.vrhoviBox = new System.Windows.Forms.CheckBox();
            this.destRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.quadtreeButton = new System.Windows.Forms.Button();
            this.grafVidButton = new System.Windows.Forms.Button();
            this.trapezDekom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.astarRadio = new System.Windows.Forms.RadioButton();
            this.djikstraRadio = new System.Windows.Forms.RadioButton();
            this.putButton = new System.Windows.Forms.Button();
            this.dfsButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bfsButton = new System.Windows.Forms.RadioButton();
            this.dodajLabel = new System.Windows.Forms.Label();
            this.poligonRadio = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.reset = new System.Windows.Forms.Button();
            this.screenPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.velicinaNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generisiNo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // screenPanel
            // 
            this.screenPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.screenPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.destRadio);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.dodajLabel);
            this.panel2.Controls.Add(this.poligonRadio);
            this.panel2.Location = new System.Drawing.Point(854, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 628);
            this.panel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Controls.Add(this.reset);
            this.groupBox4.Controls.Add(this.velicinaNo);
            this.groupBox4.Controls.Add(this.generisiNo);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.generisiPoligone);
            this.groupBox4.Location = new System.Drawing.Point(7, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 131);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            // 
            // velicinaNo
            // 
            this.velicinaNo.AutoSize = true;
            this.velicinaNo.Location = new System.Drawing.Point(61, 64);
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
            // generisiNo
            // 
            this.generisiNo.AutoSize = true;
            this.generisiNo.Location = new System.Drawing.Point(61, 38);
            this.generisiNo.Name = "generisiNo";
            this.generisiNo.Size = new System.Drawing.Size(47, 20);
            this.generisiNo.TabIndex = 14;
            this.generisiNo.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Broj:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Vel:";
            // 
            // generisiPoligone
            // 
            this.generisiPoligone.Location = new System.Drawing.Point(6, 12);
            this.generisiPoligone.Name = "generisiPoligone";
            this.generisiPoligone.Size = new System.Drawing.Size(102, 20);
            this.generisiPoligone.TabIndex = 2;
            this.generisiPoligone.Text = "Generisi";
            this.generisiPoligone.UseVisualStyleBackColor = true;
            this.generisiPoligone.Click += new System.EventHandler(this.generisiPoligone_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(134, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "Koraci";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "",
            "1. Generisanje",
            "2. PF Algoritam",
            "3. Start/Destinacija",
            "4. Pretraga"});
            this.listBox1.Location = new System.Drawing.Point(134, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(111, 95);
            this.listBox1.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.dodatnoBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.graneBox);
            this.groupBox3.Controls.Add(this.vrhoviBox);
            this.groupBox3.Location = new System.Drawing.Point(134, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 117);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // dodatnoBox
            // 
            this.dodatnoBox.AutoSize = true;
            this.dodatnoBox.Location = new System.Drawing.Point(8, 77);
            this.dodatnoBox.Name = "dodatnoBox";
            this.dodatnoBox.Size = new System.Drawing.Size(67, 17);
            this.dodatnoBox.TabIndex = 14;
            this.dodatnoBox.Text = "Dodatno";
            this.dodatnoBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Crtanje";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graneBox
            // 
            this.graneBox.AutoSize = true;
            this.graneBox.Location = new System.Drawing.Point(7, 54);
            this.graneBox.Name = "graneBox";
            this.graneBox.Size = new System.Drawing.Size(55, 17);
            this.graneBox.TabIndex = 13;
            this.graneBox.Text = "Grane";
            this.graneBox.UseVisualStyleBackColor = true;
            // 
            // vrhoviBox
            // 
            this.vrhoviBox.AutoSize = true;
            this.vrhoviBox.Checked = true;
            this.vrhoviBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vrhoviBox.Location = new System.Drawing.Point(7, 31);
            this.vrhoviBox.Name = "vrhoviBox";
            this.vrhoviBox.Size = new System.Drawing.Size(56, 17);
            this.vrhoviBox.TabIndex = 12;
            this.vrhoviBox.Text = "Vrhovi";
            this.vrhoviBox.UseVisualStyleBackColor = true;
            // 
            // destRadio
            // 
            this.destRadio.AutoSize = true;
            this.destRadio.BackColor = System.Drawing.SystemColors.Control;
            this.destRadio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destRadio.Location = new System.Drawing.Point(9, 74);
            this.destRadio.Name = "destRadio";
            this.destRadio.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.destRadio.Size = new System.Drawing.Size(72, 19);
            this.destRadio.TabIndex = 18;
            this.destRadio.TabStop = true;
            this.destRadio.Text = "Poc/Kraj";
            this.destRadio.UseVisualStyleBackColor = false;
            this.destRadio.CheckedChanged += new System.EventHandler(this.destRadio_CheckedChanged);
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
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "PF Algoritmi";
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
            this.groupBox1.Controls.Add(this.astarRadio);
            this.groupBox1.Controls.Add(this.djikstraRadio);
            this.groupBox1.Controls.Add(this.putButton);
            this.groupBox1.Controls.Add(this.dfsButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bfsButton);
            this.groupBox1.Location = new System.Drawing.Point(134, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 163);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // astarRadio
            // 
            this.astarRadio.AutoSize = true;
            this.astarRadio.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.astarRadio.ForeColor = System.Drawing.Color.DimGray;
            this.astarRadio.Location = new System.Drawing.Point(7, 107);
            this.astarRadio.Name = "astarRadio";
            this.astarRadio.Size = new System.Drawing.Size(51, 17);
            this.astarRadio.TabIndex = 12;
            this.astarRadio.Text = "AStar";
            this.astarRadio.UseVisualStyleBackColor = false;
            // 
            // djikstraRadio
            // 
            this.djikstraRadio.AutoSize = true;
            this.djikstraRadio.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.djikstraRadio.ForeColor = System.Drawing.Color.LimeGreen;
            this.djikstraRadio.Location = new System.Drawing.Point(7, 84);
            this.djikstraRadio.Name = "djikstraRadio";
            this.djikstraRadio.Size = new System.Drawing.Size(60, 17);
            this.djikstraRadio.TabIndex = 11;
            this.djikstraRadio.Text = "Djikstra";
            this.djikstraRadio.UseVisualStyleBackColor = false;
            // 
            // putButton
            // 
            this.putButton.Location = new System.Drawing.Point(19, 134);
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
            this.dfsButton.ForeColor = System.Drawing.Color.Chocolate;
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
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Algoritmi Pretrage";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bfsButton
            // 
            this.bfsButton.AutoSize = true;
            this.bfsButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bfsButton.Checked = true;
            this.bfsButton.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.bfsButton.Location = new System.Drawing.Point(6, 40);
            this.bfsButton.Name = "bfsButton";
            this.bfsButton.Size = new System.Drawing.Size(45, 17);
            this.bfsButton.TabIndex = 8;
            this.bfsButton.TabStop = true;
            this.bfsButton.Text = "BFS";
            this.bfsButton.UseVisualStyleBackColor = false;
            this.bfsButton.CheckedChanged += new System.EventHandler(this.bfsButton_CheckedChanged);
            // 
            // dodajLabel
            // 
            this.dodajLabel.AutoSize = true;
            this.dodajLabel.BackColor = System.Drawing.SystemColors.Control;
            this.dodajLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajLabel.Location = new System.Drawing.Point(10, 24);
            this.dodajLabel.Name = "dodajLabel";
            this.dodajLabel.Padding = new System.Windows.Forms.Padding(0, 2, 20, 2);
            this.dodajLabel.Size = new System.Drawing.Size(71, 21);
            this.dodajLabel.TabIndex = 1;
            this.dodajLabel.Text = "Dodaj:";
            // 
            // poligonRadio
            // 
            this.poligonRadio.AutoSize = true;
            this.poligonRadio.BackColor = System.Drawing.SystemColors.Control;
            this.poligonRadio.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poligonRadio.Location = new System.Drawing.Point(9, 51);
            this.poligonRadio.Name = "poligonRadio";
            this.poligonRadio.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.poligonRadio.Size = new System.Drawing.Size(72, 19);
            this.poligonRadio.TabIndex = 0;
            this.poligonRadio.TabStop = true;
            this.poligonRadio.Text = "Poligon";
            this.poligonRadio.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(6, 102);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(102, 23);
            this.reset.TabIndex = 22;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.velicinaNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generisiNo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox graneBox;
        private System.Windows.Forms.CheckBox vrhoviBox;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton djikstraRadio;
        private System.Windows.Forms.RadioButton astarRadio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox dodatnoBox;
        private System.Windows.Forms.Button reset;
    }
}

