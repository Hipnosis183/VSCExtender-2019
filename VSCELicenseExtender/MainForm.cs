using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace VSCELicenseExtender
{
    public partial class MainForm : Form
    {
        // VS2019
        
        private const string RegSubKey = @"Licenses\41717607-F34E-432C-A138-A3CFD7E25CDA\09278";

        public MainForm()
        {
            InitializeComponent();
            GetDate();
        }

        private byte[] OpenHKCRSubKey(string SubKey)
        {
            RegistryKey RegHKCR = Registry.ClassesRoot.OpenSubKey(SubKey, true);

            byte[] EncryptedData = (byte[])RegHKCR.GetValue("", true);
            byte[] DecryptedData = ProtectedData.Unprotect(EncryptedData, null, DataProtectionScope.LocalMachine);

            RegHKCR.Close();

            return DecryptedData;
        }

        private void WriteHKCRSubKey(byte[] DecryptedData, string SubKey)
        {
            RegistryKey RegHKCR = Registry.ClassesRoot.OpenSubKey(SubKey, true);

            byte[] EncryptedData = ProtectedData.Protect(DecryptedData, null, DataProtectionScope.LocalMachine);
            
            RegHKCR.SetValue("", EncryptedData);
            RegHKCR.Close();
        }

        private void GetDate()
        {
            try
            {
                byte[] DecryptedData = OpenHKCRSubKey(RegSubKey);
                string ExpirationDate = ConvertFromBinaryDate(DecryptedData);

                TextBox_Expiration.Text = ExpirationDate;
            }

            catch
            {
                MessageBox.Show("Visual Studio Community 2019 not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ConvertFromBinaryDate(byte[] DecryptedData)
        {
            // Year

            byte[] YearB = new byte[2];
            YearB[0] = DecryptedData[DecryptedData.Length - 15];
            YearB[1] = DecryptedData[DecryptedData.Length - 16];

            string YearS = "";
            YearS += BitConverter.ToString(YearB, 0, 1);
            YearS += BitConverter.ToString(YearB, 1, 1);

            int YearI = int.Parse(YearS, System.Globalization.NumberStyles.HexNumber);

            // Month

            byte[] MonthB = new byte[2];
            MonthB[0] = DecryptedData[DecryptedData.Length - 13];
            MonthB[1] = DecryptedData[DecryptedData.Length - 14];

            string MonthS = "";
            MonthS += BitConverter.ToString(MonthB, 0, 1);
            MonthS += BitConverter.ToString(MonthB, 1, 1);

            int MonthI = int.Parse(MonthS, System.Globalization.NumberStyles.HexNumber);

            // Day

            byte[] DayB = new byte[2];
            DayB[0] = DecryptedData[DecryptedData.Length - 11];
            DayB[1] = DecryptedData[DecryptedData.Length - 12];

            string DayS = "";
            DayS += BitConverter.ToString(DayB, 0, 1);
            DayS += BitConverter.ToString(DayB, 1, 1);

            int DayI = int.Parse(DayS, System.Globalization.NumberStyles.HexNumber);

            string ExpirationDate = String.Format("{0:00}", DayI) + "/" + String.Format("{0:00}", MonthI) + "/" + YearI.ToString();

            return ExpirationDate;
        }

        private void Button_Extend_Click(object sender, EventArgs e)
        {
            try
            {
                SetDate();
                MessageBox.Show("License extended successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetDate();
            }

            catch
            {
                MessageBox.Show("The license couldn't be extended.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDate()
        {
            byte[] DecryptedData = OpenHKCRSubKey(RegSubKey);
            DateTime ExpirationDate = DateTime.Today.AddMonths(1);
            byte[] NewData = ConvertToBinaryDate(DecryptedData, ExpirationDate.Year, ExpirationDate.Month, ExpirationDate.Day);

            WriteHKCRSubKey(NewData, RegSubKey);
        }

        private byte[] ConvertToBinaryDate(byte[] DecryptedData, int Year, int Month, int Day)
        {
            // Year

            byte[] YearB = BitConverter.GetBytes(Year);
            DecryptedData[DecryptedData.Length - 16] = YearB[0];
            DecryptedData[DecryptedData.Length - 15] = YearB[1];

            // Month

            byte[] MonthB = BitConverter.GetBytes(Month);
            DecryptedData[DecryptedData.Length - 14] = MonthB[0];
            DecryptedData[DecryptedData.Length - 13] = MonthB[1];

            // Day

            byte[] DayB = BitConverter.GetBytes(Day);
            DecryptedData[DecryptedData.Length - 12] = DayB[0];
            DecryptedData[DecryptedData.Length - 11] = DayB[1];

            return DecryptedData;
        }
    }
}
