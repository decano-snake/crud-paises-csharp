namespace CrudPaises.WinForms
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
            dataGridViewPaises = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            txtPopulacao = new TextBox();
            txtArea = new TextBox();
            btnAdd = new Button();
            btnAtt = new Button();
            btnExc = new Button();
            btnRefr = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaises).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPaises
            // 
            dataGridViewPaises.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPaises.Location = new Point(0, 165);
            dataGridViewPaises.MultiSelect = false;
            dataGridViewPaises.Name = "dataGridViewPaises";
            dataGridViewPaises.ReadOnly = true;
            dataGridViewPaises.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPaises.Size = new Size(512, 212);
            dataGridViewPaises.TabIndex = 0;
            dataGridViewPaises.CellContentClick += dataGridViewPaises_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 15);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 40);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "População";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 67);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 3;
            label3.Text = "Área Total";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(204, 12);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 4;
            // 
            // txtPopulacao
            // 
            txtPopulacao.Location = new Point(204, 37);
            txtPopulacao.Name = "txtPopulacao";
            txtPopulacao.Size = new Size(100, 23);
            txtPopulacao.TabIndex = 5;
            // 
            // txtArea
            // 
            txtArea.Location = new Point(204, 64);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(100, 23);
            txtArea.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(97, 117);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnAtt
            // 
            btnAtt.Location = new Point(178, 117);
            btnAtt.Name = "btnAtt";
            btnAtt.Size = new Size(75, 23);
            btnAtt.TabIndex = 8;
            btnAtt.Text = "Editar";
            btnAtt.UseVisualStyleBackColor = true;
            btnAtt.Click += btnAtt_Click;
            // 
            // btnExc
            // 
            btnExc.Location = new Point(259, 117);
            btnExc.Name = "btnExc";
            btnExc.Size = new Size(75, 23);
            btnExc.TabIndex = 9;
            btnExc.Text = "Excluir";
            btnExc.UseVisualStyleBackColor = true;
            btnExc.Click += btnExc_Click;
            // 
            // btnRefr
            // 
            btnRefr.Location = new Point(340, 117);
            btnRefr.Name = "btnRefr";
            btnRefr.Size = new Size(75, 23);
            btnRefr.TabIndex = 10;
            btnRefr.Text = "Recarregar";
            btnRefr.UseVisualStyleBackColor = true;
            btnRefr.Click += btnRefr_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 377);
            Controls.Add(btnRefr);
            Controls.Add(btnExc);
            Controls.Add(btnAtt);
            Controls.Add(btnAdd);
            Controls.Add(txtArea);
            Controls.Add(txtPopulacao);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewPaises);
            Name = "Form1";
            Text = "Cadastro de Países";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPaises).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewPaises;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNome;
        private TextBox txtPopulacao;
        private TextBox txtArea;
        private Button btnAdd;
        private Button btnAtt;
        private Button btnExc;
        private Button btnRefr;
    }
}
