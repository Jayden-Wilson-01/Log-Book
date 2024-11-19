using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LogBook
{
    public static class MainWindowLogic
    {
        #region Properties
        /// <summary>
        /// Gets the current Date and Time
        /// </summary>
        public static DateTime? DateTime 
        {
            get {  return System.DateTime.Now; }
        }

        /// <summary>
        /// Gets or sets the college course module
        /// </summary>
        public static string? Module {  get; set; }

        /// <summary>
        /// Gets or sets the topic of module eg. Project, Test etc
        /// </summary>
        public static string? Topic { get; set; }

        /// <summary>
        /// Gets or sets the log message
        /// </summary>
        public static string? Message { get; set; }

        /// <summary>
        /// Gets or sets the output of all inputs 
        /// </summary>
        public static string? Output { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Load base values for app
        /// </summary>
        /// <param name="dateTextBlock"></param>
        public static void Load(ComboBox moduleComboBox, ComboBox topicComboBox, TextBox messageTextBox, TextBlock outputTextBlock, TextBlock dateTextBlock)
        {
            try
            {
                //Default input controls
                moduleComboBox.SelectedIndex = 0;
                topicComboBox.SelectedIndex = 0;
                messageTextBox.Text = "None";
                outputTextBlock.Text = "None";

                //Set date text block text to be the date time property value with formatting
                dateTextBlock.Text = DateTime.Value.ToString("dddd, d MMMM yyyy");

                //Default properties 
                Module = "None";
                Topic = "None";
                Message = "None";
                Output = "None";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Change module property based on module combobox selected value
        /// </summary>
        /// <param name="moduleComboBox">The combobox thats value changed</param>
        public static void ModuleComboBox_SelectionChanged(ComboBox moduleComboBox)
        {
            try
            {
                //Get current selected combobox item
                var selectedItem = moduleComboBox.SelectedItem as ComboBoxItem;

                //Set module property to be the content of selected item
                Module = selectedItem.Content.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Change topic property based on topic combobox selected value
        /// </summary>
        /// <param name="topicComboBox">The combobox thats value changed</param>
        public static void TopicComboBox_SelectionChanged(ComboBox? topicComboBox)
        {
            try
            {
                //Get current selected combobox item
                var selectedItem = topicComboBox?.SelectedItem as ComboBoxItem;

                //Set module property to be the content of selected item
                Topic = selectedItem?.Content.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Change message property based on topic message textbox value
        /// </summary>
        /// <param name="messageTextBox">The textbox thats value changed</param>
        public static void MessageTextBox_TextChanged(TextBox messageTextBox)
        {
            try
            {
                //Get current value of message textbox
                string text = messageTextBox.Text as string;

                //Set message property to be the text box value
                Message = messageTextBox.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Change output property based on input and display to output textblock
        /// </summary>
        /// <param name="outputTextBlock">The textblock that should display the output message</param>
        public static void OutputButton_Click(TextBlock outputTextBlock)
        {
            try
            {
                //Set output to be value of properties
                Output = $"{DateTime.Value.ToString("dddd, d MMMM yyyy")} {Message} - {Topic} - {Module}";

                //Set output text block text to be the output property value
                outputTextBlock.Text = Output;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Write output to log text file
        /// </summary>
        /// <param name="moduleComboBox">The combobox to be cleared</param>
        /// <param name="topicComboBox">The combobox to be cleared</param>
        /// <param name="messageTextBox">The textbox to be cleared</param>
        /// <param name="outputTextBlock">The textblock to be cleared</param>
        public static void AddButton_Click(ComboBox moduleComboBox, ComboBox topicComboBox, TextBox messageTextBox, TextBlock outputTextBlock)
        {
            try
            {
                //Write output to log text file
                using(StreamWriter sw = new StreamWriter("LogBook.txt", true))
                {
                    sw.WriteLine(Output);
                    sw.WriteLine();
                }

                //Clear input controls
                moduleComboBox.SelectedIndex = 0;
                topicComboBox.SelectedIndex = 0;
                messageTextBox.Text = "";
                outputTextBlock.Text = "Added to Log"; 

                //Clear properties 
                Module = "None";
                Topic = "None";
                Message = "None";
                Output = "None";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Open the folder directory where the log file is located
        /// </summary>
        public static void OpenButton_Click()
        {
            try
            {
                //Open file explorer at the LogBook.exe location
                Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
