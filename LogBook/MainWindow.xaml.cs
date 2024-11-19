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

namespace LogBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Load base values for app
            MainWindowLogic.Load(ModuleComboBox, TopicComboBox, MessageTextBox, OutputTextBlock, DateTextBlock);
        }

        /// <summary>
        /// Adds functionality to module combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindowLogic.ModuleComboBox_SelectionChanged(ModuleComboBox);
        }

        /// <summary>
        /// Adds functionality to topic combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindowLogic.TopicComboBox_SelectionChanged(TopicComboBox);
        }

        /// <summary>
        /// Adds functionality to message textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindowLogic.MessageTextBox_TextChanged(MessageTextBox);
        }

        /// <summary>
        /// Adds functionality to output button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowLogic.OutputButton_Click(OutputTextBlock);
        }

        /// <summary>
        /// Adds functionality to add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowLogic.AddButton_Click(ModuleComboBox, TopicComboBox, MessageTextBox, OutputTextBlock);
        }

        /// <summary>
        /// Adds functionality to open button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowLogic.OpenButton_Click();
        }
    }
}
