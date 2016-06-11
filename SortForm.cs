using System;
using System.Media;
using System.Windows.Forms;
using SortingAlgorithms;

/*Project Number:Team Project - Sorting
 *Date: 16 December 2011
 *Programmer Name: Tara Eicher
 *Program Description: This application generates and sorts random integers and strings. It utilizes sorting
 *      algorithms that have been previously defined in a .dll. The user chooses the type of sort, the number
 *      of items to sort, and the type of object to sort (integer or string).
 */

namespace SortApplication
{
    public partial class SortForm : Form
    {
        bool exitMessageShown=false;    //Determine if the exit message has been shown, use in FormClosing.
        DialogResult exit = DialogResult.No;    //Assume the user does not want to exit.
        Random randomValue = new Random();  //Generate random values.
        string checkedSortType;     //Track the sort type.
        public SortForm()
        {
            InitializeComponent();
        }

        //Enable the user to enter a number of objects if valid sort and type are checked.
        //Track the sort type via the radio buttons.

        private void SortType_CheckedChanged(object sender, EventArgs e)
        {
            if (!radBtnNoSort.Checked && !radBtnNoData.Checked)
                txtBxNumObjects.Enabled = true;
            else
                txtBxNumObjects.Enabled = false;
            checkedSortType = ((RadioButton)sender).Name;
            txtBxNumObjects.Clear();
            txtBxOutput.Clear();
        }

        //Enable the user to enter a number of objects if valid sort and type are checked.

        private void DataType_CheckedChanged(object sender, EventArgs e)
        {
            if (!radBtnNoSort.Checked && !radBtnNoData.Checked)
                txtBxNumObjects.Enabled = true;
            else
                txtBxNumObjects.Enabled = false;
            if (radBtnInt.Checked)
                radBtnRadix.Enabled = true;
            else
            {
                radBtnRadix.Enabled = false;
                if (radBtnRadix.Checked)
                    radBtnNoSort.Checked = true;
            }
            txtBxNumObjects.Clear();
            txtBxOutput.Clear();
        }

        //Allow the user to sort if they have made an entry.

        private void txtBxNumObjects_TextChanged(object sender, EventArgs e)
        {
            if (txtBxNumObjects.Text != "")
                btnSort.Enabled = true;
            else
                btnSort.Enabled = false;
            txtBxOutput.Clear();
        }

        //Generate random objects of specified type, then place them in an array.
        //Sort the array as specified.
        //Output the sorted array and other information about the sort.

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                int numObjects = int.Parse(txtBxNumObjects.Text);
                string output = "Original Array:\n";

                //Create an integer array of specified size using random number generator.
                //Call proper sort algorithm.
                //Add sorted array to output string.
                if (radBtnInt.Checked)
                {
                    Sort<int> thisSort = new Sort<int>();
                    int[] Numbers = new int[numObjects];

                    //Build array.
                    for (int i = 0; i < numObjects; ++i)
                    {
                        int thisInteger = randomValue.Next();
                        Numbers[i] = thisInteger;
                    }

                    //Add the original array to output string.
                    foreach (int number in Numbers)
                    {
                        output += number.ToString() + "; ";
                    }
                    output += "\n\nSorted Array:\n";

                    //Utilize selected sort algorithm for output.
                    switch (checkedSortType)
                    {
                        case "radBtnBubble":
                            foreach (int number in thisSort.BubbleSort(Numbers))
                            {
                                output += number.ToString() + "; ";
                            }
                            break;
                        case "radBtnBucket":
                            try
                            {
                                foreach (int number in thisSort.BucketSort(Numbers))
                                {
                                    output += number.ToString() + "; ";
                                }
                            }
                            catch (ArgumentNullException)   //if zero integers
                            {
                            }
                            break;
                        case "radBtnHeap":
                            try
                            {
                                foreach (int number in thisSort.HeapSort(Numbers))
                                {
                                    output += number.ToString() + "; ";
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            break;
                        case "radBtnInsertion":
                            foreach (int number in thisSort.InsertionSort(Numbers))
                            {
                                output += number.ToString() + "; ";
                            }
                            break;
                        case "radBtnMerge":
                            foreach (int number in thisSort.MergeSort(Numbers))
                            {
                                output += number.ToString() + "; ";
                            }
                            break;
                        case "radBtnQuick":
                            try
                            {
                                foreach (int number in thisSort.QuickSort(Numbers))
                                {
                                    output += number.ToString() + "; ";
                                }
                            }
                            catch (IndexOutOfRangeException)    //if zero integers
                            {
                            }
                            break;
                        case "radBtnRadix":
                            foreach (int number in thisSort.RadixSort(Numbers))
                            {
                                output += number.ToString() + "; ";
                            }
                            break;
                        default:
                            foreach (int number in thisSort.Selection(Numbers))
                            {
                                output += number.ToString() + "; ";
                            }
                            break;
                    }

                    //Output other details of sort.
                    output += "\n\nNumber of Elements: " + thisSort.NumberOfElementsSorted.ToString() +
                                    "\nNumber of Comparisons: " + thisSort.NumberOfComparisonsPerformed.ToString() +
                                    "\nNumber of Swaps: " + thisSort.NumberofSwapsMade.ToString() +
                                    "\nElapsed Time: " + thisSort.Time + " milliseconds";
                    txtBxOutput.Text = output;
                    SystemSounds.Beep.Play();
                }

                //Create a string array of specified size using random number generator.
                //Call proper sort algorithm.
                //Add sorted array to output string.
                else
                {
                    Sort<string> thisSort = new Sort<string>();
                    string[] Strings = new string[numObjects];

                    //Build the array from random strings.
                    for (int i = 0; i < numObjects; ++i)
                    {
                        string thisString = "";
                        int thisInteger = randomValue.Next();   //Start with random integer.
                        char[] Digits = thisInteger.ToString().ToCharArray();     //Convert each digit to a char.
                        int numDigits = Digits.Length;
                        int j = 0;

                        //Take two digits at a time and convert them to letters in the alphabet, creating a random string.
                        do
                        {
                            string twoDigitNumber = Digits[j].ToString() + Digits[j + 1];
                            char letter = (char)((int.Parse(twoDigitNumber) % 26) + 65);
                            thisString += letter;
                            j += 2;
                        }
                        while (j < numDigits - 1);
                        Strings[i] = thisString;
                    }

                    //Add original array to output string.
                    foreach (string aString in Strings)
                    {
                        output += aString + "; ";
                    }
                    output += "\n\nSorted Array:\n";
                    switch (checkedSortType)
                    {
                        case "radBtnBubble":
                            foreach (string word in thisSort.BubbleSort(Strings))
                            {
                                output += word + "; ";
                            }
                            break;
                        case "radBtnBucket":
                            foreach (string word in thisSort.BucketSort(Strings))
                            {
                                output += word + "; ";
                            }
                            break;
                        case "radBtnHeap":
                            try
                            {
                                foreach (string word in thisSort.HeapSort(Strings))
                                {
                                    output += word + "; ";
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            break;
                        case "radBtnInsertion":
                            foreach (string word in thisSort.InsertionSort(Strings))
                            {
                                output += word + "; ";
                            }
                            break;
                        case "radBtnMerge":
                            foreach (string word in thisSort.MergeSort(Strings))
                            {
                                output += word + "; ";
                            }
                            break;
                        case "radBtnQuick":
                            try
                            {
                                foreach (string word in thisSort.QuickSort(Strings))
                                {
                                    output += word + "; ";
                                }
                            }
                            catch (IndexOutOfRangeException)    //if zero strings
                            {
                            }
                            break;
                        default:
                            foreach (string word in thisSort.Selection(Strings))
                            {
                                output += word + "; ";
                            }
                            break;
                    }
                    output += "\n\nNumber of Elements: " + thisSort.NumberOfElementsSorted.ToString() +
                                    "\nNumber of Comparisons: " + thisSort.NumberOfComparisonsPerformed.ToString() +
                                    "\nNumber of Swaps: " + thisSort.NumberofSwapsMade.ToString() +
                                    "\nElapsed Time: " + thisSort.Time + " milliseconds";
                    txtBxOutput.Text = output;
                    SystemSounds.Beep.Play();
                }
            }

            //Do not allow a non-numeric entry for number of digits.
            catch (FormatException)
            {
                MessageBox.Show("You must enter a numeric value for the number of objects. "
                    + "Do not enter commas or decimal points in your value.", "Invalid Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBxNumObjects.Focus();
                txtBxNumObjects.SelectAll();
            }

            catch (OverflowException)
            {
                MessageBox.Show("You must enter a positive value for the number of digits.", "Invalid Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Your computer does not have enough memory available to perform this sort.",
                    "Memory Overflow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Reset all data fields.

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBxNumObjects.Clear();
            radBtnNoData.Checked = true;
            radBtnNoSort.Checked = true;
            txtBxOutput.Clear();
        }

        //Ensure that the user wants to exit.
        //If so, allow the application to close and do not show the exit message again.

        private void btnExit_Click(object sender, EventArgs e)
        {
            exit = MessageBox.Show("If you exit this application, you will" +
                " lose all data. Do you wish to exit?", "Exit Application?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exit == DialogResult.Yes)
            {
                exitMessageShown = true;
                Application.Exit();
            }
        }

        //If exit message has not been shown, show it.
        //If the user does not want to exit, don't close the form.

        private void SortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitMessageShown)
                btnExit_Click(sender,e);
            if (exit == DialogResult.No)
                e.Cancel = true;
        }
    }
}
