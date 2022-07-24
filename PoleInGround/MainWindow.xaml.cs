using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
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

namespace PoleInGround
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataModel dataModel;        

        public MainWindow()
        {
            dataModel = new DataModel();            
            InitializeComponent();
            this.DataContext = dataModel;
            dataModel.PropertyChanged+= new PropertyChangedEventHandler(dataModel_PropertyChanged);
        }

        private void dataModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName== "Type")
            {
                //MessageBox.Show(dataModel.Type.ToString());
                switch(dataModel.Type)
                {
                    case DataModel.EType.SVERL:
                        RadioButton1.IsChecked = true;
                        break;
                    case DataModel.EType.SVERL_VERHNIY_RIGEL:
                        RadioButton2.IsChecked = true;
                        break;
                    case DataModel.EType.KOPAN_VERHNIY_RIGEL:
                        RadioButton3.IsChecked = true;
                        break;
                    case DataModel.EType.KOPAN_VERHNIY_NIZNIY_RIGEL:
                        RadioButton4.IsChecked = true;
                        break;
                    case DataModel.EType.SVERL_VERHNIY_RIGEL_BANKETKA:
                        RadioButton5.IsChecked = true;
                        break;
                    case DataModel.EType.KOPAN_VERHNIY_BANKETKA_NIZNIY_RIGEL:
                        RadioButton6.IsChecked = true;
                        break;
                }
            }
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (PictureBox1 == null) return;            
            PictureBox1.Source = new BitmapImage(new Uri("/Resources/type1.png", UriKind.Relative));
            GroupBoxVerhRigel.IsEnabled = false;
            GroupBoxNizhniyRigel.IsEnabled = false;
            GroupBoxBanketka.IsEnabled = false;
            //binding type
            dataModel.Type = DataModel.EType.SVERL;
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            if (PictureBox1 == null) return;
            PictureBox1.Source = new BitmapImage(new Uri("/Resources/type2.png", UriKind.Relative));

            //binding type
            dataModel.Type = DataModel.EType.SVERL_VERHNIY_RIGEL;
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            if (PictureBox1 == null) return;
            PictureBox1.Source = new BitmapImage(new Uri("/Resources/type3.png", UriKind.Relative));

            //binding type
            dataModel.Type = DataModel.EType.KOPAN_VERHNIY_RIGEL;
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            if (PictureBox1 == null) return;
            PictureBox1.Source = new BitmapImage(new Uri("/Resources/type4.png", UriKind.Relative));

            //binding type
            dataModel.Type = DataModel.EType.KOPAN_VERHNIY_NIZNIY_RIGEL;
        }

        private void RadioButton5_Checked(object sender, RoutedEventArgs e)
        {
            if (PictureBox1 == null) return;
            PictureBox1.Source = new BitmapImage(new Uri("/Resources/type5.png", UriKind.Relative));

            //binding type
            dataModel.Type = DataModel.EType.SVERL_VERHNIY_RIGEL_BANKETKA;
        }

        private void RadioButton6_Checked(object sender, RoutedEventArgs e)
        {
            if (PictureBox1 == null) return;
            PictureBox1.Source = new BitmapImage(new Uri("/Resources/type6.png", UriKind.Relative));

            //binding type
            dataModel.Type = DataModel.EType.KOPAN_VERHNIY_BANKETKA_NIZNIY_RIGEL;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.dataModel.SupportType.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.dataModel.SupportType = 2;
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "xml files (*.xml)|*.xml";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    dataModel.Save(filePath);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter= "xml files (*.xml)|*.xml";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    dataModel.Load(filePath);
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
