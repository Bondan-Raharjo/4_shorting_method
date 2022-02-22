using System.Diagnostics;
namespace _4_shorting_method
{
    public partial class Form1 : Form
    {
        string[] myArray;
        int[] myInts, myInts2, myInts3, myInts4;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Prevent to get non numeric variable
        /// can receive both positive or negative number
        /// </summary>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }


        /// <summary>
        /// Start Shorting metode divided to 4 different function shorting 
        /// </summary>

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
            SaveandStored();
            Cleandatagrid();
            QuicShort();
            BubbleShort();
            MergeShort();
                findGCD(myInts4);
                dataGridView4.ColumnCount = 2;
                for (int i = 0; i < myInts4.Length; i++)
                {
                    dataGridView4.Rows.Add(new object[] { i, myInts4[i] });
                }
            }
            
        }

        private void SaveandStored() {
            myArray = textBox1.Text.Split(new Char[] { ',' });
            myInts = Array.ConvertAll(myArray, int.Parse);
            myInts2 = myInts;
            myInts3 = myInts;
            myInts4 = myInts;
        }
        private void Cleandatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
        }
        private void QuicShort()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Array.Sort(myInts);
            dataGridView1.ColumnCount = 2;
            for (int i = 0; i < myInts.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] { i, myInts[i] });
            }
            stopWatch.Stop();
            label1.Text = String.Format("time: {0} ms",
            stopWatch.Elapsed.Milliseconds / 1000.0);

        }
        private void BubbleShort()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int n = myInts2.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (myInts2[j] > myInts2[j + 1])
                    {
                        int temp = myInts2[j];
                        myInts2[j] = myInts2[j + 1];
                        myInts2[j + 1] = temp;
                    }

            dataGridView2.ColumnCount = 2;
            for (int i = 0; i < myInts2.Length; i++)
            {
                dataGridView2.Rows.Add(new object[] { i, myInts2[i] });
            }
            stopWatch.Stop();
            label2.Text = String.Format("time: {0} ms",
            stopWatch.Elapsed.Milliseconds / 1000.0);
            
        }
        private void MergeShort() {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Sort(myInts3);

            dataGridView3.ColumnCount = 2;
            for (int i = 0; i < myInts3.Length; i++)
            {
                dataGridView3.Rows.Add(new object[] { i, myInts3[i] });
            }
            stopWatch.Stop();
            label3.Text = String.Format("time: {0} ms",
            stopWatch.Elapsed.Milliseconds / 1000.0);

        }
        public  int[] Sort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];          
            if (array.Length <= 1)
                return array;           
            int midPoint = array.Length / 2;           
            left = new int[midPoint];
            if (array.Length % 2 == 0)
                right = new int[midPoint];
            else
                right = new int[midPoint + 1];
           
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];
          
            int x = 0;      
             for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = Sort(left);          
            right = Sort(right);
            result = merge(left, right);
            
            return result;

        }
        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        static int BasicGCD(int a, int b)
        {
            if (a == 0)
                return b;
            return BasicGCD(b % a, a);
        }
        static int findGCD(int[] arr)
        {int n = arr.Length;    
            int result = arr[0];
            for (int i = 1; i < n; i++)
                result = BasicGCD(arr[i], result);

            return result;
        }

    }
}