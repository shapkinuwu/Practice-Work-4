using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Pr_3
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            
        }
        /// <summary>
        /// Метод MergeLists<T>() соединяет 2 списка и берёт из первого чётные элементы, а из второго нечётные
        /// </summary>
        static List<T> MergeLists<T>(List<T> list1, List<T> list2)
        {
            List<T> resultList = new List<T>();

            for (int i = 0, j = 0; i < list1.Count || j < list2.Count; i++, j++)
            {
                if (j < list2.Count && j % 2 == 1)
                {
                    resultList.Add(list2[j]);
                }

                if (i < list1.Count && i % 2 == 0)
                {
                    resultList.Add(list1[i]);
                }
            }
            return resultList;
        }
        private async void btn_calc_Click(object sender, EventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (String.IsNullOrEmpty(str1.Text) || String.IsNullOrEmpty(str2.Text))
            {
                if (String.IsNullOrEmpty(str1.Text))
                {
                    errorProvider.SetError(str1, "Поле не должно быть пустым!");
                    await Task.Delay(2222); // Делей нужен для того, чтобы через определённое время удалялось сообщение об ошибке // await - это оператор, который используется внутри асинхронных методов для ожидания завершения асинхронных операций.
                    errorProvider.SetError(str1, "");
                }
                if (String.IsNullOrEmpty(str2.Text))
                {
                    errorProvider.SetError(str2, "Поле не должно быть пустым!");
                    await Task.Delay(2222); // Делей нужен для того, чтобы через определённое время удалялось сообщение об ошибке // await - это оператор, который используется внутри асинхронных методов для ожидания завершения асинхронных операций.
                    errorProvider.SetError(str2, "");
                }
            }
            else
            {
                string txt = str1.Text;
                string[] lines = str1.Text.Trim().Split(new char[] { ' ' });
                List<string> lst1 = new List<string>(lines);

                string txt2 = str2.Text;
                string[] lines2 = str2.Text.Trim().Split(new char[] { ' ' });
                List<string> lst2 = new List<string>(lines2);

                List<string> list3 = MergeLists(lst1, lst2);
                result.Text = String.Join(", ", list3);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void программаРасчётыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (String.IsNullOrEmpty(str1.Text) || String.IsNullOrEmpty(str2.Text))
            {
                if (String.IsNullOrEmpty(str1.Text))
                {
                    errorProvider.SetError(str1, "Поле не должно быть пустым!");
                    await Task.Delay(2222); // Делей нужен для того, чтобы через определённое время удалялось сообщение об ошибке // await - это оператор, который используется внутри асинхронных методов для ожидания завершения асинхронных операций.
                    errorProvider.SetError(str1, "");
                }
                if (String.IsNullOrEmpty(str2.Text))
                {
                    errorProvider.SetError(str2, "Поле не должно быть пустым!");
                    await Task.Delay(2222); // Делей нужен для того, чтобы через определённое время удалялось сообщение об ошибке // await - это оператор, который используется внутри асинхронных методов для ожидания завершения асинхронных операций.
                    errorProvider.SetError(str2, "");
                }
            }
            else
            {
                string txt = str1.Text;
                string[] lines = txt.Split(',');
                List<string> lst1 = new List<string>(lines);

                string txt2 = str2.Text;
                string[] lines2 = txt2.Split(',');
                List<string> lst2 = new List<string>(lines2);

                List<string> list3 = MergeLists(lst1, lst2);
                result.Text = String.Join(", ", list3);
            }
        }

        private void DeleteMenuTools_Click(object sender, EventArgs e)
        {
            str1.Clear();
            str2.Clear();
            result.Clear();
        }

        private void ExitMenuTools_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutProgrammMenuTools_Click(object sender, EventArgs e)
        {
            Form Spr = new Form();
            Spr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}