using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimuladorSAT
{
    public partial class fmPagoIVA : Form
    {
        private decimal _montoACargo = 0;
        private decimal _totalCompensaciones = 0;
        private decimal _totalEstimulos = 0;

        public fmPagoIVA(decimal montoACargo = 0)
        {
            InitializeComponent();
            _montoACargo = montoACargo;

            cmbCompensaciones.SelectedIndexChanged += CmbCompensaciones_SelectedIndexChanged;
            cmbEstimulos.SelectedIndexChanged += CmbEstimulos_SelectedIndexChanged;

            btnCapturarComp.Click += BtnCapturarComp_Click;
            btnCapturarEst.Click += BtnCapturarEst_Click;

            CargarValoresIniciales();
        }

        private void CargarValoresIniciales()
        {
            txtACargo.Text = _montoACargo.ToString("N0");
            txtTotalContrib1.Text = _montoACargo.ToString("N0");
            txtTotalContrib2.Text = _montoACargo.ToString("N0");

            cmbCompensaciones.SelectedIndex = 0;
            cmbEstimulos.SelectedIndex = 0;

            RecalcularTotales();
            ReorganizarPosiciones();
        }

        private void RecalcularTotales()
        {
            decimal totalAplicaciones = _totalCompensaciones + _totalEstimulos;

            txtTotalAplicaciones1.Text = totalAplicaciones.ToString("N0");
            txtTotalAplicaciones2.Text = totalAplicaciones.ToString("N0");

            decimal cantidadACargo = _montoACargo - totalAplicaciones;
            if (cantidadACargo < 0) cantidadACargo = 0;

            txtCantidadACargo.Text = cantidadACargo.ToString("N0");
            txtCantidadAPagar.Text = cantidadACargo.ToString("N0");
        }

        private void CmbCompensaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool tieneComp = cmbCompensaciones.SelectedItem?.ToString() == "Si";

            lblCompensaciones.Visible = tieneComp;
            lblMasComp.Visible = tieneComp;
            txtCompensaciones.Visible = tieneComp;
            btnCapturarComp.Visible = tieneComp;

            if (!tieneComp)
            {
                _totalCompensaciones = 0;
                txtCompensaciones.Text = "";
                RecalcularTotales();
            }
            else if (_totalCompensaciones == 0)
            {
                txtCompensaciones.Text = "";
            }

            ReorganizarPosiciones();
        }

        private void CmbEstimulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool tieneEst = cmbEstimulos.SelectedItem?.ToString() == "Si";

            lblEstimulos.Visible = tieneEst;
            lblMasEst.Visible = tieneEst;
            txtEstimulos.Visible = tieneEst;
            btnCapturarEst.Visible = tieneEst;

            if (!tieneEst)
            {
                _totalEstimulos = 0;
                txtEstimulos.Text = "";
                RecalcularTotales();
            }
            else if (_totalEstimulos == 0)
            {
                txtEstimulos.Text = "";
            }

            ReorganizarPosiciones();
        }

        private void BtnCapturarComp_Click(object sender, EventArgs e)
        {
            // Reemplazar con llamada real a tu Formulario Emergente de Captura
            // Ejemplo:
            // using (var frm = new fmCapturaCompensaciones()) {
            //     if(frm.ShowDialog() == DialogResult.OK) { _totalCompensaciones = frm.MontoTotal; }
            // }

            // Mock de prueba para validar interfaz:
            _totalCompensaciones = 5000;
            txtCompensaciones.Text = _totalCompensaciones.ToString("N0");
            RecalcularTotales();
        }

        private void BtnCapturarEst_Click(object sender, EventArgs e)
        {
            // Reemplazar con llamada real a tu Formulario Emergente de Captura

            // Mock de prueba para validar interfaz:
            _totalEstimulos = 2500;
            txtEstimulos.Text = _totalEstimulos.ToString("N0");
            RecalcularTotales();
        }

        private void ReorganizarPosiciones()
        {
            int colLabel = 25;
            int colOper = 590;
            int colCampo = 620;
            int rowH = 38;
            int y = 45;

            // Fila 1: A Cargo
            lblACargo.Location = new Point(colLabel, y + 4);
            txtACargo.Location = new Point(colCampo, y);

            // Fila 2: Total Contribuciones 1
            y += rowH;
            lblTotalContrib1.Location = new Point(colLabel, y + 4);
            lblMas1.Location = new Point(colOper, y + 4);
            txtTotalContrib1.Location = new Point(colCampo, y);

            // Fila 3: ¿Tienes Compensaciones?
            y += rowH;
            lblPregCompensaciones.Location = new Point(colLabel, y + 4);
            cmbCompensaciones.Location = new Point(colCampo, y);

            // Fila 4: Detalle Compensaciones (Condicional)
            if (cmbCompensaciones.SelectedItem?.ToString() == "Si")
            {
                y += rowH;
                lblCompensaciones.Location = new Point(40, y + 4);
                lblMasComp.Location = new Point(colOper, y + 4);
                txtCompensaciones.Location = new Point(colCampo, y);
                btnCapturarComp.Location = new Point(855, y - 1);
            }

            // Fila 5: ¿Tienes Estímulos?
            y += rowH;
            lblPregEstimulos.Location = new Point(colLabel, y + 4);
            cmbEstimulos.Location = new Point(colCampo, y);

            // Fila 6: Detalle Estímulos (Condicional)
            if (cmbEstimulos.SelectedItem?.ToString() == "Si")
            {
                y += rowH;
                lblEstimulos.Location = new Point(40, y + 4);
                lblMasEst.Location = new Point(colOper, y + 4);
                txtEstimulos.Location = new Point(colCampo, y);
                btnCapturarEst.Location = new Point(855, y - 1);
            }

            // Separador Intermedio
            y += rowH + 10;
            pnlSeparador.Location = new Point(colLabel, y);

            // Fila 7: Total Aplicaciones 1
            y += 15;
            lblTotalAplicaciones1.Location = new Point(colLabel, y + 4);
            lblMasApl1.Location = new Point(colOper, y + 4);
            txtTotalAplicaciones1.Location = new Point(colCampo, y);

            // Fila 8: Total Contribuciones 2
            y += rowH;
            lblTotalContrib2.Location = new Point(colLabel, y + 4);
            txtTotalContrib2.Location = new Point(colCampo, y);

            // Fila 9: Total Aplicaciones 2
            y += rowH;
            lblTotalAplicaciones2.Location = new Point(colLabel, y + 4);
            lblMenosApl2.Location = new Point(593, y + 4);
            txtTotalAplicaciones2.Location = new Point(colCampo, y);

            // Fila 10: Cantidad a cargo
            y += rowH;
            lblCantidadACargo.Location = new Point(colLabel, y + 4);
            lblMasCant.Location = new Point(colOper, y + 4);
            txtCantidadACargo.Location = new Point(colCampo, y);

            // Fila 11: Cantidad a pagar
            y += rowH;
            lblCantidadAPagar.Location = new Point(colLabel, y + 4);
            txtCantidadAPagar.Location = new Point(colCampo, y);
        }
    }
}