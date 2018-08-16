using Net.ConnectCode.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void cmbMainSymbos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbMainSymbos.SelectedItem != null && !string.IsNullOrEmpty(cmbMainSymbos.SelectedItem.ToString()))
                {
                    cmbSubSymbo.Items.Clear();

                    if(cmbMainSymbos.SelectedItem.ToString() == "EAN Standards")
                    {
                        var symbols = Enum.GetValues(typeof(BarcodeFonts.EANStandardsEnum))
                                    .Cast<BarcodeFonts.EANStandardsEnum>()
                                    .Select(val => val.ToString())
                                    .ToList();
                        symbols.ForEach(s => { cmbSubSymbo.Items.Add(s); });
                    }
                    else if (cmbMainSymbos.SelectedItem.ToString() == "Other")
                    {
                        var symbols = Enum.GetValues(typeof(BarcodeFonts.BarcodeEnum))
                                    .Cast<BarcodeFonts.BarcodeEnum>()
                                    .Select(val => val.ToString())
                                    .ToList();
                        symbols.ForEach(s => { cmbSubSymbo.Items.Add(s); });
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {

                BarcodeFonts barcode = new BarcodeFonts();

                if (cmbMainSymbos.SelectedItem.ToString() == "EAN Standards")
                {
                    barcode.EANStandards = (BarcodeFonts.EANStandardsEnum)Enum.Parse(typeof(BarcodeFonts.EANStandardsEnum), cmbSubSymbo.SelectedItem.ToString());
                }
                else if (cmbMainSymbos.SelectedItem.ToString() == "Other")
                {
                    barcode.BarcodeType = (BarcodeFonts.BarcodeEnum)Enum.Parse(typeof(BarcodeFonts.BarcodeEnum),cmbSubSymbo.SelectedItem.ToString());
                }

                barcode.CheckDigit = BarcodeFonts.YesNoEnum.No;
                barcode.Data = txtInput.Text;
                //if (checkBox1.Checked)
                //    barcode.CheckDigit = BarcodeFonts.YesNoEnum.Yes;
                barcode.encode();
                txtHumanReadable.Text = barcode.HumanText;
                txtOutput.Text = barcode.EncodedData;
                Font font = new Font("CCode39_S3_Trial", 30);
                txtOutput.Font = font;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
