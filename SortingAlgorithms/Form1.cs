using System;
using System.CodeDom.Compiler;
using System.Drawing.Text;
using System.IO.Pipes;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public partial class Form1 : Form
    {
        int[] tab = { };
        Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox1.Checked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = true;
                label4.Enabled = true;
                dl.Enabled = true;
                generate.Enabled = true;

            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = false;
                label4.Enabled = false;
                dl.Enabled = false;
                generate.Enabled = false;
            }
        }
        private int[] convert(string napis)
        {
            try
            {
                var liczbyS = napis.Trim().Split(' ');
                var liczby = new int[liczbyS.Length];
                for (int i = 0; i < liczbyS.Length; i++)
                    liczby[i] = int.Parse(liczbyS[i]);
                return liczby;
            }
            catch (FormatException ex)
            {

                MessageBox.Show("Wyst¹pi³ b³¹d:\n" + ex);
                return new int[0];
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Wyst¹pi³ b³¹d:\n" + ex);
                return new int[0];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dl_ValueChanged(object sender, EventArgs e)
        {
            dl.Maximum = 2000000;
        }

        private int[] generateRandom(int n)
        {
            int[] tab = new int[n + 1];
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < n; i++)
                tab[i] = random.Next(1, 1001);
            return tab;
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tab = generateRandom((int)dl.Value);
                label6.Text = "array has been generated";
            }
            else
            {
                MessageBox.Show("Nie zaznaczono checkboxa");
            }
        }

        private int[] bubble_sort(int[] tab)
        {
            int n = tab.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i; j++)
                    if (j < n - 1 && tab[j] > tab[j + 1])
                    {
                        int temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
            return tab;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                stopwatch.Start();
                int[] sorted = bubble_sort(tab);
                stopwatch.Stop();
                double czas = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
                label4.Text = czas.ToString() + " seconds";
                stopwatch.Reset();

            }
            else
            {
                int[] unsorted = convert(textBox1.Text);
                int[] sorted = bubble_sort(unsorted);
                textBox2.Text = string.Join(" ", sorted);
            }
        }

        private int[] selection_sort(int[] tab)
        {
            int n = tab.Length;
            int i = 0;
            while (i < n - 1)
            {
                int minIndex = i;
                int j = i + 1;
                while (j < n)
                {
                    if (tab[j] < tab[minIndex])
                    {
                        minIndex = j;
                    }
                    j++;
                }
                int temp = tab[i];
                tab[i] = tab[minIndex];
                tab[minIndex] = temp;
                i++;
            }
            return tab;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                stopwatch.Start();
                int[] sorted = selection_sort(tab);
                stopwatch.Stop();
                double czas = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
                label4.Text = czas.ToString() + " seconds";
                stopwatch.Reset();

            }
            else
            {
                int[] unsorted = convert(textBox1.Text);
                int[] sorted = selection_sort(unsorted);
                textBox2.Text = string.Join(" ", sorted);
            }
        }

        private int[] insertion_sort(int[] tab)
        {
            int n = tab.Length;
            for (int i = 1; i < n; i++)
            {
                int key = tab[i];
                int j = i - 1;

                while (j >= 0 && tab[j] > key)
                {
                    tab[j + 1] = tab[j];
                    j = j - 1;
                }
                tab[j + 1] = key;
            }
            return tab;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                stopwatch.Start();
                int[] sorted = insertion_sort(tab);
                stopwatch.Stop();
                double czas = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
                label4.Text = czas.ToString() + " seconds";
                stopwatch.Reset();

            }
            else
            {
                int[] unsorted = convert(textBox1.Text);
                int[] sorted = insertion_sort(unsorted);
                textBox2.Text = string.Join(" ", sorted);
            }
        }

        private int[] merge_sort(int[] tab)
        {
            if (tab.Length > 1)
            {
                int mid = tab.Length / 2;

                int[] left = new int[mid];
                for (int i = 0; i < mid; i++)
                {
                    left[i] = tab[i];
                }


                int[] right = new int[tab.Length - mid];
                for (int i = mid, j = 0; i < tab.Length; i++, j++)
                {
                    right[j] = tab[i];
                }

                merge_sort(left);
                merge_sort(right);

                int x = 0, y = 0, k = 0;
                while (x < left.Length && y < right.Length)
                {
                    if (left[x] < right[y])
                    {
                        tab[k] = left[x];
                        x++;
                    }
                    else
                    {
                        tab[k] = right[y];
                        y++;
                    }
                    k++;
                }
                while (x < left.Length)
                {
                    tab[k] = left[x];
                    x++;
                    k++;
                }
                while (y < right.Length)
                {
                    tab[k] = right[y];
                    y++;
                    k++;
                }
                return tab;
            }
            return tab;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                stopwatch.Start();
                int[] sorted = merge_sort(tab);
                stopwatch.Stop();
                double czas = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
                label4.Text = czas.ToString() + " seconds";
                stopwatch.Reset();
            }
            else
            {
                int[] unsorted = convert(textBox1.Text);
                int[] sorted = merge_sort(unsorted);
                textBox2.Text = string.Join(" ", sorted);
            }
        }

        int partition(int[] tab, int start, int end)
        {
            int pivot = tab[end];
            int low = start;
            int high = end - 1;

            while (true)
            {
                while (low <= high && tab[low] <= pivot)
                    low++;

                while (low <= high && tab[high] >= pivot)
                    high--;

                if (low <= high)
                {
                    int temp = tab[low];
                    tab[low] = tab[high];
                    tab[high] = temp;
                }
                else
                {
                    break;
                }
            }
            int temp2 = tab[end];
            tab[end] = tab[low];
            tab[low] = temp2;
            return low;
        }

        private int[] quick_sort(int[] tab, int start, int end)
        {
            if (start < end)
            {
                int pivot = partition(tab, start, end);
                quick_sort(tab, start, pivot - 1);
                quick_sort(tab, pivot + 1, end);
                return tab;
            }
            return tab;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                stopwatch.Start();
                int[] sorted = quick_sort(tab, 0, tab.Length - 1);
                stopwatch.Stop();
                double czas = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);
                label4.Text = czas.ToString() + " seconds";
                stopwatch.Reset();

            }
            else
            {
                int[] unsorted = convert(textBox1.Text);
                int[] sorted = quick_sort(unsorted, 0, unsorted.Length - 1);
                textBox2.Text = string.Join(" ", sorted);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}