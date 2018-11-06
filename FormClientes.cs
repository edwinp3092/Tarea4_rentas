using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormClientes : Form
    {

        ClientesBL _cliente;
        CiudadesBL _Ciudades;


        public FormClientes()
        {
            InitializeComponent();

            _cliente = new ClientesBL();
            infoclienteBindingSource.DataSource = _cliente.ObtenerCliente();

            _Ciudades = new CiudadesBL();
            listaCiudadesBindingSource.DataSource = _Ciudades.ObtenerCiudades();

        }

        /*private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            infoclienteBindingSource.EndEdit();
            var cliente = (Cliente)infoclienteBindingSource.Current;

            var resultado2 = _cliente.GuardarCliente(cliente);

            if (resultado2.Exitoso == true)
            {
                infoclienteBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado2.Mensaje);
            }

        }*/

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;

        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox1.Text != "")
            {
                var resultado2 = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado2 == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox1.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _cliente.EliminarCliente(id);

            if (resultado == true)
            {
                infoclienteBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el Cliente");
            }
        }

        private void ToolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }




        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void infoclienteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void infoclienteBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            _cliente.CancelarCambios();


        }

        private void infoclienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            infoclienteBindingSource.EndEdit();
            var cliente = (Cliente)infoclienteBindingSource.Current;

            if (fotoPictureBox .Image != null )
            {
                cliente.Foto = Program.ImageToByteArray(fotoPictureBox.Image);

            }
            else
            {
                cliente.Foto = null;

            }

            var resultado2 = _cliente.GuardarCliente(cliente);

            if (resultado2.Exitoso == true)
            {
                infoclienteBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado2.Mensaje);
            }

        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (idTextBox1.Text != "")
            {
                var resultado2 = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado2 == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox1.Text);
                    Eliminar(id);
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            _cliente.AgregarCliente();
            infoclienteBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cliente = (Cliente)infoclienteBindingSource.Current;

            if (cliente !=null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);

                }
            }
            else
            {
                MessageBox.Show("Cree un registro de cliente antes de seleccionar imagen");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
