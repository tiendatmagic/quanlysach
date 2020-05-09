using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //  ©2020 Copy and paste by Tiendatmagic
        private void btnKetnoi_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                using (SqlConnection connection =

                    new SqlConnection(@"Server=DESKTOP-24L225P;Database=Quanlysach; Integrated Security=SSPI"))

                {

                    connection.Open();

                }

                MessageBox.Show("Mo va dong co so du lieu thanh cong.");

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi: " + ex.Message);

            }
        }
        //  ©2020 Copy and paste by Tiendatmagic
        private void btnDulieu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=Quanlysach; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("SELECT MaSach, Tieude, NamXB, MaTG FROM Sach; ",
 connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(danhsach);
                    }
                }
                MessageBox.Show("Ket noi co so du lieu thanh cong.");
                dulieu.ItemsSource = danhsach.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }

        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Sach tiendatmagic = new Sach();
            tiendatmagic.MaSach = txtMaSach.Text;
            tiendatmagic.Tieude = txtTieude.Text;
            tiendatmagic.NamXB = txtNamXB.Text;
            tiendatmagic.MaTG = txtMaTG.Text;
            Them_sach(tiendatmagic);
        }

        private void Them_sach(Sach Sach)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=Quanlysach; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM Sach;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow tiendatmagic = danhsach.NewRow();
                    tiendatmagic["MaSach"] = Sach.MaSach;
                    tiendatmagic["Tieude"] = Sach.Tieude;
                    tiendatmagic["NamXB"] = Sach.NamXB;
                    tiendatmagic["MaTG"] = Sach.MaTG;
                    danhsach.Rows.Add(tiendatmagic);
                    adapter.Update(danhsach);
                }
                MessageBox.Show("Them du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }


        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            Sach tiendatmagic = new Sach();
            tiendatmagic.MaSach = txtMaSach.Text;
            Xoa_sach(tiendatmagic);
        }

        private void Xoa_sach(Sach Sach)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=Quanlysach; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM Sach;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow[] dt =
                    danhsach.Select("MaSach = '" + Sach.MaSach + "'");
                    dt[0].Delete();
                    adapter.Update(dt);
                }
                MessageBox.Show("Xoa du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        }

        private void btnCapnhat_Click(object sender, RoutedEventArgs e)
        {
            Sach tiendatmagic = new Sach();
            txtMaSach.MaxLength = 9;
            tiendatmagic.MaSach = txtMaSach.Text;
            tiendatmagic.Tieude = txtTieude.Text;
            tiendatmagic.NamXB = txtNamXB.Text;
            tiendatmagic.MaTG = txtMaTG.Text;
            Cap_nhat_sach(tiendatmagic);
        }

        //  ©2020 Copy and paste by Tiendatmagic
        private void Cap_nhat_sach(Sach Sach)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=Quanlysach; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM Sach;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow[] dt = danhsach.Select(
                    "MaSach = '" + Sach.MaSach + "'");
                    dt[0]["Tieude"] = Sach.Tieude;
                    dt[0]["NamXB"] = Sach.NamXB;
                    dt[0]["MaTG"] = Sach.MaTG;
                    adapter.Update(danhsach);
                }
                MessageBox.Show("Cap nhat du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        }

        private void btnthoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

//  ©2020 Copy and paste by Tiendatmagic