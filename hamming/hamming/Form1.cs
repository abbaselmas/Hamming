using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hamming
{
    public partial class Form1 : Form
    {
        FileStream file;
        public byte[] bytes;
        public byte[] decodes;
        public string[] bytes2;
        public string[] encoded;
        public string[] decoded;
        public string[] decoded2;
        
        int corrected;
        int corrupted;
        int unfixed;
        static Random temp = new Random();
        int p1, p2, p3, p4;
        StringBuilder sb;
        double bitEr = 0;
        

        string[] te = { "00000000", "11100001", "10011001", "01111000", "01010101", "10110100", "11001100", "00101101", 
                        "11010010", "00110011", "01001011", "10101010", "10000111", "01100110", "00011110", "11111111" };
        string[] de = { "0000",     "1000",     "0100",     "1100",     "0010",     "1010",     "0110",     "1110", 
                        "0001",     "1001",     "0101",     "1101",     "0011",     "1011",     "0111",     "1111"     };
        public Form1()
        {
            InitializeComponent();
        }

        private void encoder_Click(object sender, EventArgs e)
        {
            
            bytes2 = new string[file.Length*2];
            encoded = new string[file.Length*2]; //codeword 8bits
            for (int i = 0, j=0; i< file.Length; i++, j+=2)
            {
                string g = Convert.ToString(bytes[i], 2);
                int boy = g.Length;
                if(boy < 8)
                {
                    for (int z = 0; z < (8-boy) ; z++ )
                    {
                        g = "0" + g; // 8 bit e sıfır ekleyerek tamamla
                    }
                }

                bytes2[j]     = g.Substring(0, 4); // ikiye böl
                bytes2[j + 1] = g.Substring(4, 4); //bytes2 arrayinde tut
                g = ""; boy = 0;
            }

            char[] a;
            for(int i = 0 ; i<bytes2.Length; i++)
            {
                a = bytes2[i].ToCharArray(); //d1 d2 d3 d4
                p1 = (Convert.ToByte(a[0]) + Convert.ToByte(a[1]) + Convert.ToByte(a[3])) % 2;
                p2 = (Convert.ToByte(a[0]) + Convert.ToByte(a[2]) + Convert.ToByte(a[3])) % 2;
                p3 = (Convert.ToByte(a[1]) + Convert.ToByte(a[2]) + Convert.ToByte(a[3])) % 2;
                p4 = (p1 + p2 + Convert.ToByte(a[0]) + p3 + Convert.ToByte(a[1]) + Convert.ToByte(a[2]) + Convert.ToByte(a[3])) % 2;

                encoded[i] = p1.ToString() + p2.ToString() + a[0] + p3.ToString() + a[1] + a[2] + a[3] + p4.ToString();
            }

            bitErrorRate.Enabled = true;
        }

        private void corrupt_Click(object sender, EventArgs e)
        {
            bitEr = Convert.ToDouble(bitErrorRate.Text);
            int ctrl = (int)(encoded.Length * 8 * bitEr);

            for (int y = 0; y<ctrl ;y++ )
            {
                int a = temp.Next(encoded.Length);
                int b = temp.Next(8);
                sb = new StringBuilder(encoded[a]);
                if (sb[b] == '0')
                {
                    sb[b] = '1';
                }
                else
                {
                    sb[b] = '0';
                }
                encoded[a] = sb.ToString();
            }

            decoder.Enabled = true;
            corrupted = ctrl;

            result.Text += "Curropted bit number: " + corrupted + "\n";

        }

        private void decoder_Click(object sender, EventArgs e)
        {
            decoded2 = new string[encoded.Length];
            for (int ab = 0; ab<decoded2.Length ;ab++ )
            {
                for (int i = 0; i < 16; i++)
                {
                    if (encoded[ab] == te[i])
                    {
                        decoded2[ab] = de[i]; // 8 liye bak eşitse 4 lü halini decoded2 yaz sonra birleştirilecek
                    }
                }
                if (decoded2[ab] == null) // null or ""
                {
                    int[] count = new int[16]; //herbir eleman ile olan hd farkını tutacağım
                    for (int i = 0; i < 16; i++)
                    {
                        string hd = Convert.ToString((Convert.ToByte(encoded[ab], 2) ^ Convert.ToByte(te[i], 2)), 2);
                        char[] e1 = hd.ToCharArray();
                        for (int j = 0; j < e1.Length; j++)
                        {
                            if (e1[j] == '1')
                                count[i]++;
                        }
                    }
                    
                    for (int i = 0; i < 16; i++)
                    {
                        if (count[i] == 1)
                        {
                            decoded2[ab] = de[i];
                            corrected++;
                        }
                    }
                    
                }
            }
            unfixed = corrupted - corrected;
            //birleştirme
            decoded = new string[decoded2.Length/2];
            decodes = new byte[decoded.Length];
            for(int i=0, j=0; i<decoded.Length ;i++, j+=2)
            {
                decoded[i] = decoded2[j] + decoded2[j + 1];
                decodes[i] = Convert.ToByte(decoded[i],2);
            }

            save.Enabled = true;
            result.Text += "Corrected bit number: " + corrected + "\n";

            result.Text += "Unfixed bit number: " + unfixed + "\n";
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                //string safeFilePath = ofd.SafeFileName;
                file = new FileStream(path, FileMode.Open, FileAccess.Read);
                bytes = new byte[file.Length];

                int numBytesToRead = (int)file.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = file.Read(bytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
            }

            encoder.Enabled = true;
            result.Text += "Number of input bits: " + bytes.Length * 8 + "\n";
        }


        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                File.WriteAllBytes(path,decodes);
            }


        }

        private void reset_Click(object sender, EventArgs e)
        {
            bytes = null;
            decodes =null;
            bytes2 =null;
            encoded = null;
            decoded = null;
            decoded2 = null;
        
            int corrected = 0;
            int corrupted = 0;
            int unfixed =0;
            int p1 =0 , p2=0, p3=0, p4=0;
        
            double bitEr = 0;
            encoder.Enabled = false;
            bitErrorRate.Enabled = false;
            corrupt.Enabled = false;
            decoder.Enabled = false;
            result.Text = null;
            save.Enabled = false;
            bitErrorRate.Text = "0,01";

        }

        private void bitErrorRate_Click(object sender, EventArgs e)
        {
            corrupt.Enabled = true;
        }
    }
}
