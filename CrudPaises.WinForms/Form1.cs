using CrudPaises.Data;
using CrudPaises.Models;
using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CrudPaises.WinForms
{
    public partial class Form1 : Form
    {
        private readonly PaisRepository _repo = new PaisRepository();
        private int _codigoSelecionado = 0;

        public Form1()
        {
            InitializeComponent();

            // define forms e eventos sem precisar do designer
            btnAdd.Click += btAdd_Click;
            btnAtt.Click += btnAtt_Click;
            btnExc.Click += btnExc_Click;
            btnRefr.Click += btnRefr_Click;
            dataGridViewPaises.CellClick += dataGridViewPaises_CellClick;

            btnAtt.Enabled = false;
            btnExc.Enabled = false;

            CarregarGrid();

            CarregarGrid();
        }
        private void CarregarGrid()
        {
            dataGridViewPaises.DataSource = null;
            dataGridViewPaises.DataSource = _repo.Listar();

            dataGridViewPaises.ClearSelection();
            _codigoSelecionado = 0;

            btnAtt.Enabled = false;
            btnExc.Enabled = false;
        }
        private void dataGridViewPaises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var pais = (Pais)dataGridViewPaises.Rows[e.RowIndex].DataBoundItem;
            _codigoSelecionado = pais.Codigo_pais;

            txtNome.Text = pais.Nome_pais;
            txtPopulacao.Text = pais.Populacao.ToString();
            txtArea.Text = pais.Area_total.ToString(CultureInfo.InvariantCulture);

            btnAtt.Enabled = true;
            btnExc.Enabled = true;
        }
        private bool ValidarCampos(out Pais pais)
        {
            pais = new Pais();

            var nome = txtNome.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Nome vazio.");
                return false;
            }

            if (!long.TryParse(txtPopulacao.Text.Trim(), out var popula))
            {
                MessageBox.Show("População inválida.");
                return false;
            }

            var areaTxt = txtArea.Text.Trim().Replace(',', '.');
            if (!double.TryParse(areaTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out var area))
            {
                MessageBox.Show("Área inválida.");
                return false;
            }

            if (popula <= 0)
            {
                MessageBox.Show("População deve ser maior que zero.");
                return false;
            }

            if (area <= 0)
            {
                MessageBox.Show("Área total deve ser maior que zero.");
                return false;
            }

            pais.Nome_pais = nome;
            pais.Populacao = popula;
            pais.Area_total = area;

            return true;

        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPopulacao.Clear();
            txtArea.Clear();
            _codigoSelecionado = 0;

            btnAtt.Enabled = false;
            btnExc.Enabled = false;
            dataGridViewPaises.ClearSelection();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out var pais)) return;

            _repo.Inserir(pais);
            LimparCampos();
            CarregarGrid();
        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            if (_codigoSelecionado == 0)
            {
                MessageBox.Show("Selecione um país na lista.");
                return;
            }

            if (!ValidarCampos(out var pais)) return;

            pais.Codigo_pais = _codigoSelecionado;
            _repo.Atualizar(pais);

            LimparCampos();
            CarregarGrid();
        }
        private void btnExc_Click(object sender, EventArgs e)
        {
            if (_codigoSelecionado == 0)
            {
                MessageBox.Show("Selecione um país na lista.");
                return;
            }

            var resp = MessageBox.Show(
                "Confirmar exclusão?",
                "Excluir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resp != DialogResult.Yes)
            {
                // remove o foco do botão
                this.ActiveControl = null;
                return;
            }

            _repo.Excluir(_codigoSelecionado);
            LimparCampos();
            CarregarGrid();

            this.ActiveControl = null;
        }
        private void btnRefr_Click(object sender, EventArgs e)
        {
            LimparCampos();
            CarregarGrid();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // sem ação
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // sem ação
        }
    }
}
