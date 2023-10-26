namespace VMA_Spectrum_Analyser_for_CRTU
{
    using Ivi.Visa.Interop;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.IO.Ports;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Threading;
    using System.Windows.Forms;
    using VMA_Spectrum_Analyser_for_CRTU.My;

    [ComVisible(true), DesignerGenerated, PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    public class Form1 : Form
    {
        private ResourceManagerClass rm;
        private FormattedIO488Class ioobj;
        private object idnItem;
        private object[] idnItems;
        private NetworkStream oTCPStream;
        private TcpClient oTCP;
        private byte[] bytWriting;
        private byte[] bytReading;
        private string[,] gps_data;
        private string gps_debug;
        private bool logger_record;
        private bool logger_play;
        private bool logger_stop;
        private bool log_marker1;
        private string LOG_Filename;
        private string LogFileToSaveAs;
        private Pen cor_vermelho;
        private Pen cor_laranja;
        private Pen cor_amarelo;
        private Pen cor_azul;
        private Pen cor_preto;
        private Pen cor_verde;
        private Pen cor_verde_escuro;
        private Pen cor_azul_claro;
        private Pen cinza_escuro;
        private Pen cinza_claro;
        private Pen cyan;
        private Pen cor_trigger_red;
        private Pen cor_trigger_blue;
        private Color[] colormap;
        private Bitmap bmp1;
        private Bitmap bmp2;
        private Bitmap bmp3;
        private Graphics grafico1;
        private Graphics grafico2;
        private Graphics grafico3;
        private Bitmap trigger_map;
        private bool rx_changed;
        private bool tx_changed;
        private float[,] trace;
        private string[] dump2;
        private float[,] average;
        private float[,] colortrace;
        private int avg;
        private float db_max;
        private float db_min;
        private int wx;
        private byte ct;
        private bool start;
        private int xview;
        private int yview;
        private byte set_mem;
        private bool trace_export;
        private bool overlay;
        private bool save_overlay;
        private int[] swr_marker;
        private byte swr_count;
        private bool record;
        private bool play;
        private string rec_filename;
        private string play_filename;
        private int[] red;
        private int[] blue;
        private bool trigger_active;
        private bool alarm;
        private bool alarm_timeout;
        private int mouse_x_up;
        private int mouse_y_up;
        private int mouse_x_down;
        private int mouse_y_down;
        private string status;
        private string min_freq;
        private string max_freq;
        private bool SSA_connected;
        private string SSA_Model;
        private string SSA_Serial;
        private string SSA_FW;
        private int[] transponder;
        private int trans_count;
        private bool save_transponder;
        private string[,] transponder_list;
        private string satellite_found;
        private int sensitivity;
        private int total_satellite;
        private int satellite_id;
        private byte marker;
        private int marker1;
        private int marker2;
        private bool TG;
        private IContainer components;

        public Form1()
        {
            base.Load += new EventHandler(this.Form1_Load);
            base.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
            this.oTCP = new TcpClient();
            this.gps_data = new string[3, 4];
            this.gps_debug = "";
            this.logger_record = false;
            this.logger_play = false;
            this.logger_stop = false;
            this.log_marker1 = false;
            this.LOG_Filename = "";
            this.LogFileToSaveAs = "";
            this.cor_vermelho = new Pen(Color.Red);
            this.cor_laranja = new Pen(Color.Orange);
            this.cor_amarelo = new Pen(Color.Yellow);
            this.cor_azul = new Pen(Color.Blue, 1f);
            this.cor_preto = new Pen(Color.Black);
            this.cor_verde = new Pen(Color.Green, 1f);
            this.cor_verde_escuro = new Pen(Color.DarkGreen);
            this.cor_azul_claro = new Pen(Color.Blue);
            this.cinza_escuro = new Pen(Color.FromArgb(0x4b, 0x4b, 0x4b));
            this.cinza_claro = new Pen(Color.FromArgb(0xaf, 0xaf, 0xaf));
            this.cyan = new Pen(Color.Cyan);
            this.cor_trigger_red = new Pen(Color.FromArgb(250, 0, 0));
            this.cor_trigger_blue = new Pen(Color.FromArgb(0, 0, 250));
            this.colormap = new Color[0x100];
            this.bmp1 = new Bitmap(560, 500);
            this.bmp2 = new Bitmap(560, 100);
            this.bmp3 = new Bitmap(560, 500);
            this.rx_changed = false;
            this.tx_changed = false;
            this.trace = new float[0x231, 11];
            this.dump2 = new string[0x231];
            this.average = new float[0x231, 0x2711];
            this.colortrace = new float[0x231, 0x101];
            this.avg = 0;
            this.wx = 0;
            this.ct = 0;
            this.start = false;
            this.xview = 3;
            this.yview = 7;
            this.set_mem = 0;
            this.trace_export = false;
            this.overlay = false;
            this.save_overlay = false;
            this.swr_marker = new int[10];
            this.swr_count = 0;
            this.record = false;
            this.play = false;
            this.rec_filename = "";
            this.play_filename = "";
            this.red = new int[0x231];
            this.blue = new int[0x231];
            this.trigger_active = false;
            this.alarm = false;
            this.alarm_timeout = false;
            this.mouse_x_up = 0;
            this.mouse_y_up = -1;
            this.mouse_x_down = 0;
            this.mouse_y_down = -1;
            this.status = "";
            this.min_freq = "10 MHz";
            this.max_freq = "2700 MHz";
            this.SSA_connected = false;
            this.SSA_Model = "";
            this.SSA_Serial = "";
            this.SSA_FW = "";
            this.transponder = new int[0x3e9];
            this.trans_count = 0;
            this.save_transponder = false;
            this.transponder_list = new string[0x97, 0x3e9];
            this.satellite_found = "";
            this.sensitivity = 1;
            this.total_satellite = 0;
            this.satellite_id = 0;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.TG = false;
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox20.Text;
            this.TextBox4.Text = this.TextBox21.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox26.Text;
            this.TextBox4.Text = this.TextBox27.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox29.Text;
            this.TextBox4.Text = this.TextBox30.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox32.Text;
            this.TextBox4.Text = this.TextBox33.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox35.Text;
            this.TextBox4.Text = this.TextBox36.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox38.Text;
            this.TextBox4.Text = this.TextBox39.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox41.Text;
            this.TextBox4.Text = this.TextBox42.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox44.Text;
            this.TextBox4.Text = this.TextBox45.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox13.Text;
            this.TextBox4.Text = this.TextBox14.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (this.Button18.BackColor == Color.Green)
            {
                this.Button18.BackColor = Color.Transparent;
            }
            else
            {
                this.Button18.BackColor = Color.Green;
            }
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            if (this.Button19.BackColor == Color.Red)
            {
                this.Button19.BackColor = Color.Transparent;
            }
            else
            {
                this.Button19.BackColor = Color.Red;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = Conversion.Str(Conversion.Int((double) (Conversion.Val(this.TextBox1.Text) + 5.0)));
            if (Conversion.Val(this.TextBox1.Text) > 80.0)
            {
                this.TextBox1.Text = Conversion.Str((int) 80);
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            if (this.Button20.BackColor == Color.Blue)
            {
                this.Button20.BackColor = Color.Transparent;
            }
            else
            {
                this.Button20.BackColor = Color.Blue;
            }
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            if (this.Button21.BackColor == Color.Cyan)
            {
                this.Button21.BackColor = Color.Transparent;
            }
            else
            {
                this.Button21.BackColor = Color.Cyan;
            }
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            if (this.Button22.BackColor == Color.Gray)
            {
                this.Button22.BackColor = Color.Transparent;
            }
            else
            {
                this.Button22.BackColor = Color.Gray;
            }
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            if (this.Button23.BackColor == Color.Orange)
            {
                this.Button23.BackColor = Color.Transparent;
                this.set_mem = 0;
            }
            else
            {
                this.Button23.BackColor = Color.Orange;
                this.set_mem = 1;
            }
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            if (this.Button24.BackColor == Color.Orange)
            {
                this.Button24.BackColor = Color.Transparent;
                this.set_mem = 0;
            }
            else
            {
                this.Button24.BackColor = Color.Orange;
                this.set_mem = 2;
            }
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            if (this.Button25.BackColor == Color.Orange)
            {
                this.Button25.BackColor = Color.Transparent;
                this.set_mem = 0;
            }
            else
            {
                this.Button25.BackColor = Color.Orange;
                this.set_mem = 3;
            }
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            if (this.Button26.BackColor == Color.Orange)
            {
                this.Button26.BackColor = Color.Transparent;
                this.set_mem = 0;
            }
            else
            {
                this.Button26.BackColor = Color.Orange;
                this.set_mem = 4;
            }
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            if (this.Button27.BackColor == Color.Orange)
            {
                this.Button27.BackColor = Color.Transparent;
                this.set_mem = 0;
            }
            else
            {
                this.Button27.BackColor = Color.Orange;
                this.set_mem = 5;
            }
        }

        private void Button28_Click(object sender, EventArgs e)
        {
            MyProject.Forms.Form6.ShowDialog();
        }

        private void Button29_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (true)
            {
                this.trace[num, 3] = float.PositiveInfinity;
                num++;
                if (num > 560)
                {
                    return;
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.db_max = -200f;
            this.db_min = 200f;
            int num = 0;
            while (true)
            {
                if (this.trace[num, 1] > this.db_max)
                {
                    this.db_max = this.trace[num, 1];
                }
                if (this.trace[num, 1] < this.db_min)
                {
                    this.db_min = this.trace[num, 1];
                }
                num++;
                if (num > 0x22e)
                {
                    this.TextBox1.Text = Conversion.Str(Conversion.Int((double) (this.db_max + 0.5)));
                    this.TextBox2.Text = Conversion.Str(Conversion.Int((double) (this.db_min + 0.5)));
                    return;
                }
            }
        }

        private void Button30_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (true)
            {
                this.trace[num, 2] = float.NegativeInfinity;
                num++;
                if (num > 560)
                {
                    return;
                }
            }
        }

        private void Button31_Click(object sender, EventArgs e)
        {
            int num = 0;
            while (true)
            {
                this.trace[num, 4] = 0f;
                num++;
                if (num > 560)
                {
                    this.avg = 0;
                    return;
                }
            }
        }

        private void Button32_Click(object sender, EventArgs e)
        {
            this.trace_export = true;
        }

        private void Button33_Click(object sender, EventArgs e)
        {
            this.overlay = false;
        }

        private void Button34_Click(object sender, EventArgs e)
        {
            this.save_overlay = true;
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                DefaultExt = "*.cos",
                Filter = "CRTU Overlay Spectrum (.cos)|*.cos"
            };
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                StreamReader reader = new StreamReader(dialog.FileName);
                int num = 0;
                while (true)
                {
                    this.trace[num, 7] = (float) Conversion.Val(reader.ReadLine());
                    num++;
                    if (num > 0x22f)
                    {
                        this.overlay = true;
                        break;
                    }
                }
            }
        }

        private void Button36_Click(object sender, EventArgs e)
        {
            if (this.record)
            {
                this.record = false;
                this.Button36.BackColor = Color.Transparent;
            }
            else
            {
                this.record = true;
                this.Button36.BackColor = Color.Red;
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "*.csf",
                    Filter = "CRTU Spectrum File (.csf)|*.csf"
                };
                dialog.ShowDialog();
                this.rec_filename = dialog.FileName;
                if (this.rec_filename == "")
                {
                    this.record = false;
                    this.Button36.BackColor = Color.Transparent;
                }
            }
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            if (this.play)
            {
                this.play = false;
                this.GroupBox1.Enabled = true;
                this.GroupBox5.Enabled = true;
                this.Button37.BackColor = Color.Transparent;
            }
            else
            {
                this.play = true;
                this.GroupBox1.Enabled = false;
                this.GroupBox5.Enabled = false;
                this.Button37.BackColor = Color.Green;
                OpenFileDialog dialog = new OpenFileDialog {
                    DefaultExt = "*.csf",
                    Filter = "CRTU Spectrum File (.csf)|*.csf"
                };
                dialog.ShowDialog();
                this.play_filename = dialog.FileName;
                if (this.play_filename != "")
                {
                    this.start = false;
                    this.Button42.Text = "START";
                    this.spectrum_playback();
                }
                else
                {
                    this.play = false;
                    this.GroupBox1.Enabled = true;
                    this.GroupBox5.Enabled = true;
                    this.Button36.BackColor = Color.Transparent;
                }
            }
        }

        private void Button38_Click(object sender, EventArgs e)
        {
            this.TextBox12.Text = this.HzToMHz(Conversions.ToString((float) (this.MHzToHz(this.TextBox12.Text) / 2f)));
            this.TextBox3.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) - (0.5 * this.MHzToHz(this.TextBox12.Text)))));
            if (this.MHzToHz(this.TextBox3.Text) < this.MHzToHz(this.min_freq))
            {
                this.TextBox3.Text = this.min_freq;
            }
            this.TextBox4.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) + (0.5 * this.MHzToHz(this.TextBox12.Text)))));
            if (this.MHzToHz(this.TextBox4.Text) > this.MHzToHz(this.max_freq))
            {
                this.TextBox4.Text = this.max_freq;
            }
            this.update_centre_frequency();
            this.update_span();
        }

        private void Button39_Click(object sender, EventArgs e)
        {
            this.TextBox12.Text = this.HzToMHz(Conversions.ToString((float) (this.MHzToHz(this.TextBox12.Text) * 2f)));
            if (this.MHzToHz(this.TextBox12.Text) > this.MHzToHz(this.max_freq))
            {
                this.TextBox12.Text = this.max_freq;
            }
            this.TextBox3.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) - (0.5 * this.MHzToHz(this.TextBox12.Text)))));
            if (this.MHzToHz(this.TextBox3.Text) < this.MHzToHz(this.min_freq))
            {
                this.TextBox3.Text = this.min_freq;
            }
            this.TextBox4.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) + (0.5 * this.MHzToHz(this.TextBox12.Text)))));
            if (this.MHzToHz(this.TextBox4.Text) > this.MHzToHz(this.max_freq))
            {
                this.TextBox4.Text = this.max_freq;
            }
            this.update_centre_frequency();
            this.update_span();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = Conversion.Str(Conversion.Int((double) (Conversion.Val(this.TextBox1.Text) - 5.0)));
            if (Conversion.Val(this.TextBox1.Text) <= Conversion.Val(this.TextBox2.Text))
            {
                this.TextBox1.Text = Conversion.Str(Conversion.Val(this.TextBox2.Text) + 5.0);
            }
        }

        private void Button40_Click(object sender, EventArgs e)
        {
            if (this.Button40.BackColor == Color.DarkTurquoise)
            {
                this.Button40.BackColor = Color.Transparent;
            }
            else
            {
                this.Button40.BackColor = Color.DarkTurquoise;
                this.Button41.BackColor = Color.Transparent;
            }
        }

        private void Button41_Click(object sender, EventArgs e)
        {
            if (this.Button41.BackColor == Color.DarkSalmon)
            {
                this.Button41.BackColor = Color.Transparent;
            }
            else
            {
                this.Button41.BackColor = Color.DarkSalmon;
                this.Button40.BackColor = Color.Transparent;
            }
        }

        private void Button42_Click(object sender, EventArgs e)
        {
            if (this.start)
            {
                this.start = false;
                this.Button42.Text = "START";
                this.Button42.BackColor = Color.Transparent;
                this.Label5.Text = "NOT CONNECTED";
            }
            else
            {
                this.start = true;
                this.Button42.Text = "STOP";
                this.Button42.BackColor = Color.LightGreen;
                this.rm = new ResourceManagerClass();
                this.ioobj = new FormattedIO488Class();
                string str = "";
                this.ioobj.set_IO((IMessage) this.rm.Open(this.TextBox56.Text, 0, 0x7d0, ""));
                this.ioobj.WriteString(this.TextBox6.Text + ";*IDN?", true);
                this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                object[] idnItems = this.idnItems;
                for (int i = 0; i < idnItems.Length; i++)
                {
                    this.idnItem = idnItems[i];
                    str = str + this.idnItem.ToString() + " ";
                }
                this.Label5.Text = str;
                this.ioobj.WriteString(this.TextBox6.Text + ";SPECtrum:FREQuency:STARt?", true);
                this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                str = Conversions.ToString(this.idnItems[this.idnItems.Count<object>() - 1]);
                this.TextBox3.Text = this.convert_freq(Conversion.Str(Conversions.ToDouble(str) / 0x3e8) + " KHz");
                this.ioobj.WriteString(this.TextBox6.Text + ";SPECtrum:FREQuency:STOP?", true);
                this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                str = Conversions.ToString(this.idnItems[this.idnItems.Count<object>() - 1]);
                this.TextBox4.Text = this.convert_freq(Conversion.Str(Conversions.ToDouble(str) / 0x3e8) + " KHz");
                this.update_centre_frequency();
                this.update_span();
                this.ioobj.WriteString(this.TextBox6.Text + ";INPUT?", true);
                this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                str = Conversions.ToString(this.idnItems[this.idnItems.Count<object>() - 1]);
                if (Strings.InStr(str.ToString(), "RF1", CompareMethod.Binary) > 0)
                {
                    this.RadioButton1.Checked = true;
                }
                if (Strings.InStr(str.ToString(), "RF2", CompareMethod.Binary) > 0)
                {
                    this.RadioButton2.Checked = true;
                }
                if (Strings.InStr(str.ToString(), "RF4", CompareMethod.Binary) > 0)
                {
                    this.RadioButton3.Checked = true;
                }
                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT?", true);
                this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                str = Conversions.ToString(this.idnItems[this.idnItems.Count<object>() - 1]);
                if (Strings.InStr(str.ToString(), "RF1", CompareMethod.Binary) > 0)
                {
                    this.RadioButton4.Checked = true;
                }
                if (Strings.InStr(str.ToString(), "RF2", CompareMethod.Binary) > 0)
                {
                    this.RadioButton5.Checked = true;
                }
                if (Strings.InStr(str.ToString(), "RF3", CompareMethod.Binary) > 0)
                {
                    this.RadioButton6.Checked = true;
                }
                this.ioobj.get_IO().Close();
                this.Spectrum();
            }
        }

        private void Button43_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (!((this.MHzToHz(this.TextBox20.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox20.Text) > this.MHzToHz(this.TextBox21.Text))))
            {
                this.TextBox20.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox20.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox21.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox20.Text) > this.MHzToHz(this.TextBox21.Text))))
            {
                this.TextBox21.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox21.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox23.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox23.Text) > this.MHzToHz(this.TextBox24.Text))))
            {
                this.TextBox23.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox23.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox24.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox23.Text) > this.MHzToHz(this.TextBox24.Text))))
            {
                this.TextBox24.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox24.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox26.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox26.Text) > this.MHzToHz(this.TextBox27.Text))))
            {
                this.TextBox26.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox26.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox27.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox26.Text) > this.MHzToHz(this.TextBox27.Text))))
            {
                this.TextBox27.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox27.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox29.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox29.Text) > this.MHzToHz(this.TextBox30.Text))))
            {
                this.TextBox29.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox29.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox30.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox29.Text) > this.MHzToHz(this.TextBox30.Text))))
            {
                this.TextBox30.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox30.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox32.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox32.Text) > this.MHzToHz(this.TextBox33.Text))))
            {
                this.TextBox32.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox32.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox33.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox32.Text) > this.MHzToHz(this.TextBox33.Text))))
            {
                this.TextBox33.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox33.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox35.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox35.Text) > this.MHzToHz(this.TextBox36.Text))))
            {
                this.TextBox35.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox35.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox36.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox35.Text) > this.MHzToHz(this.TextBox36.Text))))
            {
                this.TextBox36.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox36.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox38.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox38.Text) > this.MHzToHz(this.TextBox39.Text))))
            {
                this.TextBox38.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox38.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox39.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox38.Text) > this.MHzToHz(this.TextBox39.Text))))
            {
                this.TextBox39.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox39.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox41.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox41.Text) > this.MHzToHz(this.TextBox42.Text))))
            {
                this.TextBox41.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox41.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox42.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox41.Text) > this.MHzToHz(this.TextBox42.Text))))
            {
                this.TextBox42.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox42.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox44.Text) < this.MHzToHz(this.min_freq)) | (this.MHzToHz(this.TextBox44.Text) > this.MHzToHz(this.TextBox45.Text))))
            {
                this.TextBox44.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox44.BackColor = Color.Red;
                flag = false;
            }
            if (!((this.MHzToHz(this.TextBox45.Text) > this.MHzToHz(this.max_freq)) | (this.MHzToHz(this.TextBox44.Text) > this.MHzToHz(this.TextBox45.Text))))
            {
                this.TextBox45.BackColor = Color.LightBlue;
            }
            else
            {
                this.TextBox45.BackColor = Color.Red;
                flag = false;
            }
            if (flag)
            {
                this.Button1.Text = this.TextBox19.Text;
                this.Button9.Text = this.TextBox22.Text;
                this.Button10.Text = this.TextBox25.Text;
                this.Button11.Text = this.TextBox28.Text;
                this.Button12.Text = this.TextBox31.Text;
                this.Button13.Text = this.TextBox34.Text;
                this.Button14.Text = this.TextBox37.Text;
                this.Button15.Text = this.TextBox40.Text;
                this.Button16.Text = this.TextBox43.Text;
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset1", this.TextBox19.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset2", this.TextBox22.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset3", this.TextBox25.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset4", this.TextBox28.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset5", this.TextBox31.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset6", this.TextBox34.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset7", this.TextBox37.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset8", this.TextBox40.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset9", this.TextBox43.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F1S", this.TextBox20.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F2S", this.TextBox23.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F3S", this.TextBox26.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F4S", this.TextBox29.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F5S", this.TextBox32.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F6S", this.TextBox35.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F7S", this.TextBox38.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F8S", this.TextBox41.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F9S", this.TextBox44.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F1E", this.TextBox21.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F2E", this.TextBox24.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F3E", this.TextBox27.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F4E", this.TextBox30.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F5E", this.TextBox33.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F6E", this.TextBox36.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F7E", this.TextBox39.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F8E", this.TextBox42.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F9E", this.TextBox45.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF1", this.TextBox7.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF2", this.TextBox8.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF3", this.TextBox9.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF4", this.TextBox47.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF5", this.TextBox48.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF6", this.TextBox49.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF7", this.TextBox50.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF8", this.TextBox51.Text);
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF9", this.TextBox52.Text);
            }
        }

        private void Button44_Click(object sender, EventArgs e)
        {
            this.xview--;
            if (this.xview < -12)
            {
                this.xview = -12;
            }
        }

        private void Button45_Click(object sender, EventArgs e)
        {
            this.xview++;
            if (this.xview > 12)
            {
                this.xview = 12;
            }
        }

        private void Button46_Click(object sender, EventArgs e)
        {
            this.yview++;
            if (this.yview > 12)
            {
                this.yview = 12;
            }
        }

        private void Button47_Click(object sender, EventArgs e)
        {
            this.yview--;
            if (this.yview < -12)
            {
                this.yview = -12;
            }
        }

        private void Button48_Click(object sender, EventArgs e)
        {
            MyProject.Forms.Form4.ShowDialog();
            string[,] strArray = new string[0x11, 0x11];
            strArray[1, 1] = "0";
            strArray[2, 1] = "1";
            strArray[3, 1] = "2";
            strArray[4, 1] = "3";
            strArray[5, 1] = "4";
            strArray[6, 1] = "5";
            strArray[7, 1] = "6";
            strArray[8, 1] = "7";
            strArray[9, 1] = "8";
            strArray[10, 1] = "9";
            strArray[11, 1] = "A";
            strArray[12, 1] = "B";
            strArray[13, 1] = "C";
            strArray[14, 1] = "D";
            strArray[15, 1] = "E";
            strArray[0x10, 1] = "F";
            string text = this.TextBox62.Text;
            strArray[1, 1] = "0";
            strArray[2, 1] = "1";
            strArray[3, 1] = "2";
            strArray[4, 1] = "3";
            strArray[5, 1] = "4";
            strArray[6, 1] = "5";
            strArray[7, 1] = "6";
            strArray[8, 1] = "7";
            strArray[9, 1] = "8";
            strArray[10, 1] = "9";
            strArray[11, 1] = "A";
            strArray[12, 1] = "B";
            strArray[13, 1] = "C";
            strArray[14, 1] = "D";
            strArray[15, 1] = "E";
            strArray[0x10, 1] = "F";
            int num2 = 1;
            while (true)
            {
                int num = 1;
                while (true)
                {
                    strArray[num, num2 + 1] = strArray[num + 1, num2];
                    num++;
                    if (num > 15)
                    {
                        strArray[0x10, num2 + 1] = strArray[1, num2];
                        num2++;
                        if (num2 <= 15)
                        {
                            break;
                        }
                        string expression = text;
                        string str2 = "";
                        string str3 = "A785C899EE2DC3";
                        string str4 = "";
                        while (Strings.Len(str4) < Strings.Len(expression))
                        {
                            str4 = str4 + str3;
                        }
                        int num3 = Strings.Len(expression);
                        int start = 1;
                        while (start <= num3)
                        {
                            string str5 = Strings.Mid(expression, start, 1);
                            string str6 = Strings.Mid(str4, start, 1);
                            int num5 = 1;
                            while (true)
                            {
                                if (str5 == strArray[num5, 1])
                                {
                                    num = num5;
                                }
                                num5++;
                                if (num5 > 0x10)
                                {
                                    int num6 = 1;
                                    while (true)
                                    {
                                        if (str6 == strArray[1, num6])
                                        {
                                            num2 = num6;
                                        }
                                        num6++;
                                        if (num6 > 0x10)
                                        {
                                            str2 = str2 + strArray[num, num2];
                                            start++;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        Clipboard.SetText(this.TextBox62.Text, TextDataFormat.Text);
                        return;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void Button49_Click(object sender, EventArgs e)
        {
            if (((byte) Interaction.MsgBox("Are you sure you want to update the activation code?\r\nThe software will terminate after updating the activation code!", MsgBoxStyle.YesNo, null)) == 6)
            {
                string text = this.TextBox63.Text;
                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\SMA Simple Spectrum", "Activation Code", text);
                Interaction.MsgBox("The software will be terminated now!", MsgBoxStyle.Information, null);
                ProjectData.EndApp();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text = Conversion.Str(Conversion.Int((double) (Conversion.Val(this.TextBox2.Text) + 5.0)));
            if (Conversion.Val(this.TextBox2.Text) >= Conversion.Val(this.TextBox1.Text))
            {
                this.TextBox2.Text = Conversion.Str(Conversion.Val(this.TextBox1.Text) - 5.0);
            }
        }

        private void Button50_Click(object sender, EventArgs e)
        {
            this.Label11.Text = Strings.Trim(Conversion.Str(Conversion.Val(this.Label11.Text) - 1.0));
            if (Conversion.Val(this.Label11.Text) < -80.0)
            {
                this.Label11.Text = "-80";
            }
        }

        private void Button51_Click(object sender, EventArgs e)
        {
            this.Label11.Text = Strings.Trim(Conversion.Str(Conversion.Val(this.Label11.Text) + 1.0));
            if (Conversion.Val(this.Label11.Text) > 80.0)
            {
                this.Label11.Text = "80";
            }
        }

        private void Button52_Click(object sender, EventArgs e)
        {
            MyProject.Forms.Form5.ShowDialog();
        }

        private void Button53_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "*.png",
                Filter = "PNG Image File (.png)|*.png"
            };
            dialog.ShowDialog();
            this.rec_filename = dialog.FileName;
            if (dialog.FileName != "")
            {
                this.bmp1.Save(dialog.FileName, ImageFormat.Png);
            }
        }

        private void Button54_Click(object sender, EventArgs e)
        {
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "GPS Latitude", this.TextBox69.Text);
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "GPS Longitude", this.TextBox70.Text);
        }

        private void Button55_Click(object sender, EventArgs e)
        {
            new PrintForm(this).PrintPreview(true, PrintForm.PrintMode_ENUM.FitToPage, "PrintForm", null);
        }

        private void Button56_Click(object sender, EventArgs e)
        {
            new PrintForm(this).PrintPreview(true, PrintForm.PrintMode_ENUM.FitToPage, "PrintForm", null);
        }

        private void Button57_Click(object sender, EventArgs e)
        {
            this.WebBrowser1.ObjectForScripting = this;
            double[] numArray2 = new double[,] { { 42.13557, -0.40806 }, { 42.13684, -0.40884 }, { 42.13716, -0.40729 } };
            string[] textArray2 = new string[,] { { "42.13557", "-0.40806", "marker0" }, { "42.13684", "-0.40884", "marker1" }, { "42.13716", "-0.40729", "marker2" } };
            string[] textArray4 = new string[,] { { "42.13557", "-0.40806", "marker0", "red.png" }, { "42.13684", "-0.40884", "marker1", "red.png" }, { "42.13716", "-0.40729", "marker2", "green.png" } };
            string inputStr = "";
            int num = 0;
            OpenFileDialog dialog = new OpenFileDialog {
                FileName = ""
            };
            dialog.ShowDialog();
            string fileName = dialog.FileName;
            if (fileName != "")
            {
                this.Label73.Text = dialog.SafeFileName;
                StreamReader reader = new StreamReader(fileName);
                this.Label81.Text = reader.ReadLine() + " MHz";
                this.Label82.Text = reader.ReadLine();
                inputStr = reader.ReadLine();
                float num2 = 0x4e20f;
                float num3 = -20_000f;
                while (true)
                {
                    if (reader.EndOfStream)
                    {
                        reader.Close();
                        string[,] md = new string[(num - 1) + 1, 4];
                        int expression = 0;
                        float num6 = 0x100f / (num3 - num2);
                        StreamReader reader2 = new StreamReader(fileName);
                        this.ListBox1.Items.Clear();
                        this.ListBox1.Items.Add("N      Latitude      Longitude     Signal Power");
                        int num7 = 0;
                        this.Label81.Text = reader2.ReadLine() + " MHz";
                        this.Label82.Text = reader2.ReadLine();
                        inputStr = reader2.ReadLine();
                        int num8 = num - 1;
                        expression = 0;
                        while (true)
                        {
                            if (expression > num8)
                            {
                                WebBrowser wb = this.WebBrowser1;
                                this.WebBrowser1 = wb;
                                new GoogleMapHelper(ref wb, md).loadMap();
                                break;
                            }
                            float num5 = (float) Conversion.Val(Strings.Replace(reader2.ReadLine(), ",", ".", 1, -1, CompareMethod.Binary));
                            md[num7, 0] = reader2.ReadLine();
                            md[num7, 1] = reader2.ReadLine();
                            md[num7, 2] = Strings.Replace(Strings.Format(num5, "00.0"), ",", ".", 1, -1, CompareMethod.Binary) + " dBm";
                            reader2.ReadLine();
                            md[num7, 3] = Strings.Replace(Strings.Format((num5 - num2) * num6, "000"), ",", ".", 1, -1, CompareMethod.Binary) + ".png";
                            string[] textArray5 = new string[] { Strings.Replace(Strings.Format(expression, "000"), ",", ".", 1, -1, CompareMethod.Binary), "   ", md[num7, 0], "   ", md[num7, 1], "      ", Strings.Replace(Strings.Format(num5, "00.0"), ",", ".", 1, -1, CompareMethod.Binary), " dbm" };
                            this.ListBox1.Items.Add(string.Concat(textArray5));
                            if ((Conversion.Val(md[num7, 0]) != 0.0) & (Conversion.Val(md[num7, 1]) != 0.0))
                            {
                                num7++;
                            }
                            expression++;
                        }
                        break;
                    }
                    inputStr = reader.ReadLine();
                    if (Conversion.Val(inputStr) < num2)
                    {
                        num2 = (float) Conversion.Val(inputStr);
                    }
                    if (Conversion.Val(inputStr) > num3)
                    {
                        num3 = (float) Conversion.Val(inputStr);
                    }
                    inputStr = reader.ReadLine();
                    inputStr = reader.ReadLine();
                    inputStr = reader.ReadLine();
                    num++;
                }
            }
        }

        private void Button58_Click(object sender, EventArgs e)
        {
            if (this.log_marker1)
            {
                this.Button58.Text = "Start Log on Marker 1";
                this.log_marker1 = false;
            }
            else
            {
                this.Button58.Text = "Stop Log on Marker 1";
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.ShowDialog();
                this.LogFileToSaveAs = dialog.FileName;
                StreamWriter writer1 = new StreamWriter(this.LogFileToSaveAs, false);
                writer1.WriteLine(this.TextBox13.Text);
                writer1.WriteLine(DateTime.Now.ToString());
                writer1.WriteLine("---");
                writer1.Close();
                this.Timer2.Enabled = false;
                this.CheckBox4.Checked = false;
                Application.DoEvents();
                this.log_marker1 = true;
            }
        }

        private void Button59_Click(object sender, EventArgs e)
        {
            if (this.start)
            {
                Interaction.MsgBox("In order to write debug inforation, please stop live spectrum first!", MsgBoxStyle.Information, null);
            }
            else
            {
                StreamWriter writer = new StreamWriter("debug_file.txt");
                this.rm = new ResourceManagerClass();
                this.ioobj = new FormattedIO488Class();
                try
                {
                    this.ioobj.set_IO((IMessage) this.rm.Open(this.TextBox56.Text, 0, 0x7d0, ""));
                    this.ioobj.WriteString(this.TextBox6.Text + ";INITIATE:SPECtrum", true);
                    this.ioobj.WriteString(this.TextBox6.Text + ";READ:ARRAY:SPECTRUM:CURRENT?", true);
                    this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                    object[] idnItems = this.idnItems;
                    int index = 0;
                    while (true)
                    {
                        if (index >= idnItems.Length)
                        {
                            this.ioobj.WriteString(this.TextBox6.Text + ";*GTL", true);
                            break;
                        }
                        this.idnItem = idnItems[index];
                        writer.WriteLine(this.idnItem.ToString());
                        index++;
                    }
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    Interaction.MsgBox("An error occurred: " + exception.Message, MsgBoxStyle.Critical, null);
                    ProjectData.ClearProjectError();
                }
                finally
                {
                    try
                    {
                        this.ioobj.get_IO().Close();
                    }
                    catch (Exception exception5)
                    {
                        Exception ex = exception5;
                        ProjectData.SetProjectError(ex);
                        Exception exception2 = ex;
                        Interaction.MsgBox("An error occurred with 'ioobj.IO.Close()': " + exception2.Message, MsgBoxStyle.Critical, null);
                        ProjectData.ClearProjectError();
                    }
                    goto TR_0008;
                TR_0005:
                    try
                    {
                        Marshal.ReleaseComObject(this.rm);
                    }
                    catch (Exception exception7)
                    {
                        Exception ex = exception7;
                        ProjectData.SetProjectError(ex);
                        Exception exception4 = ex;
                        Interaction.MsgBox("An error occurred with 'ReleaseComObject(rm)': " + exception4.Message, MsgBoxStyle.Critical, null);
                        ProjectData.ClearProjectError();
                    }
                TR_0008:
                    try
                    {
                        Marshal.ReleaseComObject(this.ioobj);
                    }
                    catch (Exception exception6)
                    {
                        Exception ex = exception6;
                        ProjectData.SetProjectError(ex);
                        Exception exception3 = ex;
                        Interaction.MsgBox("An error occurred with 'ReleaseComObject(ioobj)': " + exception3.Message, MsgBoxStyle.Critical, null);
                        ProjectData.ClearProjectError();
                    }
                    goto TR_0005;
                }
                writer.Close();
                Interaction.MsgBox("Debug file has been written successfully!\r\nPlease check 'debug_file.txt' in executable folder!", MsgBoxStyle.Information, null);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text = Conversion.Str(Conversion.Int((double) (Conversion.Val(this.TextBox2.Text) - 5.0)));
            if (Conversion.Val(this.TextBox2.Text) < -200.0)
            {
                this.TextBox2.Text = Conversion.Str(-200);
            }
        }

        private void Button60_Click(object sender, EventArgs e)
        {
            string filename = "";
            OpenFileDialog dialog1 = new OpenFileDialog();
            dialog1.ShowDialog();
            filename = dialog1.FileName;
            if (filename != "")
            {
                this.PictureBox7.Image = Image.FromFile(filename);
                Bitmap image = (Bitmap) this.PictureBox7.Image;
                int index = 0;
                while (true)
                {
                    this.blue[index] = -1;
                    int y = 0;
                    while (true)
                    {
                        Color pixel = image.GetPixel(index, y);
                        if (pixel.ToString() == "Color [A=255, R=0, G=0, B=250]")
                        {
                            this.blue[index] = y;
                        }
                        y++;
                        if (y > 0x1f3)
                        {
                            this.red[index] = 0x1f5;
                            int num3 = 0x1f3;
                            while (true)
                            {
                                pixel = image.GetPixel(index, num3);
                                if (pixel.ToString() == "Color [A=255, R=250, G=0, B=0]")
                                {
                                    this.red[index] = num3;
                                }
                                num3 += -1;
                                if (num3 < 0)
                                {
                                    index++;
                                    if (index > 0x22f)
                                    {
                                        this.trigger_active = true;
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void Button61_Click(object sender, EventArgs e)
        {
            this.trigger_active = false;
            this.Label85.BackColor = Color.Green;
            this.Label85.Text = "STATUS: OK";
        }

        private void Button62_Click(object sender, EventArgs e)
        {
            this.ListBox2.Items.Clear();
        }

        private void Button63_Click(object sender, EventArgs e)
        {
            if (this.Button63.Text != "Open Trigger Mask Editor")
            {
                this.ListBox2.Visible = true;
                this.PictureBox8.Visible = false;
                this.Button64.Visible = false;
                this.Button65.Visible = false;
                this.Button66.Visible = false;
                this.Button63.Text = "Open Trigger Mask Editor";
            }
            else
            {
                this.ListBox2.Visible = false;
                this.bmp3 = (Bitmap) this.bmp1.Clone();
                this.grafico3 = Graphics.FromImage(this.bmp3);
                this.PictureBox8.Image = this.bmp3;
                this.PictureBox8.Visible = true;
                this.Button64.Visible = true;
                this.Button65.Visible = true;
                this.Button66.Visible = true;
                this.Button63.Text = "Close Trigger Mask Editor";
            }
        }

        private void Button64_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "*.png",
                Filter = "CRTU Spectrum File (.png)|*.png"
            };
            dialog.ShowDialog();
            this.rec_filename = dialog.FileName;
            string filename = this.rec_filename;
            if (filename != "")
            {
                this.bmp3.Save(filename, ImageFormat.Png);
            }
        }

        private void Button65_Click(object sender, EventArgs e)
        {
            this.bmp3 = (Bitmap) this.bmp1.Clone();
            this.grafico3 = Graphics.FromImage(this.bmp3);
            this.PictureBox8.Image = this.bmp3;
            this.mouse_y_down = -1;
            this.mouse_y_up = -1;
        }

        private void Button66_Click(object sender, EventArgs e)
        {
            this.PictureBox7.Image = this.PictureBox8.Image;
            Bitmap image = (Bitmap) this.PictureBox7.Image;
            int index = 0;
            while (true)
            {
                this.blue[index] = -1;
                int y = 0;
                while (true)
                {
                    Color pixel = image.GetPixel(index, y);
                    if (pixel.ToString() == "Color [A=255, R=0, G=0, B=250]")
                    {
                        this.blue[index] = y;
                    }
                    y++;
                    if (y > 0x1f3)
                    {
                        this.red[index] = 0x1f5;
                        int num3 = 0x1f3;
                        while (true)
                        {
                            pixel = image.GetPixel(index, num3);
                            if (pixel.ToString() == "Color [A=255, R=250, G=0, B=0]")
                            {
                                this.red[index] = num3;
                            }
                            num3 += -1;
                            if (num3 < 0)
                            {
                                index++;
                                if (index <= 0x22f)
                                {
                                    break;
                                }
                                this.trigger_active = true;
                                return;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void Button67_Click(object sender, EventArgs e)
        {
            // Invalid method body.
        }

        private void Button68_Click(object sender, EventArgs e)
        {
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Send To", this.TextBox71.Text);
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "SMTP Server", this.TextBox72.Text);
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Login", this.TextBox74.Text);
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Password", this.TextBox73.Text);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "VISA Address", this.TextBox56.Text);
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "VISA Secondary Address", this.TextBox6.Text);
        }

        private void Button70_Click(object sender, EventArgs e)
        {
            this.sensitivity++;
            if (this.sensitivity > 8)
            {
                this.sensitivity = 8;
            }
            this.Label95.Text = Strings.Trim(Conversion.Str(this.sensitivity));
        }

        private void Button71_Click(object sender, EventArgs e)
        {
            this.sensitivity--;
            if (this.sensitivity < 0)
            {
                this.sensitivity = 0;
            }
            this.Label95.Text = Strings.Trim(Conversion.Str(this.sensitivity));
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (!this.TG)
            {
                this.TG = true;
                this.Button8.Text = "ON";
            }
            else
            {
                this.TG = false;
                this.Button8.Text = "OFF";
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            this.TextBox3.Text = this.TextBox23.Text;
            this.TextBox4.Text = this.TextBox24.Text;
            this.marker1 = 0;
            this.marker2 = 0x22e;
            this.update_centre_frequency();
            this.update_span();
            this.reset_traces();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ComboBox3.Text == "- - - - -")
            {
                this.CheckBox4.Checked = false;
            }
            if (this.CheckBox4.Checked)
            {
                this.SerialPort1.PortName = this.ComboBox3.Text;
                this.SerialPort1.Open();
                this.Timer2.Enabled = true;
            }
            else
            {
                this.SerialPort1.Close();
                this.Timer2.Enabled = false;
                this.Label75.Text = "";
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "GPS Port", this.ComboBox3.Text);
        }

        private string convert_freq(string hz)
        {
            string str = "";
            if (Strings.InStr(hz, " ", CompareMethod.Binary) > 1)
            {
                str = Strings.Replace(Strings.Format(Conversion.Val(hz), "0.000000"), ",", ".", 1, -1, CompareMethod.Binary) + Strings.Mid(hz, Strings.InStr(hz, " ", CompareMethod.Binary));
            }
            if ((Strings.InStr(hz, " Hz", CompareMethod.Binary) > 1) & (Conversion.Val(hz) >= 0x3e8))
            {
                str = Strings.Replace(Strings.Format(Conversion.Val(hz) / 0x3e8, "0.000000"), ",", ".", 1, -1, CompareMethod.Binary) + " KHz";
            }
            if ((Strings.InStr(hz, " KHz", CompareMethod.Binary) > 1) & (Conversion.Val(hz) >= 0x3e8))
            {
                str = Strings.Replace(Strings.Format(Conversion.Val(hz) / 0x3e8, "0.000000"), ",", ".", 1, -1, CompareMethod.Binary) + " MHz";
            }
            return str;
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public void Draw_Spectrum()
        {
            // Invalid method body.
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.play = false;
            this.start = false;
            Application.DoEvents();
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void Form1_Load(object sender, EventArgs e)
        {
            string text;
            string[,] strArray;
            string str4;
            string str5;
            string str6;
            string str7;
            string str8;
            string str9;
            int num3;
            int num4;
            string str11;
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            int index = 0;
       //     goto TR_00A2;
        TR_0020:
            this.read_transponder_lists();
            this.grafico1 = Graphics.FromImage(this.bmp1);
            this.grafico2 = Graphics.FromImage(this.bmp2);
            this.PictureBox1.Image = this.bmp1;
            this.PictureBox2.Image = this.bmp2;
            byte blue = 0;
            int num20 = 0;
            while (true)
            {
                this.colormap[num20] = Color.FromArgb(0, 0, blue);
                blue = (byte) Math.Round((double) (blue + 5.1));
                num20++;
                if (num20 > 50)
                {
                    blue = 0;
                    int num21 = 0x33;
                    while (true)
                    {
                        this.colormap[num21] = Color.FromArgb(0, blue, 0xff);
                        blue = (byte) Math.Round((double) (blue + 5.1));
                        num21++;
                        if (num21 > 100)
                        {
                            blue = 0;
                            int num22 = 0x65;
                            while (true)
                            {
                                this.colormap[num22] = Color.FromArgb(blue, 0xff, 0xff - blue);
                                blue = (byte) Math.Round((double) (blue + 5.1));
                                num22++;
                                if (num22 > 150)
                                {
                                    blue = 0;
                                    int num23 = 0x97;
                                    while (true)
                                    {
                                        this.colormap[num23] = Color.FromArgb(0xff, 0xff - blue, 0);
                                        blue = (byte) Math.Round((double) (blue + 5.1));
                                        num23++;
                                        if (num23 > 200)
                                        {
                                            int num24 = 0xc9;
                                            while (true)
                                            {
                                                this.colormap[num24] = Color.FromArgb(0xff, (int) Math.Round((double) ((((double) (num24 - 0xc9)) / 0x36) * 0xff)), (int) Math.Round((double) ((((double) (num24 - 0xc9)) / 0x36) * 0xff)));
                                                num24++;
                                                if (num24 > 0xff)
                                                {
                                                    int num25 = 0;
                                                    while (true)
                                                    {
                                                        this.trace[num25, 2] = float.NegativeInfinity;
                                                        this.trace[num25, 3] = float.PositiveInfinity;
                                                        num25++;
                                                        if (num25 > 560)
                                                        {
                                                            string str3 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "GPS Port", null));
                                                            if (str3 != "")
                                                            {
                                                                this.ComboBox3.Text = str3;
                                                            }
                                                            this.TextBox69.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "GPS Latitude", null));
                                                            this.TextBox70.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "GPS Longitude", null));
                                                            if (this.TextBox69.Text == "")
                                                            {
                                                                this.TextBox69.Text = "000.000000";
                                                            }
                                                            if (this.TextBox70.Text == "")
                                                            {
                                                                this.TextBox70.Text = "000.000000";
                                                            }
                                                            this.TextBox71.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Send To", null));
                                                            this.TextBox72.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "SMTP Server", null));
                                                            this.TextBox74.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Login", null));
                                                            this.TextBox73.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Password", null));
                                                            this.TextBox56.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "VISA Address", null));
                                                            this.TextBox6.Text = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "VISA Secondary Address", null));
                                                            this.preset_buttons();
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            goto stop:
        TR_004D:
            index++;
        TR_00A2:
            while (true)
            {
                if (index < allNetworkInterfaces.Length)
                {
                    string str = allNetworkInterfaces[index].GetPhysicalAddress().ToString();
                    if (str == "")
                    {
                        goto TR_004D;
                    }
                    else
                    {
                        text = str;
                        strArray = new string[0x11, 0x11];
                        strArray[1, 1] = "0";
                        strArray[2, 1] = "1";
                        strArray[3, 1] = "2";
                        strArray[4, 1] = "3";
                        strArray[5, 1] = "4";
                        strArray[6, 1] = "5";
                        strArray[7, 1] = "6";
                        strArray[8, 1] = "7";
                        strArray[9, 1] = "8";
                        strArray[10, 1] = "9";
                        strArray[11, 1] = "A";
                        strArray[12, 1] = "B";
                        strArray[13, 1] = "C";
                        strArray[14, 1] = "D";
                        strArray[15, 1] = "E";
                        strArray[0x10, 1] = "F";
                        num4 = 1;
                        while (true)
                        {
                            num3 = 1;
                            while (true)
                            {
                                strArray[num3, num4 + 1] = strArray[num3 + 1, num4];
                                num3++;
                                if (num3 > 15)
                                {
                                    strArray[0x10, num4 + 1] = strArray[1, num4];
                                    num4++;
                                    if (num4 > 15)
                                    {
                                        str4 = text;
                                        str5 = "";
                                        str6 = "A785C899EE2DC3";
                                        str7 = "";
                                        while (true)
                                        {
                                            if (Strings.Len(str7) < Strings.Len(str4))
                                            {
                                                str7 = str7 + str6;
                                                continue;
                                            }
                                            int num5 = Strings.Len(str4);
                                            int start = 1;
                                            while (true)
                                            {
                                                if (start <= num5)
                                                {
                                                    str8 = Strings.Mid(str4, start, 1);
                                                    str9 = Strings.Mid(str7, start, 1);
                                                    int num7 = 1;
                                                    while (true)
                                                    {
                                                        if (str8 == strArray[num7, 1])
                                                        {
                                                            num3 = num7;
                                                        }
                                                        num7++;
                                                        if (num7 > 0x10)
                                                        {
                                                            int num8 = 1;
                                                            while (true)
                                                            {
                                                                if (str9 == strArray[1, num8])
                                                                {
                                                                    num4 = num8;
                                                                }
                                                                num8++;
                                                                if (num8 > 0x10)
                                                                {
                                                                    str5 = str5 + strArray[num3, num4];
                                                                    start++;
                                                                    break;
                                                                }
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    continue;
                                                }
                                                str11 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", null));
                                                if (str11 == "")
                                                {
                                                    MyProject.Forms.Form4.ShowDialog();
                                                    text = MyProject.Forms.Form4.ComboBox1.Text;
                                                    strArray[1, 1] = "0";
                                                    strArray[2, 1] = "1";
                                                    strArray[3, 1] = "2";
                                                    strArray[4, 1] = "3";
                                                    strArray[5, 1] = "4";
                                                    strArray[6, 1] = "5";
                                                    strArray[7, 1] = "6";
                                                    strArray[8, 1] = "7";
                                                    strArray[9, 1] = "8";
                                                    strArray[10, 1] = "9";
                                                    strArray[11, 1] = "A";
                                                    strArray[12, 1] = "B";
                                                    strArray[13, 1] = "C";
                                                    strArray[14, 1] = "D";
                                                    strArray[15, 1] = "E";
                                                    strArray[0x10, 1] = "F";
                                                    num4 = 1;
                                                    while (true)
                                                    {
                                                        num3 = 1;
                                                        while (true)
                                                        {
                                                            strArray[num3, num4 + 1] = strArray[num3 + 1, num4];
                                                            num3++;
                                                            if (num3 > 15)
                                                            {
                                                                strArray[0x10, num4 + 1] = strArray[1, num4];
                                                                num4++;
                                                                if (num4 > 15)
                                                                {
                                                                    str4 = text;
                                                                    str5 = "";
                                                                    str6 = "736ABC2312DEC9";
                                                                    str7 = "";
                                                                    while (true)
                                                                    {
                                                                        if (Strings.Len(str7) >= Strings.Len(str4))
                                                                        {
                                                                            int num9 = Strings.Len(str4);
                                                                            int num10 = 1;
                                                                            while (true)
                                                                            {
                                                                                if (num10 > num9)
                                                                                {
                                                                                    Clipboard.SetText(str5, TextDataFormat.Text);
                                                                                    str11 = Interaction.InputBox("Please enter the activation code for serial number: " + str5, "", "", -1, -1);
                                                                                    MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", str11);
                                                                                    Interaction.MsgBox("The software will be terminated now!", MsgBoxStyle.Information, null);
                                                                                    ProjectData.EndApp();
                                                                                    break;
                                                                                }
                                                                                str8 = Strings.Mid(str4, num10, 1);
                                                                                str9 = Strings.Mid(str7, num10, 1);
                                                                                int num11 = 1;
                                                                                while (true)
                                                                                {
                                                                                    if (str8 == strArray[num11, 1])
                                                                                    {
                                                                                        num3 = num11;
                                                                                    }
                                                                                    num11++;
                                                                                    if (num11 > 0x10)
                                                                                    {
                                                                                        int num12 = 1;
                                                                                        while (true)
                                                                                        {
                                                                                            if (str9 == strArray[1, num12])
                                                                                            {
                                                                                                num4 = num12;
                                                                                            }
                                                                                            num12++;
                                                                                            if (num12 > 0x10)
                                                                                            {
                                                                                                str5 = str5 + strArray[num3, num4];
                                                                                                num10++;
                                                                                                break;
                                                                                            }
                                                                                        }
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        }
                                                                        str7 = str7 + str6;
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Interaction.MsgBox("No authorized MAC address found. Do you want to erase existing license information?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                    {
                        MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", "");
                    }
                    ProjectData.EndApp();
                    goto TR_0020;
                }
                break;
            }
            this.TextBox63.Text = str11;
            string str10 = str5;
            str4 = "";
            str5 = str11;
            str6 = "B76C879E1A00FF";
            str7 = "";
            while (true)
            {
                if (Strings.Len(str7) < Strings.Len(str5))
                {
                    str7 = str7 + str6;
                    continue;
                }
                int num13 = Strings.Len(str5);
                int start = 1;
                while (true)
                {
                    if (start <= num13)
                    {
                        str8 = Strings.Mid(str5, start, 1);
                        str9 = Strings.Mid(str7, start, 1);
                        int num15 = 1;
                        while (true)
                        {
                            if (str9 == strArray[1, num15])
                            {
                                num4 = num15;
                            }
                            num15++;
                            if (num15 > 0x10)
                            {
                                int num16 = 1;
                                while (true)
                                {
                                    if (str8 == strArray[num16, num4])
                                    {
                                        num3 = num16;
                                    }
                                    num16++;
                                    if (num16 > 0x10)
                                    {
                                        str4 = str4 + strArray[num3, 1];
                                        start++;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        continue;
                    }
                    string str12 = Strings.Mid(str4, 1, 12);
                    string str13 = Strings.Mid(str4, 13, 4);
                    string str14 = Strings.Mid(str4, 0x11, 2);
                    if (str12 != text)
                    {
                        break;
                    }
                    byte number = 0;
                    number = (byte) Math.Round(Conversion.Val(Strings.Mid(str5, 1, 1)));
                    int num18 = Strings.Len(str5) - 2;
                    int num19 = 2;
                    while (true)
                    {
                        if (num19 > num18)
                        {
                            string expression = Conversion.Hex(number);
                            if (Strings.Len(expression) == 1)
                            {
                                expression = "0" + expression;
                            }
                            if (expression != Strings.Mid(str11, 0x13, 2))
                            {
                                Interaction.MsgBox("System code: " + str10 + "\r\nInvalid activation code. Contact vma@norcam.pt for further information!", MsgBoxStyle.Critical, null);
                                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", "");
                                ProjectData.EndApp();
                            }
                            if (str12 != text)
                            {
                                Interaction.MsgBox("System code: " + str10 + "\r\nInvalid activation code. Contact vma@norcam.pt for further information!", MsgBoxStyle.Critical, null);
                                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", "");
                                ProjectData.EndApp();
                            }
                            else if (DateTime.Today.Year > Conversions.ToDouble(str13))
                            {
                                Interaction.MsgBox("System code: " + str10 + "\r\nThe evaluation period expired. Contact vma@norcam.pt for further information!", MsgBoxStyle.Critical, null);
                                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", "");
                                ProjectData.EndApp();
                            }
                            else if ((DateTime.Today.Month > Conversions.ToDouble(str14)) & (DateTime.Today.Year >= Conversions.ToDouble(str13)))
                            {
                                Interaction.MsgBox("System code: " + str10 + "\r\nThe evaluation period expired. Contact vma@norcam.pt for further information!", MsgBoxStyle.Critical, null);
                                MyProject.Computer.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "Activation Code", "");
                                ProjectData.EndApp();
                            }
                            this.TextBox62.Text = str10;
                            string str16 = "";
                            if (str14 == "01")
                            {
                                str16 = "january";
                            }
                            if (str14 == "02")
                            {
                                str16 = "february";
                            }
                            if (str14 == "03")
                            {
                                str16 = "march";
                            }
                            if (str14 == "04")
                            {
                                str16 = "abril";
                            }
                            if (str14 == "05")
                            {
                                str16 = "may";
                            }
                            if (str14 == "06")
                            {
                                str16 = "june";
                            }
                            if (str14 == "07")
                            {
                                str16 = "july";
                            }
                            if (str14 == "08")
                            {
                                str16 = "august";
                            }
                            if (str14 == "09")
                            {
                                str16 = "september";
                            }
                            if (str14 == "10")
                            {
                                str16 = "october";
                            }
                            if (str14 == "11")
                            {
                                str16 = "november";
                            }
                            if (str14 == "12")
                            {
                                str16 = "december";
                            }
                            this.TextBox64.Text = str16 + " " + str13;
                            break;
                        }
                        number = (byte) (number ^ ((long) Math.Round(Conversion.Val(Strings.Mid(str5, num19, 1)))));
                        num19++;
                    }
                    goto TR_0020;
                }
                break;
            }
            goto TR_004D;
            stop:

        }

        public string getmac()
        {
            string message = "Error";
            string str2 = "";
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            int index = 0;
            while (true)
            {
                if (index < allNetworkInterfaces.Length)
                {
                    str2 = allNetworkInterfaces[index].GetPhysicalAddress().ToString();
                    if (str2 == "")
                    {
                        index++;
                        continue;
                    }
                    message = str2;
                    Debug.Print(message);
                }
                return message;
            }
        }

        private string HzToMHz(string hz) => 
            (Conversion.Val(hz) <= 0xf_4240) ? ((Conversion.Val(hz) <= 0x3e8) ? (Strings.Replace(Strings.Format(Conversion.Val(hz), "0.000000"), ",", ".", 1, -1, CompareMethod.Binary) + " Hz") : (Strings.Replace(Strings.Format(Conversion.Val(hz) / 0x3e8, "0.000000"), ",", ".", 1, -1, CompareMethod.Binary) + " KHz")) : (Strings.Replace(Strings.Format(Conversion.Val(hz) / 0xf_4240, "0.000000"), ",", ".", 1, -1, CompareMethod.Binary) + " MHz");

        private string HzToMHzGrid(string hz) => 
            (Conversion.Val(hz) <= 0xf_4240) ? ((Conversion.Val(hz) <= 0x3e8) ? (Strings.Replace(Strings.Format(Conversion.Val(hz), "0"), ",", ".", 1, -1, CompareMethod.Binary) + " Hz") : (Strings.Replace(Strings.Format(Conversion.Val(hz) / 0x3e8, "0.0"), ",", ".", 1, -1, CompareMethod.Binary) + " KHz")) : (Strings.Replace(Strings.Format(Conversion.Val(hz) / 0xf_4240, "0.0"), ",", ".", 1, -1, CompareMethod.Binary) + " MHz");

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Form1));
            this.PictureBox1 = new PictureBox();
            this.PictureBox2 = new PictureBox();
            this.TextBox1 = new TextBox();
            this.TextBox2 = new TextBox();
            this.Button3 = new Button();
            this.Label3 = new Label();
            this.TextBox5 = new TextBox();
            this.CheckBox1 = new CheckBox();
            this.TabControl1 = new TabControl();
            this.TabPage1 = new TabPage();
            this.GroupBox4 = new GroupBox();
            this.Button52 = new Button();
            this.Button8 = new Button();
            this.RadioButton6 = new RadioButton();
            this.RadioButton5 = new RadioButton();
            this.RadioButton4 = new RadioButton();
            this.GroupBox2 = new GroupBox();
            this.RadioButton3 = new RadioButton();
            this.RadioButton2 = new RadioButton();
            this.RadioButton1 = new RadioButton();
            this.Button55 = new Button();
            this.Button53 = new Button();
            this.Button42 = new Button();
            this.GroupBox11 = new GroupBox();
            this.Label79 = new Label();
            this.Label80 = new Label();
            this.Label72 = new Label();
            this.Label71 = new Label();
            this.Button58 = new Button();
            this.Label32 = new Label();
            this.Label31 = new Label();
            this.Label30 = new Label();
            this.HScrollBar1 = new HScrollBar();
            this.Button37 = new Button();
            this.Button36 = new Button();
            this.GroupBox10 = new GroupBox();
            this.TabControl2 = new TabControl();
            this.TabPage4 = new TabPage();
            this.Label69 = new Label();
            this.Label68 = new Label();
            this.Label67 = new Label();
            this.Label66 = new Label();
            this.Label65 = new Label();
            this.Label64 = new Label();
            this.TextBox67 = new TextBox();
            this.TextBox66 = new TextBox();
            this.TextBox65 = new TextBox();
            this.CheckBox3 = new CheckBox();
            this.TabPage5 = new TabPage();
            this.CheckBox8 = new CheckBox();
            this.Label103 = new Label();
            this.TextBox82 = new TextBox();
            this.TextBox81 = new TextBox();
            this.TextBox80 = new TextBox();
            this.TextBox79 = new TextBox();
            this.CheckBox11 = new CheckBox();
            this.CheckBox10 = new CheckBox();
            this.CheckBox9 = new CheckBox();
            this.TabPage6 = new TabPage();
            this.Label85 = new Label();
            this.Button61 = new Button();
            this.Button60 = new Button();
            this.TabPage7 = new TabPage();
            this.CheckBox12 = new CheckBox();
            this.CheckBox2 = new CheckBox();
            this.Label11 = new Label();
            this.Button50 = new Button();
            this.Button51 = new Button();
            this.Label95 = new Label();
            this.Button71 = new Button();
            this.Button70 = new Button();
            this.Label94 = new Label();
            this.CheckBox7 = new CheckBox();
            this.Button69 = new Button();
            this.Label92 = new Label();
            this.Label93 = new Label();
            this.TextBox76 = new TextBox();
            this.Label90 = new Label();
            this.CheckBox6 = new CheckBox();
            this.GroupBox8 = new GroupBox();
            this.Button33 = new Button();
            this.Button34 = new Button();
            this.Button35 = new Button();
            this.GroupBox7 = new GroupBox();
            this.Button47 = new Button();
            this.Button46 = new Button();
            this.Button45 = new Button();
            this.Button44 = new Button();
            this.Button41 = new Button();
            this.Button40 = new Button();
            this.Label29 = new Label();
            this.TextBox46 = new TextBox();
            this.Button32 = new Button();
            this.Button31 = new Button();
            this.Button30 = new Button();
            this.Button29 = new Button();
            this.Button28 = new Button();
            this.Button27 = new Button();
            this.Button26 = new Button();
            this.Button25 = new Button();
            this.Button24 = new Button();
            this.Button23 = new Button();
            this.Button22 = new Button();
            this.Button21 = new Button();
            this.Button20 = new Button();
            this.Button19 = new Button();
            this.Button18 = new Button();
            this.GroupBox6 = new GroupBox();
            this.Label56 = new Label();
            this.TextBox57 = new TextBox();
            this.Label8 = new Label();
            this.TextBox55 = new TextBox();
            this.TextBox17 = new TextBox();
            this.Label16 = new Label();
            this.TextBox18 = new TextBox();
            this.TextBox16 = new TextBox();
            this.TextBox15 = new TextBox();
            this.Label14 = new Label();
            this.TextBox13 = new TextBox();
            this.Label15 = new Label();
            this.TextBox14 = new TextBox();
            this.GroupBox5 = new GroupBox();
            this.Button17 = new Button();
            this.Button16 = new Button();
            this.Button15 = new Button();
            this.Button14 = new Button();
            this.Button13 = new Button();
            this.Button12 = new Button();
            this.Button11 = new Button();
            this.Button10 = new Button();
            this.Button9 = new Button();
            this.Button1 = new Button();
            this.Label5 = new Label();
            this.Button6 = new Button();
            this.Button5 = new Button();
            this.Button4 = new Button();
            this.Button2 = new Button();
            this.GroupBox1 = new GroupBox();
            this.Button39 = new Button();
            this.Button38 = new Button();
            this.Label13 = new Label();
            this.TextBox12 = new TextBox();
            this.Label6 = new Label();
            this.TextBox11 = new TextBox();
            this.Label2 = new Label();
            this.Label1 = new Label();
            this.TextBox4 = new TextBox();
            this.TextBox3 = new TextBox();
            this.TabPage8 = new TabPage();
            this.Button66 = new Button();
            this.Button65 = new Button();
            this.Button64 = new Button();
            this.Button63 = new Button();
            this.Button62 = new Button();
            this.PictureBox7 = new PictureBox();
            this.PictureBox8 = new PictureBox();
            this.ListBox2 = new ListBox();
            this.TabPage9 = new TabPage();
            this.Button56 = new Button();
            this.Label84 = new Label();
            this.Label83 = new Label();
            this.Label82 = new Label();
            this.Label81 = new Label();
            this.Label74 = new Label();
            this.Label73 = new Label();
            this.ListBox1 = new ListBox();
            this.Button57 = new Button();
            this.WebBrowser1 = new WebBrowser();
            this.PictureBox5 = new PictureBox();
            this.TabPage2 = new TabPage();
            this.GroupBox13 = new GroupBox();
            this.Button59 = new Button();
            this.Button7 = new Button();
            this.Label9 = new Label();
            this.TextBox6 = new TextBox();
            this.Label4 = new Label();
            this.TextBox56 = new TextBox();
            this.GroupBox18 = new GroupBox();
            this.Button68 = new Button();
            this.Label89 = new Label();
            this.TextBox74 = new TextBox();
            this.CheckBox5 = new CheckBox();
            this.Label88 = new Label();
            this.TextBox73 = new TextBox();
            this.Label87 = new Label();
            this.TextBox72 = new TextBox();
            this.Label86 = new Label();
            this.TextBox71 = new TextBox();
            this.Button67 = new Button();
            this.GroupBox14 = new GroupBox();
            this.Button54 = new Button();
            this.Label78 = new Label();
            this.Label75 = new Label();
            this.GroupBox15 = new GroupBox();
            this.TextBox70 = new TextBox();
            this.Label77 = new Label();
            this.TextBox69 = new TextBox();
            this.Label76 = new Label();
            this.CheckBox4 = new CheckBox();
            this.ComboBox3 = new ComboBox();
            this.GroupBox19 = new GroupBox();
            this.Button72 = new Button();
            this.TextBox77 = new TextBox();
            this.TextBox78 = new TextBox();
            this.Label96 = new Label();
            this.Label97 = new Label();
            this.GroupBox12 = new GroupBox();
            this.PictureBox6 = new PictureBox();
            this.TextBox68 = new TextBox();
            this.GroupBox3 = new GroupBox();
            this.Label63 = new Label();
            this.Button48 = new Button();
            this.Button49 = new Button();
            this.TextBox64 = new TextBox();
            this.TextBox63 = new TextBox();
            this.TextBox62 = new TextBox();
            this.Label62 = new Label();
            this.Label61 = new Label();
            this.Label60 = new Label();
            this.GroupBox9 = new GroupBox();
            this.Label7 = new Label();
            this.TextBox52 = new TextBox();
            this.TextBox8 = new TextBox();
            this.TextBox51 = new TextBox();
            this.TextBox9 = new TextBox();
            this.TextBox50 = new TextBox();
            this.TextBox47 = new TextBox();
            this.TextBox49 = new TextBox();
            this.TextBox48 = new TextBox();
            this.TextBox7 = new TextBox();
            this.Button43 = new Button();
            this.Label26 = new Label();
            this.TextBox45 = new TextBox();
            this.Label17 = new Label();
            this.Label18 = new Label();
            this.TextBox44 = new TextBox();
            this.Label19 = new Label();
            this.TextBox43 = new TextBox();
            this.Label20 = new Label();
            this.TextBox42 = new TextBox();
            this.Label21 = new Label();
            this.TextBox41 = new TextBox();
            this.Label22 = new Label();
            this.TextBox40 = new TextBox();
            this.Label23 = new Label();
            this.TextBox39 = new TextBox();
            this.Label24 = new Label();
            this.TextBox38 = new TextBox();
            this.Label25 = new Label();
            this.TextBox37 = new TextBox();
            this.TextBox36 = new TextBox();
            this.TextBox35 = new TextBox();
            this.TextBox34 = new TextBox();
            this.TextBox33 = new TextBox();
            this.TextBox32 = new TextBox();
            this.TextBox31 = new TextBox();
            this.TextBox30 = new TextBox();
            this.TextBox29 = new TextBox();
            this.TextBox28 = new TextBox();
            this.TextBox27 = new TextBox();
            this.TextBox26 = new TextBox();
            this.TextBox25 = new TextBox();
            this.TextBox24 = new TextBox();
            this.TextBox23 = new TextBox();
            this.TextBox22 = new TextBox();
            this.TextBox21 = new TextBox();
            this.TextBox20 = new TextBox();
            this.TextBox19 = new TextBox();
            this.Label28 = new Label();
            this.Label27 = new Label();
            this.TabPage3 = new TabPage();
            this.TextBox53 = new TextBox();
            this.TextBox54 = new TextBox();
            this.Timer1 = new Timer(this.components);
            this.Timer2 = new Timer(this.components);
            this.Timer5 = new Timer(this.components);
            this.SerialPort2 = new SerialPort(this.components);
            this.SerialPort1 = new SerialPort(this.components);
            ((ISupportInitialize) this.PictureBox1).BeginInit();
            ((ISupportInitialize) this.PictureBox2).BeginInit();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox11.SuspendLayout();
            this.GroupBox10.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.TabPage6.SuspendLayout();
            this.TabPage7.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabPage8.SuspendLayout();
            ((ISupportInitialize) this.PictureBox7).BeginInit();
            ((ISupportInitialize) this.PictureBox8).BeginInit();
            this.TabPage9.SuspendLayout();
            ((ISupportInitialize) this.PictureBox5).BeginInit();
            this.TabPage2.SuspendLayout();
            this.GroupBox13.SuspendLayout();
            this.GroupBox18.SuspendLayout();
            this.GroupBox14.SuspendLayout();
            this.GroupBox15.SuspendLayout();
            this.GroupBox19.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            ((ISupportInitialize) this.PictureBox6).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.TabPage3.SuspendLayout();
            base.SuspendLayout();
            this.PictureBox1.BackColor = Color.Black;
            this.PictureBox1.Location = new Point(0x48, 6);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new Size(0x231, 500);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.PictureBox2.BackColor = Color.Black;
            this.PictureBox2.Location = new Point(0x48, 0x200);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new Size(0x231, 100);
            this.PictureBox2.TabIndex = 2;
            this.PictureBox2.TabStop = false;
            this.TextBox1.BackColor = Color.PeachPuff;
            this.TextBox1.Location = new Point(6, 0x23);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new Size(60, 20);
            this.TextBox1.TabIndex = 3;
            this.TextBox1.Text = "5 dBm";
            this.TextBox1.TextAlign = HorizontalAlignment.Right;
            this.TextBox2.BackColor = Color.PeachPuff;
            this.TextBox2.Location = new Point(6, 0x1c9);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new Size(60, 20);
            this.TextBox2.TabIndex = 4;
            this.TextBox2.Text = "-100 dBm";
            this.TextBox2.TextAlign = HorizontalAlignment.Right;
            this.Button3.Location = new Point(6, 0xe0);
            this.Button3.Name = "Button3";
            this.Button3.Size = new Size(60, 0x38);
            this.Button3.TabIndex = 10;
            this.Button3.Text = "AUTO";
            this.Button3.UseVisualStyleBackColor = true;
            this.Label3.AutoSize = true;
            this.Label3.Location = new Point(0x49, 0x7e);
            this.Label3.Name = "Label3";
            this.Label3.Size = new Size(0x21, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "RBW";
            this.TextBox5.BackColor = Color.LightBlue;
            this.TextBox5.Location = new Point(0x71, 0x7b);
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.ReadOnly = true;
            this.TextBox5.Size = new Size(0x62, 20);
            this.TextBox5.TabIndex = 11;
            this.TextBox5.Text = "1 MHz";
            this.TextBox5.TextAlign = HorizontalAlignment.Right;
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new Point(0x171, 0x29);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new Size(0x6f, 0x11);
            this.CheckBox1.TabIndex = 0x10;
            this.CheckBox1.Text = "Shaded Spectrum";
            this.CheckBox1.UseVisualStyleBackColor = true;
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage8);
            this.TabControl1.Controls.Add(this.TabPage9);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Location = new Point(1, 1);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new Size(0x451, 0x2e5);
            this.TabControl1.TabIndex = 0x15;
            this.TabPage1.Controls.Add(this.GroupBox4);
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Controls.Add(this.Button55);
            this.TabPage1.Controls.Add(this.Button53);
            this.TabPage1.Controls.Add(this.Button42);
            this.TabPage1.Controls.Add(this.GroupBox11);
            this.TabPage1.Controls.Add(this.GroupBox10);
            this.TabPage1.Controls.Add(this.GroupBox8);
            this.TabPage1.Controls.Add(this.GroupBox7);
            this.TabPage1.Controls.Add(this.GroupBox6);
            this.TabPage1.Controls.Add(this.GroupBox5);
            this.TabPage1.Controls.Add(this.Label5);
            this.TabPage1.Controls.Add(this.Button6);
            this.TabPage1.Controls.Add(this.Button5);
            this.TabPage1.Controls.Add(this.Button4);
            this.TabPage1.Controls.Add(this.Button2);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.PictureBox1);
            this.TabPage1.Controls.Add(this.Button3);
            this.TabPage1.Controls.Add(this.PictureBox2);
            this.TabPage1.Controls.Add(this.TextBox2);
            this.TabPage1.Controls.Add(this.TextBox1);
            this.TabPage1.Location = new Point(4, 0x16);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new Padding(3);
            this.TabPage1.Size = new Size(0x449, 0x2cb);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Spectrum";
            this.TabPage1.UseVisualStyleBackColor = true;
            this.GroupBox4.Controls.Add(this.Button52);
            this.GroupBox4.Controls.Add(this.Button8);
            this.GroupBox4.Controls.Add(this.RadioButton6);
            this.GroupBox4.Controls.Add(this.RadioButton5);
            this.GroupBox4.Controls.Add(this.RadioButton4);
            this.GroupBox4.Location = new Point(0x364, 0x98);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new Size(0x68, 0x53);
            this.GroupBox4.TabIndex = 0x25;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "TG";
            this.Button52.Location = new Point(60, 0x17);
            this.Button52.Name = "Button52";
            this.Button52.Size = new Size(0x26, 0x17);
            this.Button52.TabIndex = 4;
            this.Button52.Text = "CFG";
            this.Button52.UseVisualStyleBackColor = true;
            this.Button52.Visible = false;
            this.Button8.Location = new Point(60, 0x34);
            this.Button8.Name = "Button8";
            this.Button8.Size = new Size(0x26, 0x17);
            this.Button8.TabIndex = 3;
            this.Button8.Text = "OFF";
            this.Button8.UseVisualStyleBackColor = true;
            this.RadioButton6.AutoSize = true;
            this.RadioButton6.Location = new Point(15, 50);
            this.RadioButton6.Name = "RadioButton6";
            this.RadioButton6.Size = new Size(0x2d, 0x11);
            this.RadioButton6.TabIndex = 2;
            this.RadioButton6.TabStop = true;
            this.RadioButton6.Text = "RF3";
            this.RadioButton6.UseVisualStyleBackColor = true;
            this.RadioButton5.AutoSize = true;
            this.RadioButton5.Location = new Point(15, 0x23);
            this.RadioButton5.Name = "RadioButton5";
            this.RadioButton5.Size = new Size(0x2d, 0x11);
            this.RadioButton5.TabIndex = 1;
            this.RadioButton5.TabStop = true;
            this.RadioButton5.Text = "RF2";
            this.RadioButton5.UseVisualStyleBackColor = true;
            this.RadioButton4.AutoSize = true;
            this.RadioButton4.Location = new Point(15, 20);
            this.RadioButton4.Name = "RadioButton4";
            this.RadioButton4.Size = new Size(0x2d, 0x11);
            this.RadioButton4.TabIndex = 0;
            this.RadioButton4.TabStop = true;
            this.RadioButton4.Text = "RF1";
            this.RadioButton4.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add(this.RadioButton3);
            this.GroupBox2.Controls.Add(this.RadioButton2);
            this.GroupBox2.Controls.Add(this.RadioButton1);
            this.GroupBox2.Location = new Point(0x364, 0x3d);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new Size(0x68, 0x53);
            this.GroupBox2.TabIndex = 0x24;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "RF Input";
            this.RadioButton3.AutoSize = true;
            this.RadioButton3.Location = new Point(15, 50);
            this.RadioButton3.Name = "RadioButton3";
            this.RadioButton3.Size = new Size(0x2d, 0x11);
            this.RadioButton3.TabIndex = 2;
            this.RadioButton3.TabStop = true;
            this.RadioButton3.Text = "RF4";
            this.RadioButton3.UseVisualStyleBackColor = true;
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new Point(15, 0x23);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new Size(0x2d, 0x11);
            this.RadioButton2.TabIndex = 1;
            this.RadioButton2.TabStop = true;
            this.RadioButton2.Text = "RF2";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Location = new Point(15, 20);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new Size(0x2d, 0x11);
            this.RadioButton1.TabIndex = 0;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "RF1";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.Button55.Location = new Point(0x327, 6);
            this.Button55.Name = "Button55";
            this.Button55.Size = new Size(0x4e, 0x1d);
            this.Button55.TabIndex = 0x23;
            this.Button55.Text = "PRINT";
            this.Button55.UseVisualStyleBackColor = true;
            this.Button53.Location = new Point(0x2d3, 6);
            this.Button53.Name = "Button53";
            this.Button53.Size = new Size(0x4e, 0x1d);
            this.Button53.TabIndex = 0x22;
            this.Button53.Text = "SAVE PIC";
            this.Button53.UseVisualStyleBackColor = true;
            this.Button42.Location = new Point(0x27f, 6);
            this.Button42.Name = "Button42";
            this.Button42.Size = new Size(0x4e, 0x1d);
            this.Button42.TabIndex = 0x16;
            this.Button42.Text = "START";
            this.Button42.UseVisualStyleBackColor = true;
            this.GroupBox11.Controls.Add(this.Label79);
            this.GroupBox11.Controls.Add(this.Label80);
            this.GroupBox11.Controls.Add(this.Label72);
            this.GroupBox11.Controls.Add(this.Label71);
            this.GroupBox11.Controls.Add(this.Button58);
            this.GroupBox11.Controls.Add(this.Label32);
            this.GroupBox11.Controls.Add(this.Label31);
            this.GroupBox11.Controls.Add(this.Label30);
            this.GroupBox11.Controls.Add(this.HScrollBar1);
            this.GroupBox11.Controls.Add(this.Button37);
            this.GroupBox11.Controls.Add(this.Button36);
            this.GroupBox11.Location = new Point(0x27f, 0x26a);
            this.GroupBox11.Name = "GroupBox11";
            this.GroupBox11.Size = new Size(0x1c3, 0x58);
            this.GroupBox11.TabIndex = 0x20;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "Logger";
            this.Label79.BackColor = Color.Black;
            this.Label79.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label79.ForeColor = Color.Lime;
            this.Label79.Location = new Point(0x10f, 0x25);
            this.Label79.Name = "Label79";
            this.Label79.Size = new Size(0x4f, 0x12);
            this.Label79.TabIndex = 30;
            this.Label79.Text = "Longitude";
            this.Label79.TextAlign = ContentAlignment.MiddleRight;
            this.Label80.BackColor = Color.Black;
            this.Label80.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label80.ForeColor = Color.Lime;
            this.Label80.Location = new Point(0x10f, 0x13);
            this.Label80.Name = "Label80";
            this.Label80.Size = new Size(0x4f, 0x12);
            this.Label80.TabIndex = 0x1d;
            this.Label80.Text = "Latitude";
            this.Label80.TextAlign = ContentAlignment.MiddleRight;
            this.Label72.BackColor = Color.Black;
            this.Label72.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label72.ForeColor = Color.Lime;
            this.Label72.Location = new Point(0x158, 0x25);
            this.Label72.Name = "Label72";
            this.Label72.Size = new Size(0x55, 0x12);
            this.Label72.TabIndex = 0x1c;
            this.Label72.Text = "---";
            this.Label72.TextAlign = ContentAlignment.MiddleRight;
            this.Label71.BackColor = Color.Black;
            this.Label71.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label71.ForeColor = Color.Lime;
            this.Label71.Location = new Point(0x158, 0x13);
            this.Label71.Name = "Label71";
            this.Label71.Size = new Size(0x55, 0x12);
            this.Label71.TabIndex = 0x1b;
            this.Label71.Text = "---";
            this.Label71.TextAlign = ContentAlignment.MiddleRight;
            this.Button58.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button58.Location = new Point(0x76, 0x13);
            this.Button58.Name = "Button58";
            this.Button58.Size = new Size(0x84, 20);
            this.Button58.TabIndex = 0x1a;
            this.Button58.Text = "Start Log on Marker 1";
            this.Button58.UseVisualStyleBackColor = true;
            this.Label32.AutoSize = true;
            this.Label32.Location = new Point(0xd8, 0x42);
            this.Label32.Name = "Label32";
            this.Label32.Size = new Size(0x22, 13);
            this.Label32.TabIndex = 0x19;
            this.Label32.Text = "FAST";
            this.Label31.AutoSize = true;
            this.Label31.Location = new Point(11, 0x42);
            this.Label31.Name = "Label31";
            this.Label31.Size = new Size(0x27, 13);
            this.Label31.TabIndex = 0x18;
            this.Label31.Text = "SLOW";
            this.Label30.AutoSize = true;
            this.Label30.Location = new Point(11, 0x2d);
            this.Label30.Name = "Label30";
            this.Label30.Size = new Size(0x55, 13);
            this.Label30.TabIndex = 0x17;
            this.Label30.Text = "Playback Speed";
            this.HScrollBar1.Location = new Point(0x35, 0x41);
            this.HScrollBar1.Minimum = 1;
            this.HScrollBar1.Name = "HScrollBar1";
            this.HScrollBar1.Size = new Size(160, 0x10);
            this.HScrollBar1.TabIndex = 0x16;
            this.HScrollBar1.Value = 50;
            this.Button37.Location = new Point(0x3e, 0x13);
            this.Button37.Name = "Button37";
            this.Button37.Size = new Size(50, 20);
            this.Button37.TabIndex = 20;
            this.Button37.Text = "PLAY";
            this.Button37.UseVisualStyleBackColor = true;
            this.Button36.Location = new Point(6, 0x13);
            this.Button36.Name = "Button36";
            this.Button36.Size = new Size(50, 20);
            this.Button36.TabIndex = 0x13;
            this.Button36.Text = "REC";
            this.Button36.UseVisualStyleBackColor = true;
            this.GroupBox10.Controls.Add(this.TabControl2);
            this.GroupBox10.Location = new Point(0x27f, 0x17f);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new Size(0x1c3, 0xe5);
            this.GroupBox10.TabIndex = 0x1f;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Measurements";
            this.TabControl2.Controls.Add(this.TabPage4);
            this.TabControl2.Controls.Add(this.TabPage5);
            this.TabControl2.Controls.Add(this.TabPage6);
            this.TabControl2.Controls.Add(this.TabPage7);
            this.TabControl2.Location = new Point(6, 15);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new Size(0x1b7, 0xd0);
            this.TabControl2.TabIndex = 0;
            this.TabPage4.Controls.Add(this.Label69);
            this.TabPage4.Controls.Add(this.Label68);
            this.TabPage4.Controls.Add(this.Label67);
            this.TabPage4.Controls.Add(this.Label66);
            this.TabPage4.Controls.Add(this.Label65);
            this.TabPage4.Controls.Add(this.Label64);
            this.TabPage4.Controls.Add(this.TextBox67);
            this.TabPage4.Controls.Add(this.TextBox66);
            this.TabPage4.Controls.Add(this.TextBox65);
            this.TabPage4.Controls.Add(this.CheckBox3);
            this.TabPage4.Location = new Point(4, 0x16);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new Padding(3);
            this.TabPage4.Size = new Size(0x1af, 0xb6);
            this.TabPage4.TabIndex = 0;
            this.TabPage4.Text = "MIN/MAX/AVG";
            this.TabPage4.UseVisualStyleBackColor = true;
            this.Label69.AutoSize = true;
            this.Label69.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.Label69.Location = new Point(0x10, 0x49);
            this.Label69.Name = "Label69";
            this.Label69.Size = new Size(0x1d, 13);
            this.Label69.TabIndex = 0x48;
            this.Label69.Text = "AVG";
            this.Label69.TextAlign = ContentAlignment.MiddleRight;
            this.Label68.AutoSize = true;
            this.Label68.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.Label68.Location = new Point(15, 50);
            this.Label68.Name = "Label68";
            this.Label68.Size = new Size(30, 13);
            this.Label68.TabIndex = 0x47;
            this.Label68.Text = "MAX";
            this.Label68.TextAlign = ContentAlignment.MiddleRight;
            this.Label67.AutoSize = true;
            this.Label67.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.Label67.Location = new Point(0x12, 0x19);
            this.Label67.Name = "Label67";
            this.Label67.Size = new Size(0x1b, 13);
            this.Label67.TabIndex = 0x3f;
            this.Label67.Text = "MIN";
            this.Label67.TextAlign = ContentAlignment.MiddleRight;
            this.Label66.AutoSize = true;
            this.Label66.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label66.Location = new Point(0x91, 0x48);
            this.Label66.Name = "Label66";
            this.Label66.Size = new Size(0x1c, 13);
            this.Label66.TabIndex = 70;
            this.Label66.Text = "dBm";
            this.Label66.TextAlign = ContentAlignment.MiddleLeft;
            this.Label65.AutoSize = true;
            this.Label65.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label65.Location = new Point(0x91, 0x31);
            this.Label65.Name = "Label65";
            this.Label65.Size = new Size(0x1c, 13);
            this.Label65.TabIndex = 0x45;
            this.Label65.Text = "dBm";
            this.Label65.TextAlign = ContentAlignment.MiddleLeft;
            this.Label64.AutoSize = true;
            this.Label64.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label64.Location = new Point(0x91, 0x19);
            this.Label64.Name = "Label64";
            this.Label64.Size = new Size(0x1c, 13);
            this.Label64.TabIndex = 0x44;
            this.Label64.Text = "dBm";
            this.Label64.TextAlign = ContentAlignment.MiddleLeft;
            this.TextBox67.BackColor = Color.PeachPuff;
            this.TextBox67.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox67.Location = new Point(0x33, 70);
            this.TextBox67.Name = "TextBox67";
            this.TextBox67.ReadOnly = true;
            this.TextBox67.Size = new Size(0x58, 20);
            this.TextBox67.TabIndex = 0x43;
            this.TextBox67.TextAlign = HorizontalAlignment.Right;
            this.TextBox66.BackColor = Color.PeachPuff;
            this.TextBox66.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox66.Location = new Point(0x33, 0x2e);
            this.TextBox66.Name = "TextBox66";
            this.TextBox66.ReadOnly = true;
            this.TextBox66.Size = new Size(0x58, 20);
            this.TextBox66.TabIndex = 0x42;
            this.TextBox66.TextAlign = HorizontalAlignment.Right;
            this.TextBox65.BackColor = Color.PeachPuff;
            this.TextBox65.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox65.Location = new Point(0x33, 0x16);
            this.TextBox65.Name = "TextBox65";
            this.TextBox65.ReadOnly = true;
            this.TextBox65.Size = new Size(0x58, 20);
            this.TextBox65.TabIndex = 0x41;
            this.TextBox65.TextAlign = HorizontalAlignment.Right;
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.Location = new Point(0x12, 0x95);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new Size(0x9b, 0x11);
            this.CheckBox3.TabIndex = 0x40;
            this.CheckBox3.Text = "Show MIN/MAX/AVG lines";
            this.CheckBox3.UseVisualStyleBackColor = true;
            this.TabPage5.Controls.Add(this.CheckBox8);
            this.TabPage5.Controls.Add(this.Label103);
            this.TabPage5.Controls.Add(this.TextBox82);
            this.TabPage5.Controls.Add(this.TextBox81);
            this.TabPage5.Controls.Add(this.TextBox80);
            this.TabPage5.Controls.Add(this.TextBox79);
            this.TabPage5.Controls.Add(this.CheckBox11);
            this.TabPage5.Controls.Add(this.CheckBox10);
            this.TabPage5.Controls.Add(this.CheckBox9);
            this.TabPage5.Location = new Point(4, 0x16);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new Padding(3);
            this.TabPage5.Size = new Size(0x1af, 0xb6);
            this.TabPage5.TabIndex = 1;
            this.TabPage5.Text = "Bandwidth";
            this.TabPage5.UseVisualStyleBackColor = true;
            this.CheckBox8.AutoSize = true;
            this.CheckBox8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox8.Location = new Point(0x144, 0x9f);
            this.CheckBox8.Name = "CheckBox8";
            this.CheckBox8.Size = new Size(0x65, 0x11);
            this.CheckBox8.TabIndex = 0x5f;
            this.CheckBox8.Text = "Use AVG Trace";
            this.CheckBox8.UseVisualStyleBackColor = true;
            this.Label103.AutoSize = true;
            this.Label103.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label103.Location = new Point(0x79, 0x67);
            this.Label103.Name = "Label103";
            this.Label103.Size = new Size(0x60, 13);
            this.Label103.TabIndex = 90;
            this.Label103.Text = "Min. seek distance";
            this.Label103.TextAlign = ContentAlignment.MiddleLeft;
            this.TextBox82.BackColor = Color.LightBlue;
            this.TextBox82.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox82.Location = new Point(0xdf, 100);
            this.TextBox82.Name = "TextBox82";
            this.TextBox82.ReadOnly = true;
            this.TextBox82.Size = new Size(0x55, 20);
            this.TextBox82.TabIndex = 0x58;
            this.TextBox82.Text = "0.500 MHz";
            this.TextBox82.TextAlign = HorizontalAlignment.Right;
            this.TextBox81.BackColor = Color.PeachPuff;
            this.TextBox81.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox81.Location = new Point(0xdf, 0x4a);
            this.TextBox81.Name = "TextBox81";
            this.TextBox81.ReadOnly = true;
            this.TextBox81.Size = new Size(0x55, 20);
            this.TextBox81.TabIndex = 0x56;
            this.TextBox81.Text = "0 MHz";
            this.TextBox81.TextAlign = HorizontalAlignment.Right;
            this.TextBox80.BackColor = Color.PeachPuff;
            this.TextBox80.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox80.Location = new Point(0xdf, 0x30);
            this.TextBox80.Name = "TextBox80";
            this.TextBox80.ReadOnly = true;
            this.TextBox80.Size = new Size(0x55, 20);
            this.TextBox80.TabIndex = 0x54;
            this.TextBox80.Text = "0 MHz";
            this.TextBox80.TextAlign = HorizontalAlignment.Right;
            this.TextBox79.BackColor = Color.PeachPuff;
            this.TextBox79.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox79.Location = new Point(0xdf, 0x17);
            this.TextBox79.Name = "TextBox79";
            this.TextBox79.ReadOnly = true;
            this.TextBox79.Size = new Size(0x55, 20);
            this.TextBox79.TabIndex = 0x52;
            this.TextBox79.Text = "0 MHz";
            this.TextBox79.TextAlign = HorizontalAlignment.Right;
            this.CheckBox11.AutoSize = true;
            this.CheckBox11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox11.Location = new Point(0x9e, 0x4c);
            this.CheckBox11.Name = "CheckBox11";
            this.CheckBox11.Size = new Size(0x41, 0x11);
            this.CheckBox11.TabIndex = 0x51;
            this.CheckBox11.Text = "-60 dBm";
            this.CheckBox11.UseVisualStyleBackColor = true;
            this.CheckBox10.AutoSize = true;
            this.CheckBox10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox10.Location = new Point(0x9e, 0x31);
            this.CheckBox10.Name = "CheckBox10";
            this.CheckBox10.Size = new Size(0x3b, 0x11);
            this.CheckBox10.TabIndex = 80;
            this.CheckBox10.Text = "-6 dBm";
            this.CheckBox10.UseVisualStyleBackColor = true;
            this.CheckBox9.AutoSize = true;
            this.CheckBox9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox9.Location = new Point(0x9e, 0x19);
            this.CheckBox9.Name = "CheckBox9";
            this.CheckBox9.Size = new Size(0x3b, 0x11);
            this.CheckBox9.TabIndex = 0x4f;
            this.CheckBox9.Text = "-3 dBm";
            this.CheckBox9.UseVisualStyleBackColor = true;
            this.TabPage6.Controls.Add(this.Label85);
            this.TabPage6.Controls.Add(this.Button61);
            this.TabPage6.Controls.Add(this.Button60);
            this.TabPage6.Location = new Point(4, 0x16);
            this.TabPage6.Name = "TabPage6";
            this.TabPage6.Size = new Size(0x1af, 0xb6);
            this.TabPage6.TabIndex = 2;
            this.TabPage6.Text = "Trigger";
            this.TabPage6.UseVisualStyleBackColor = true;
            this.Label85.BackColor = Color.Lime;
            this.Label85.BorderStyle = BorderStyle.FixedSingle;
            this.Label85.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.Label85.Location = new Point(0x4d, 0x6c);
            this.Label85.Name = "Label85";
            this.Label85.Size = new Size(0x117, 0x24);
            this.Label85.TabIndex = 0x45;
            this.Label85.Text = "STATUS: OK";
            this.Label85.TextAlign = ContentAlignment.MiddleCenter;
            this.Button61.Location = new Point(0x119, 0x38);
            this.Button61.Name = "Button61";
            this.Button61.Size = new Size(0x4b, 0x25);
            this.Button61.TabIndex = 0x44;
            this.Button61.Text = "Clear Trigger Mask";
            this.Button61.UseVisualStyleBackColor = true;
            this.Button60.Location = new Point(0x4d, 0x38);
            this.Button60.Name = "Button60";
            this.Button60.Size = new Size(0x4b, 0x25);
            this.Button60.TabIndex = 0x43;
            this.Button60.Text = "Load Trigger Mask";
            this.Button60.UseVisualStyleBackColor = true;
            this.TabPage7.Controls.Add(this.CheckBox12);
            this.TabPage7.Controls.Add(this.CheckBox2);
            this.TabPage7.Controls.Add(this.Label11);
            this.TabPage7.Controls.Add(this.Button50);
            this.TabPage7.Controls.Add(this.Button51);
            this.TabPage7.Controls.Add(this.Label95);
            this.TabPage7.Controls.Add(this.Button71);
            this.TabPage7.Controls.Add(this.Button70);
            this.TabPage7.Controls.Add(this.Label94);
            this.TabPage7.Controls.Add(this.CheckBox7);
            this.TabPage7.Controls.Add(this.Button69);
            this.TabPage7.Controls.Add(this.Label92);
            this.TabPage7.Controls.Add(this.Label93);
            this.TabPage7.Controls.Add(this.TextBox76);
            this.TabPage7.Controls.Add(this.Label90);
            this.TabPage7.Controls.Add(this.CheckBox6);
            this.TabPage7.Location = new Point(4, 0x16);
            this.TabPage7.Name = "TabPage7";
            this.TabPage7.Size = new Size(0x1af, 0xb6);
            this.TabPage7.TabIndex = 3;
            this.TabPage7.Text = "Transponder";
            this.TabPage7.UseVisualStyleBackColor = true;
            this.CheckBox12.AutoSize = true;
            this.CheckBox12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox12.Location = new Point(0x36, 0x59);
            this.CheckBox12.Name = "CheckBox12";
            this.CheckBox12.Size = new Size(0x67, 0x11);
            this.CheckBox12.TabIndex = 0x5f;
            this.CheckBox12.Text = "Use Math Trace";
            this.CheckBox12.UseVisualStyleBackColor = true;
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox2.Location = new Point(0x36, 0x42);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new Size(0x65, 0x11);
            this.CheckBox2.TabIndex = 0x5e;
            this.CheckBox2.Text = "Use AVG Trace";
            this.CheckBox2.UseVisualStyleBackColor = true;
            this.Label11.BackColor = Color.PeachPuff;
            this.Label11.BorderStyle = BorderStyle.FixedSingle;
            this.Label11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label11.Location = new Point(0x13e, 0x10);
            this.Label11.Name = "Label11";
            this.Label11.Size = new Size(0x23, 0x11);
            this.Label11.TabIndex = 0x5d;
            this.Label11.Text = "0";
            this.Label11.TextAlign = ContentAlignment.MiddleCenter;
            this.Button50.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button50.Location = new Point(0x124, 15);
            this.Button50.Name = "Button50";
            this.Button50.Size = new Size(20, 0x13);
            this.Button50.TabIndex = 0x5c;
            this.Button50.Text = "-";
            this.Button50.UseVisualStyleBackColor = true;
            this.Button51.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button51.Location = new Point(0x167, 15);
            this.Button51.Name = "Button51";
            this.Button51.Size = new Size(20, 0x13);
            this.Button51.TabIndex = 0x5b;
            this.Button51.Text = "+";
            this.Button51.UseVisualStyleBackColor = true;
            this.Label95.BackColor = Color.PeachPuff;
            this.Label95.BorderStyle = BorderStyle.FixedSingle;
            this.Label95.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label95.Location = new Point(0x13e, 0x2a);
            this.Label95.Name = "Label95";
            this.Label95.Size = new Size(0x23, 0x11);
            this.Label95.TabIndex = 90;
            this.Label95.Text = "1";
            this.Label95.TextAlign = ContentAlignment.MiddleCenter;
            this.Button71.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button71.Location = new Point(0x124, 0x29);
            this.Button71.Name = "Button71";
            this.Button71.Size = new Size(20, 0x13);
            this.Button71.TabIndex = 0x59;
            this.Button71.Text = "-";
            this.Button71.UseVisualStyleBackColor = true;
            this.Button70.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button70.Location = new Point(0x167, 0x29);
            this.Button70.Name = "Button70";
            this.Button70.Size = new Size(20, 0x13);
            this.Button70.TabIndex = 0x58;
            this.Button70.Text = "+";
            this.Button70.UseVisualStyleBackColor = true;
            this.Label94.AutoSize = true;
            this.Label94.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label94.Location = new Point(0xe8, 0x2c);
            this.Label94.Name = "Label94";
            this.Label94.Size = new Size(0x36, 13);
            this.Label94.TabIndex = 0x57;
            this.Label94.Text = "Sensitivity";
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox7.Location = new Point(0x36, 0x2b);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new Size(100, 0x11);
            this.CheckBox7.TabIndex = 0x56;
            this.CheckBox7.Text = "Identify Satellite";
            this.CheckBox7.UseVisualStyleBackColor = true;
            this.Button69.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button69.Location = new Point(0x129, 0x93);
            this.Button69.Name = "Button69";
            this.Button69.Size = new Size(0x83, 0x20);
            this.Button69.TabIndex = 0x55;
            this.Button69.Text = "Save Transponder List";
            this.Button69.UseVisualStyleBackColor = true;
            this.Label92.AutoSize = true;
            this.Label92.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label92.Location = new Point(0x13f, 0x48);
            this.Label92.Name = "Label92";
            this.Label92.Size = new Size(0x1d, 13);
            this.Label92.TabIndex = 0x54;
            this.Label92.Text = "MHz";
            this.Label93.AutoSize = true;
            this.Label93.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label93.Location = new Point(0xce, 0x48);
            this.Label93.Name = "Label93";
            this.Label93.Size = new Size(80, 13);
            this.Label93.TabIndex = 0x53;
            this.Label93.Text = "Min. Bandwidth";
            this.TextBox76.BackColor = Color.LightBlue;
            this.TextBox76.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox76.Location = new Point(0x124, 0x45);
            this.TextBox76.Name = "TextBox76";
            this.TextBox76.Size = new Size(0x1b, 20);
            this.TextBox76.TabIndex = 0x52;
            this.TextBox76.Text = "10";
            this.TextBox76.TextAlign = HorizontalAlignment.Right;
            this.Label90.AutoSize = true;
            this.Label90.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label90.Location = new Point(0xee, 0x12);
            this.Label90.Name = "Label90";
            this.Label90.Size = new Size(0x30, 13);
            this.Label90.TabIndex = 80;
            this.Label90.Text = "Treshold";
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.CheckBox6.Location = new Point(0x36, 0x12);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new Size(0x88, 0x11);
            this.CheckBox6.TabIndex = 0x4e;
            this.CheckBox6.Text = "Recognize transponder";
            this.CheckBox6.UseVisualStyleBackColor = true;
            this.GroupBox8.Controls.Add(this.Button33);
            this.GroupBox8.Controls.Add(this.Button34);
            this.GroupBox8.Controls.Add(this.Button35);
            this.GroupBox8.Location = new Point(570, 0x26a);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new Size(0x3f, 0x58);
            this.GroupBox8.TabIndex = 30;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Overlay";
            this.Button33.Location = new Point(6, 0x3e);
            this.Button33.Name = "Button33";
            this.Button33.Size = new Size(50, 20);
            this.Button33.TabIndex = 30;
            this.Button33.Text = "CLR";
            this.Button33.UseVisualStyleBackColor = true;
            this.Button34.Location = new Point(6, 40);
            this.Button34.Name = "Button34";
            this.Button34.Size = new Size(50, 20);
            this.Button34.TabIndex = 0x1d;
            this.Button34.Text = "SAVE";
            this.Button34.UseVisualStyleBackColor = true;
            this.Button35.Location = new Point(6, 0x13);
            this.Button35.Name = "Button35";
            this.Button35.Size = new Size(50, 20);
            this.Button35.TabIndex = 0x1c;
            this.Button35.Text = "LOAD";
            this.Button35.UseVisualStyleBackColor = true;
            this.GroupBox7.Controls.Add(this.Button47);
            this.GroupBox7.Controls.Add(this.Button46);
            this.GroupBox7.Controls.Add(this.Button45);
            this.GroupBox7.Controls.Add(this.Button44);
            this.GroupBox7.Controls.Add(this.Button41);
            this.GroupBox7.Controls.Add(this.Button40);
            this.GroupBox7.Controls.Add(this.Label29);
            this.GroupBox7.Controls.Add(this.TextBox46);
            this.GroupBox7.Controls.Add(this.Button32);
            this.GroupBox7.Controls.Add(this.Button31);
            this.GroupBox7.Controls.Add(this.Button30);
            this.GroupBox7.Controls.Add(this.Button29);
            this.GroupBox7.Controls.Add(this.Button28);
            this.GroupBox7.Controls.Add(this.Button27);
            this.GroupBox7.Controls.Add(this.Button26);
            this.GroupBox7.Controls.Add(this.Button25);
            this.GroupBox7.Controls.Add(this.Button24);
            this.GroupBox7.Controls.Add(this.Button23);
            this.GroupBox7.Controls.Add(this.Button22);
            this.GroupBox7.Controls.Add(this.Button21);
            this.GroupBox7.Controls.Add(this.Button20);
            this.GroupBox7.Controls.Add(this.Button19);
            this.GroupBox7.Controls.Add(this.Button18);
            this.GroupBox7.Controls.Add(this.CheckBox1);
            this.GroupBox7.Location = new Point(0x48, 0x26a);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new Size(0x1ec, 0x58);
            this.GroupBox7.TabIndex = 0x1d;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Traces";
            this.Button47.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button47.Location = new Point(0x156, 0x3e);
            this.Button47.Name = "Button47";
            this.Button47.Size = new Size(0x12, 20);
            this.Button47.TabIndex = 40;
            this.Button47.Text = @"\/";
            this.Button47.UseVisualStyleBackColor = true;
            this.Button46.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button46.Location = new Point(0x156, 40);
            this.Button46.Name = "Button46";
            this.Button46.Size = new Size(0x12, 20);
            this.Button46.TabIndex = 0x27;
            this.Button46.Text = @"/\";
            this.Button46.UseVisualStyleBackColor = true;
            this.Button45.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button45.Location = new Point(0x13e, 0x3d);
            this.Button45.Name = "Button45";
            this.Button45.Size = new Size(0x12, 20);
            this.Button45.TabIndex = 0x26;
            this.Button45.Text = ">";
            this.Button45.UseVisualStyleBackColor = true;
            this.Button44.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button44.Location = new Point(0x11e, 0x3e);
            this.Button44.Name = "Button44";
            this.Button44.Size = new Size(0x12, 20);
            this.Button44.TabIndex = 0x25;
            this.Button44.Text = "<";
            this.Button44.UseVisualStyleBackColor = true;
            this.Button41.Location = new Point(0x11e, 0x13);
            this.Button41.Name = "Button41";
            this.Button41.Size = new Size(50, 20);
            this.Button41.TabIndex = 0x23;
            this.Button41.Text = "FADE";
            this.Button41.UseVisualStyleBackColor = true;
            this.Button40.Location = new Point(0x11e, 40);
            this.Button40.Name = "Button40";
            this.Button40.Size = new Size(50, 20);
            this.Button40.TabIndex = 0x22;
            this.Button40.Text = "3D";
            this.Button40.UseVisualStyleBackColor = true;
            this.Label29.AutoSize = true;
            this.Label29.Location = new Point(380, 0x42);
            this.Label29.Name = "Label29";
            this.Label29.Size = new Size(60, 13);
            this.Label29.TabIndex = 0x21;
            this.Label29.Text = "AVG Count";
            this.TextBox46.Location = new Point(0x1be, 0x3f);
            this.TextBox46.Name = "TextBox46";
            this.TextBox46.Size = new Size(0x22, 20);
            this.TextBox46.TabIndex = 0x20;
            this.TextBox46.Text = "10";
            this.TextBox46.TextAlign = HorizontalAlignment.Right;
            this.Button32.Location = new Point(0x171, 0x13);
            this.Button32.Name = "Button32";
            this.Button32.Size = new Size(0x6f, 20);
            this.Button32.TabIndex = 0x1f;
            this.Button32.Text = "EXPORT";
            this.Button32.UseVisualStyleBackColor = true;
            this.Button31.Location = new Point(0xae, 0x3e);
            this.Button31.Name = "Button31";
            this.Button31.Size = new Size(50, 20);
            this.Button31.TabIndex = 30;
            this.Button31.Text = "CLR";
            this.Button31.UseVisualStyleBackColor = true;
            this.Button30.Location = new Point(0x76, 0x3e);
            this.Button30.Name = "Button30";
            this.Button30.Size = new Size(50, 20);
            this.Button30.TabIndex = 0x1d;
            this.Button30.Text = "CLR";
            this.Button30.UseVisualStyleBackColor = true;
            this.Button29.Location = new Point(0x3e, 0x3e);
            this.Button29.Name = "Button29";
            this.Button29.Size = new Size(50, 20);
            this.Button29.TabIndex = 0x1c;
            this.Button29.Text = "CLR";
            this.Button29.UseVisualStyleBackColor = true;
            this.Button28.Location = new Point(230, 0x3e);
            this.Button28.Name = "Button28";
            this.Button28.Size = new Size(50, 20);
            this.Button28.TabIndex = 0x1b;
            this.Button28.Text = "CFG";
            this.Button28.UseVisualStyleBackColor = true;
            this.Button27.Location = new Point(230, 40);
            this.Button27.Name = "Button27";
            this.Button27.Size = new Size(50, 20);
            this.Button27.TabIndex = 0x1a;
            this.Button27.Text = "MEM";
            this.Button27.UseVisualStyleBackColor = true;
            this.Button26.Location = new Point(0xae, 40);
            this.Button26.Name = "Button26";
            this.Button26.Size = new Size(50, 20);
            this.Button26.TabIndex = 0x19;
            this.Button26.Text = "MEM";
            this.Button26.UseVisualStyleBackColor = true;
            this.Button25.Location = new Point(0x76, 40);
            this.Button25.Name = "Button25";
            this.Button25.Size = new Size(50, 20);
            this.Button25.TabIndex = 0x18;
            this.Button25.Text = "MEM";
            this.Button25.UseVisualStyleBackColor = true;
            this.Button24.Location = new Point(0x3e, 40);
            this.Button24.Name = "Button24";
            this.Button24.Size = new Size(50, 20);
            this.Button24.TabIndex = 0x17;
            this.Button24.Text = "MEM";
            this.Button24.UseVisualStyleBackColor = true;
            this.Button23.Location = new Point(6, 40);
            this.Button23.Name = "Button23";
            this.Button23.Size = new Size(50, 20);
            this.Button23.TabIndex = 0x16;
            this.Button23.Text = "MEM";
            this.Button23.UseVisualStyleBackColor = true;
            this.Button22.Location = new Point(230, 0x13);
            this.Button22.Name = "Button22";
            this.Button22.Size = new Size(50, 20);
            this.Button22.TabIndex = 0x15;
            this.Button22.Text = "MATH";
            this.Button22.UseVisualStyleBackColor = true;
            this.Button21.Location = new Point(0xae, 0x13);
            this.Button21.Name = "Button21";
            this.Button21.Size = new Size(50, 20);
            this.Button21.TabIndex = 20;
            this.Button21.Text = "AVG";
            this.Button21.UseVisualStyleBackColor = true;
            this.Button20.Location = new Point(0x76, 0x13);
            this.Button20.Name = "Button20";
            this.Button20.Size = new Size(50, 20);
            this.Button20.TabIndex = 0x13;
            this.Button20.Text = "MAX";
            this.Button20.UseVisualStyleBackColor = true;
            this.Button19.Location = new Point(0x3e, 0x13);
            this.Button19.Name = "Button19";
            this.Button19.Size = new Size(50, 20);
            this.Button19.TabIndex = 0x12;
            this.Button19.Text = "MIN";
            this.Button19.UseVisualStyleBackColor = true;
            this.Button18.BackColor = Color.Green;
            this.Button18.Location = new Point(6, 0x13);
            this.Button18.Name = "Button18";
            this.Button18.Size = new Size(50, 20);
            this.Button18.TabIndex = 0x11;
            this.Button18.Text = "LIVE";
            this.Button18.UseVisualStyleBackColor = false;
            this.GroupBox6.Controls.Add(this.Label56);
            this.GroupBox6.Controls.Add(this.TextBox57);
            this.GroupBox6.Controls.Add(this.Label8);
            this.GroupBox6.Controls.Add(this.TextBox55);
            this.GroupBox6.Controls.Add(this.TextBox17);
            this.GroupBox6.Controls.Add(this.Label16);
            this.GroupBox6.Controls.Add(this.TextBox18);
            this.GroupBox6.Controls.Add(this.TextBox16);
            this.GroupBox6.Controls.Add(this.TextBox15);
            this.GroupBox6.Controls.Add(this.Label14);
            this.GroupBox6.Controls.Add(this.TextBox13);
            this.GroupBox6.Controls.Add(this.Label15);
            this.GroupBox6.Controls.Add(this.TextBox14);
            this.GroupBox6.Location = new Point(0x27f, 0xf1);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new Size(0x14e, 0x88);
            this.GroupBox6.TabIndex = 0x1c;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Marker";
            this.Label56.AutoSize = true;
            this.Label56.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label56.Location = new Point(0x29, 0x5f);
            this.Label56.Name = "Label56";
            this.Label56.Size = new Size(0x26, 0x18);
            this.Label56.TabIndex = 0x5e;
            this.Label56.Text = "Mouse\r\nPosition";
            this.Label56.TextAlign = ContentAlignment.MiddleRight;
            this.TextBox57.BackColor = Color.PeachPuff;
            this.TextBox57.Location = new Point(0x55, 0x61);
            this.TextBox57.Name = "TextBox57";
            this.TextBox57.ReadOnly = true;
            this.TextBox57.Size = new Size(0x62, 20);
            this.TextBox57.TabIndex = 0x5d;
            this.TextBox57.Text = "1 MHz";
            this.TextBox57.TextAlign = HorizontalAlignment.Right;
            this.Label8.AutoSize = true;
            this.Label8.Location = new Point(0xc3, 100);
            this.Label8.Name = "Label8";
            this.Label8.Size = new Size(0x1b, 13);
            this.Label8.TabIndex = 0x5c;
            this.Label8.Text = "LOF";
            this.TextBox55.BackColor = Color.LightBlue;
            this.TextBox55.Location = new Point(0xe5, 0x61);
            this.TextBox55.Name = "TextBox55";
            this.TextBox55.ReadOnly = true;
            this.TextBox55.Size = new Size(0x62, 20);
            this.TextBox55.TabIndex = 0x5b;
            this.TextBox55.Text = "0 MHz";
            this.TextBox55.TextAlign = HorizontalAlignment.Right;
            this.TextBox17.BackColor = Color.PeachPuff;
            this.TextBox17.Location = new Point(0xe5, 0x47);
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.Size = new Size(0x62, 20);
            this.TextBox17.TabIndex = 0x15;
            this.TextBox17.Text = "20 dB";
            this.TextBox17.TextAlign = HorizontalAlignment.Right;
            this.Label16.AutoSize = true;
            this.Label16.Location = new Point(0x41, 0x4a);
            this.Label16.Name = "Label16";
            this.Label16.Size = new Size(14, 13);
            this.Label16.TabIndex = 20;
            this.Label16.Text = "Δ";
            this.TextBox18.BackColor = Color.PeachPuff;
            this.TextBox18.Location = new Point(0x55, 0x47);
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.ReadOnly = true;
            this.TextBox18.Size = new Size(0x62, 20);
            this.TextBox18.TabIndex = 0x13;
            this.TextBox18.Text = "1 MHz";
            this.TextBox18.TextAlign = HorizontalAlignment.Right;
            this.TextBox16.BackColor = Color.PeachPuff;
            this.TextBox16.Location = new Point(0xe5, 0x2d);
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.Size = new Size(0x62, 20);
            this.TextBox16.TabIndex = 0x12;
            this.TextBox16.Text = "20 dB";
            this.TextBox16.TextAlign = HorizontalAlignment.Right;
            this.TextBox15.BackColor = Color.PeachPuff;
            this.TextBox15.Location = new Point(0xe5, 0x13);
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Size = new Size(0x62, 20);
            this.TextBox15.TabIndex = 0x11;
            this.TextBox15.Text = "20 dB";
            this.TextBox15.TextAlign = HorizontalAlignment.Right;
            this.Label14.AutoSize = true;
            this.Label14.Location = new Point(30, 0x30);
            this.Label14.Name = "Label14";
            this.Label14.Size = new Size(0x31, 13);
            this.Label14.TabIndex = 15;
            this.Label14.Text = "Marker 2";
            this.TextBox13.BackColor = Color.LightBlue;
            this.TextBox13.Location = new Point(0x55, 0x13);
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.ReadOnly = true;
            this.TextBox13.Size = new Size(0x62, 20);
            this.TextBox13.TabIndex = 14;
            this.TextBox13.Text = "0.1 MHz";
            this.TextBox13.TextAlign = HorizontalAlignment.Right;
            this.Label15.AutoSize = true;
            this.Label15.Location = new Point(30, 0x16);
            this.Label15.Name = "Label15";
            this.Label15.Size = new Size(0x31, 13);
            this.Label15.TabIndex = 12;
            this.Label15.Text = "Marker 1";
            this.TextBox14.BackColor = Color.LightBlue;
            this.TextBox14.Location = new Point(0x55, 0x2d);
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.ReadOnly = true;
            this.TextBox14.Size = new Size(0x62, 20);
            this.TextBox14.TabIndex = 11;
            this.TextBox14.Text = "1 MHz";
            this.TextBox14.TextAlign = HorizontalAlignment.Right;
            this.GroupBox5.Controls.Add(this.Button17);
            this.GroupBox5.Controls.Add(this.Button16);
            this.GroupBox5.Controls.Add(this.Button15);
            this.GroupBox5.Controls.Add(this.Button14);
            this.GroupBox5.Controls.Add(this.Button13);
            this.GroupBox5.Controls.Add(this.Button12);
            this.GroupBox5.Controls.Add(this.Button11);
            this.GroupBox5.Controls.Add(this.Button10);
            this.GroupBox5.Controls.Add(this.Button9);
            this.GroupBox5.Controls.Add(this.Button1);
            this.GroupBox5.Location = new Point(0x3d3, 0x3d);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new Size(0x6f, 0x13c);
            this.GroupBox5.TabIndex = 0x1b;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Frequency Presets";
            this.Button17.Location = new Point(6, 0x11f);
            this.Button17.Name = "Button17";
            this.Button17.Size = new Size(0x63, 0x15);
            this.Button17.TabIndex = 9;
            this.Button17.Text = "MARKER 1-2";
            this.Button17.UseVisualStyleBackColor = true;
            this.Button16.Location = new Point(6, 0xea);
            this.Button16.Name = "Button16";
            this.Button16.Size = new Size(0x63, 0x15);
            this.Button16.TabIndex = 8;
            this.Button16.Text = "Preset 9";
            this.Button16.UseVisualStyleBackColor = true;
            this.Button15.Location = new Point(6, 0xcf);
            this.Button15.Name = "Button15";
            this.Button15.Size = new Size(0x63, 0x15);
            this.Button15.TabIndex = 7;
            this.Button15.Text = "Preset 8";
            this.Button15.UseVisualStyleBackColor = true;
            this.Button14.Location = new Point(6, 180);
            this.Button14.Name = "Button14";
            this.Button14.Size = new Size(0x63, 0x15);
            this.Button14.TabIndex = 6;
            this.Button14.Text = "Preset 7";
            this.Button14.UseVisualStyleBackColor = true;
            this.Button13.Location = new Point(6, 0x99);
            this.Button13.Name = "Button13";
            this.Button13.Size = new Size(0x63, 0x15);
            this.Button13.TabIndex = 5;
            this.Button13.Text = "Preset 6";
            this.Button13.UseVisualStyleBackColor = true;
            this.Button12.Location = new Point(6, 0x7e);
            this.Button12.Name = "Button12";
            this.Button12.Size = new Size(0x63, 0x15);
            this.Button12.TabIndex = 4;
            this.Button12.Text = "Preset 5";
            this.Button12.UseVisualStyleBackColor = true;
            this.Button11.Location = new Point(6, 0x63);
            this.Button11.Name = "Button11";
            this.Button11.Size = new Size(0x63, 0x15);
            this.Button11.TabIndex = 3;
            this.Button11.Text = "Preset 4";
            this.Button11.UseVisualStyleBackColor = true;
            this.Button10.Location = new Point(6, 0x48);
            this.Button10.Name = "Button10";
            this.Button10.Size = new Size(0x63, 0x15);
            this.Button10.TabIndex = 2;
            this.Button10.Text = "Preset 3";
            this.Button10.UseVisualStyleBackColor = true;
            this.Button9.Location = new Point(6, 0x2f);
            this.Button9.Name = "Button9";
            this.Button9.Size = new Size(0x63, 0x15);
            this.Button9.TabIndex = 1;
            this.Button9.Text = "Preset 2";
            this.Button9.UseVisualStyleBackColor = true;
            this.Button1.Location = new Point(6, 20);
            this.Button1.Name = "Button1";
            this.Button1.Size = new Size(0x63, 0x15);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Preset 1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Label5.BackColor = Color.PeachPuff;
            this.Label5.BorderStyle = BorderStyle.FixedSingle;
            this.Label5.ForeColor = Color.Black;
            this.Label5.Location = new Point(0x27f, 0x29);
            this.Label5.Name = "Label5";
            this.Label5.Size = new Size(0x1c3, 0x11);
            this.Label5.TabIndex = 0x1a;
            this.Label5.Text = "NOT CONNECTED";
            this.Button6.Location = new Point(6, 0x1e3);
            this.Button6.Name = "Button6";
            this.Button6.Size = new Size(60, 0x17);
            this.Button6.TabIndex = 0x18;
            this.Button6.Text = @"\/";
            this.Button6.UseVisualStyleBackColor = true;
            this.Button5.Location = new Point(6, 0x1ac);
            this.Button5.Name = "Button5";
            this.Button5.Size = new Size(60, 0x17);
            this.Button5.TabIndex = 0x17;
            this.Button5.Text = @"/\";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button4.Location = new Point(6, 0x3d);
            this.Button4.Name = "Button4";
            this.Button4.Size = new Size(60, 0x17);
            this.Button4.TabIndex = 0x16;
            this.Button4.Text = @"\/";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button2.Location = new Point(6, 6);
            this.Button2.Name = "Button2";
            this.Button2.Size = new Size(60, 0x17);
            this.Button2.TabIndex = 0x15;
            this.Button2.Text = @"/\";
            this.Button2.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add(this.Button39);
            this.GroupBox1.Controls.Add(this.Button38);
            this.GroupBox1.Controls.Add(this.TextBox5);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.Controls.Add(this.TextBox12);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.TextBox11);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.TextBox4);
            this.GroupBox1.Controls.Add(this.TextBox3);
            this.GroupBox1.Location = new Point(0x27f, 0x3d);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new Size(0xde, 0xae);
            this.GroupBox1.TabIndex = 0x13;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Frequency";
            this.Button39.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button39.Location = new Point(0x22, 0x61);
            this.Button39.Name = "Button39";
            this.Button39.Size = new Size(0x16, 20);
            this.Button39.TabIndex = 0x11;
            this.Button39.Text = "+";
            this.Button39.UseVisualStyleBackColor = true;
            this.Button38.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button38.Location = new Point(6, 0x61);
            this.Button38.Name = "Button38";
            this.Button38.Size = new Size(0x16, 20);
            this.Button38.TabIndex = 0x10;
            this.Button38.Text = "-";
            this.Button38.UseVisualStyleBackColor = true;
            this.Label13.AutoSize = true;
            this.Label13.Location = new Point(0x4b, 100);
            this.Label13.Name = "Label13";
            this.Label13.Size = new Size(0x20, 13);
            this.Label13.TabIndex = 13;
            this.Label13.Text = "Span";
            this.TextBox12.BackColor = Color.LightBlue;
            this.TextBox12.Location = new Point(0x71, 0x61);
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.ReadOnly = true;
            this.TextBox12.Size = new Size(0x62, 20);
            this.TextBox12.TabIndex = 12;
            this.TextBox12.Text = "2100 MHz";
            this.TextBox12.TextAlign = HorizontalAlignment.Right;
            this.Label6.AutoSize = true;
            this.Label6.Location = new Point(0x10, 0x30);
            this.Label6.Name = "Label6";
            this.Label6.Size = new Size(0x5b, 13);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "Centre Frequency";
            this.TextBox11.BackColor = Color.LightBlue;
            this.TextBox11.Location = new Point(0x71, 0x2d);
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.ReadOnly = true;
            this.TextBox11.Size = new Size(0x62, 20);
            this.TextBox11.TabIndex = 10;
            this.TextBox11.Text = "1000 MHz";
            this.TextBox11.TextAlign = HorizontalAlignment.Right;
            this.Label2.AutoSize = true;
            this.Label2.Location = new Point(0x1c, 0x4a);
            this.Label2.Name = "Label2";
            this.Label2.Size = new Size(0x4f, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "End Frequency";
            this.Label1.AutoSize = true;
            this.Label1.Location = new Point(0x18, 0x16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new Size(0x52, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Start Frequency";
            this.TextBox4.BackColor = Color.LightBlue;
            this.TextBox4.Location = new Point(0x71, 0x47);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.ReadOnly = true;
            this.TextBox4.Size = new Size(0x62, 20);
            this.TextBox4.TabIndex = 6;
            this.TextBox4.Text = "2100 MHz";
            this.TextBox4.TextAlign = HorizontalAlignment.Right;
            this.TextBox3.BackColor = Color.LightBlue;
            this.TextBox3.Location = new Point(0x71, 0x13);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ReadOnly = true;
            this.TextBox3.Size = new Size(0x62, 20);
            this.TextBox3.TabIndex = 5;
            this.TextBox3.Text = "9 KHz";
            this.TextBox3.TextAlign = HorizontalAlignment.Right;
            this.TabPage8.Controls.Add(this.Button66);
            this.TabPage8.Controls.Add(this.Button65);
            this.TabPage8.Controls.Add(this.Button64);
            this.TabPage8.Controls.Add(this.Button63);
            this.TabPage8.Controls.Add(this.Button62);
            this.TabPage8.Controls.Add(this.PictureBox7);
            this.TabPage8.Controls.Add(this.PictureBox8);
            this.TabPage8.Controls.Add(this.ListBox2);
            this.TabPage8.Location = new Point(4, 0x16);
            this.TabPage8.Name = "TabPage8";
            this.TabPage8.Size = new Size(0x449, 0x2cb);
            this.TabPage8.TabIndex = 3;
            this.TabPage8.Text = "Trigger Log";
            this.TabPage8.UseVisualStyleBackColor = true;
            this.Button66.Location = new Point(0x76, 0x20b);
            this.Button66.Name = "Button66";
            this.Button66.Size = new Size(0x60, 30);
            this.Button66.TabIndex = 80;
            this.Button66.Text = "USE MASK";
            this.Button66.UseVisualStyleBackColor = true;
            this.Button66.Visible = false;
            this.Button65.Location = new Point(0x10, 0x20b);
            this.Button65.Name = "Button65";
            this.Button65.Size = new Size(0x60, 30);
            this.Button65.TabIndex = 0x4f;
            this.Button65.Text = "NEW MASK";
            this.Button65.UseVisualStyleBackColor = true;
            this.Button65.Visible = false;
            this.Button64.Location = new Point(220, 0x20b);
            this.Button64.Name = "Button64";
            this.Button64.Size = new Size(0x60, 30);
            this.Button64.TabIndex = 0x4d;
            this.Button64.Text = "SAVE MASK";
            this.Button64.UseVisualStyleBackColor = true;
            this.Button64.Visible = false;
            this.Button63.Location = new Point(0xa3, 0x27f);
            this.Button63.Name = "Button63";
            this.Button63.Size = new Size(0x8d, 40);
            this.Button63.TabIndex = 0x4c;
            this.Button63.Text = "Open Trigger Mask Editor";
            this.Button63.UseVisualStyleBackColor = true;
            this.Button62.Location = new Point(0x10, 0x27f);
            this.Button62.Name = "Button62";
            this.Button62.Size = new Size(0x8d, 40);
            this.Button62.TabIndex = 0x4b;
            this.Button62.Text = "Clear Trigger Log";
            this.Button62.UseVisualStyleBackColor = true;
            this.PictureBox7.BackColor = Color.Black;
            this.PictureBox7.Location = new Point(0x10, 0x11);
            this.PictureBox7.Name = "PictureBox7";
            this.PictureBox7.Size = new Size(560, 500);
            this.PictureBox7.TabIndex = 0x4a;
            this.PictureBox7.TabStop = false;
            this.PictureBox7.Visible = false;
            this.PictureBox8.BackColor = Color.Black;
            this.PictureBox8.Location = new Point(0x10, 0x11);
            this.PictureBox8.Name = "PictureBox8";
            this.PictureBox8.Size = new Size(560, 500);
            this.PictureBox8.TabIndex = 0x4e;
            this.PictureBox8.TabStop = false;
            this.PictureBox8.Visible = false;
            this.ListBox2.Font = new Font("Courier New", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.ListBox2.FormattingEnabled = true;
            this.ListBox2.ItemHeight = 0x12;
            this.ListBox2.Location = new Point(0x10, 0x11);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.ScrollAlwaysVisible = true;
            this.ListBox2.Size = new Size(0x434, 0x268);
            this.ListBox2.TabIndex = 0x49;
            this.TabPage9.Controls.Add(this.Button56);
            this.TabPage9.Controls.Add(this.Label84);
            this.TabPage9.Controls.Add(this.Label83);
            this.TabPage9.Controls.Add(this.Label82);
            this.TabPage9.Controls.Add(this.Label81);
            this.TabPage9.Controls.Add(this.Label74);
            this.TabPage9.Controls.Add(this.Label73);
            this.TabPage9.Controls.Add(this.ListBox1);
            this.TabPage9.Controls.Add(this.Button57);
            this.TabPage9.Controls.Add(this.WebBrowser1);
            this.TabPage9.Controls.Add(this.PictureBox5);
            this.TabPage9.Location = new Point(4, 0x16);
            this.TabPage9.Name = "TabPage9";
            this.TabPage9.Size = new Size(0x449, 0x2cb);
            this.TabPage9.TabIndex = 4;
            this.TabPage9.Text = "Log on Maps";
            this.TabPage9.UseVisualStyleBackColor = true;
            this.Button56.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Button56.Location = new Point(0xf7, 0x5e);
            this.Button56.Name = "Button56";
            this.Button56.Size = new Size(0x59, 0x19);
            this.Button56.TabIndex = 0x45;
            this.Button56.Text = "Print Map";
            this.Button56.UseVisualStyleBackColor = true;
            this.Label84.AutoSize = true;
            this.Label84.Location = new Point(0x92, 0x52);
            this.Label84.Name = "Label84";
            this.Label84.Size = new Size(0x39, 13);
            this.Label84.TabIndex = 0x44;
            this.Label84.Text = "Frequency";
            this.Label83.AutoSize = true;
            this.Label83.Location = new Point(4, 0x52);
            this.Label83.Name = "Label83";
            this.Label83.Size = new Size(0x5b, 13);
            this.Label83.TabIndex = 0x43;
            this.Label83.Text = "File Creation Date";
            this.Label82.BackColor = Color.PeachPuff;
            this.Label82.BorderStyle = BorderStyle.FixedSingle;
            this.Label82.Location = new Point(3, 0x5f);
            this.Label82.Name = "Label82";
            this.Label82.Size = new Size(140, 0x18);
            this.Label82.TabIndex = 0x42;
            this.Label82.TextAlign = ContentAlignment.MiddleCenter;
            this.Label81.BackColor = Color.PeachPuff;
            this.Label81.BorderStyle = BorderStyle.FixedSingle;
            this.Label81.Location = new Point(0x95, 0x5f);
            this.Label81.Name = "Label81";
            this.Label81.Size = new Size(0x5c, 0x18);
            this.Label81.TabIndex = 0x41;
            this.Label81.TextAlign = ContentAlignment.MiddleCenter;
            this.Label74.AutoSize = true;
            this.Label74.Location = new Point(0x7d, 0x1f);
            this.Label74.Name = "Label74";
            this.Label74.Size = new Size(0x5b, 13);
            this.Label74.TabIndex = 0x40;
            this.Label74.Text = "Showing Log File:";
            this.Label73.BackColor = Color.PeachPuff;
            this.Label73.BorderStyle = BorderStyle.FixedSingle;
            this.Label73.Location = new Point(0x80, 0x33);
            this.Label73.Name = "Label73";
            this.Label73.Size = new Size(0xc5, 20);
            this.Label73.TabIndex = 0x3f;
            this.Label73.Text = "---";
            this.Label73.TextAlign = ContentAlignment.MiddleCenter;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new Point(3, 0x7a);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.ScrollAlwaysVisible = true;
            this.ListBox1.Size = new Size(0x14d, 0x240);
            this.ListBox1.TabIndex = 0x3e;
            this.Button57.Location = new Point(3, 0x1f);
            this.Button57.Name = "Button57";
            this.Button57.Size = new Size(100, 0x29);
            this.Button57.TabIndex = 60;
            this.Button57.Text = "Import Log-File";
            this.Button57.UseVisualStyleBackColor = true;
            this.WebBrowser1.Location = new Point(0x167, 0x1f);
            this.WebBrowser1.MinimumSize = new Size(20, 20);
            this.WebBrowser1.Name = "WebBrowser1";
            this.WebBrowser1.Size = new Size(0x2cc, 0x28e);
            this.WebBrowser1.TabIndex = 0x3b;
            this.PictureBox5.BackColor = Color.Black;
            this.PictureBox5.Location = new Point(0x156, 12);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new Size(750, 0x2b6);
            this.PictureBox5.TabIndex = 0x3d;
            this.PictureBox5.TabStop = false;
            this.TabPage2.Controls.Add(this.GroupBox13);
            this.TabPage2.Controls.Add(this.GroupBox18);
            this.TabPage2.Controls.Add(this.GroupBox14);
            this.TabPage2.Controls.Add(this.GroupBox19);
            this.TabPage2.Controls.Add(this.GroupBox12);
            this.TabPage2.Controls.Add(this.GroupBox3);
            this.TabPage2.Controls.Add(this.GroupBox9);
            this.TabPage2.Location = new Point(4, 0x16);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new Padding(3);
            this.TabPage2.Size = new Size(0x449, 0x2cb);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Setup";
            this.TabPage2.UseVisualStyleBackColor = true;
            this.GroupBox13.Controls.Add(this.Button59);
            this.GroupBox13.Controls.Add(this.Button7);
            this.GroupBox13.Controls.Add(this.Label9);
            this.GroupBox13.Controls.Add(this.TextBox6);
            this.GroupBox13.Controls.Add(this.Label4);
            this.GroupBox13.Controls.Add(this.TextBox56);
            this.GroupBox13.Location = new Point(7, 0x29b);
            this.GroupBox13.Name = "GroupBox13";
            this.GroupBox13.Size = new Size(0x1e2, 0x27);
            this.GroupBox13.TabIndex = 0x30;
            this.GroupBox13.TabStop = false;
            this.GroupBox13.Text = "Rohde && Schwarz CRTU";
            this.Button59.Location = new Point(420, 13);
            this.Button59.Name = "Button59";
            this.Button59.Size = new Size(0x36, 20);
            this.Button59.TabIndex = 0x31;
            this.Button59.Text = "DEBUG";
            this.Button59.UseVisualStyleBackColor = true;
            this.Button7.Location = new Point(0x177, 13);
            this.Button7.Name = "Button7";
            this.Button7.Size = new Size(0x2b, 20);
            this.Button7.TabIndex = 0x1d;
            this.Button7.Text = "SAVE";
            this.Button7.UseVisualStyleBackColor = true;
            this.Label9.AutoSize = true;
            this.Label9.Location = new Point(0xe5, 0x10);
            this.Label9.Name = "Label9";
            this.Label9.Size = new Size(0x63, 13);
            this.Label9.TabIndex = 3;
            this.Label9.Text = "Secondary Address";
            this.TextBox6.BackColor = Color.LightBlue;
            this.TextBox6.Location = new Point(0x14e, 13);
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Size = new Size(0x23, 20);
            this.TextBox6.TabIndex = 2;
            this.TextBox6.Text = "1";
            this.Label4.AutoSize = true;
            this.Label4.Location = new Point(0x11, 0x10);
            this.Label4.Name = "Label4";
            this.Label4.Size = new Size(0x48, 13);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "VISA Address";
            this.TextBox56.BackColor = Color.LightBlue;
            this.TextBox56.Location = new Point(0x5f, 13);
            this.TextBox56.Name = "TextBox56";
            this.TextBox56.Size = new Size(0x80, 20);
            this.TextBox56.TabIndex = 0;
            this.TextBox56.Text = "ASRL1::INSTR";
            this.GroupBox18.Controls.Add(this.Button68);
            this.GroupBox18.Controls.Add(this.Label89);
            this.GroupBox18.Controls.Add(this.TextBox74);
            this.GroupBox18.Controls.Add(this.CheckBox5);
            this.GroupBox18.Controls.Add(this.Label88);
            this.GroupBox18.Controls.Add(this.TextBox73);
            this.GroupBox18.Controls.Add(this.Label87);
            this.GroupBox18.Controls.Add(this.TextBox72);
            this.GroupBox18.Controls.Add(this.Label86);
            this.GroupBox18.Controls.Add(this.TextBox71);
            this.GroupBox18.Controls.Add(this.Button67);
            this.GroupBox18.Location = new Point(0x1ef, 0x221);
            this.GroupBox18.Name = "GroupBox18";
            this.GroupBox18.Size = new Size(0x254, 0x74);
            this.GroupBox18.TabIndex = 0x2f;
            this.GroupBox18.TabStop = false;
            this.GroupBox18.Text = "e-mail Settings";
            this.Button68.Location = new Point(0x1f0, 0x2e);
            this.Button68.Name = "Button68";
            this.Button68.Size = new Size(0x5d, 0x2b);
            this.Button68.TabIndex = 0x34;
            this.Button68.Text = "Save e-mail Settings";
            this.Button68.UseVisualStyleBackColor = true;
            this.Label89.AutoSize = true;
            this.Label89.Location = new Point(0x2c, 0x31);
            this.Label89.Name = "Label89";
            this.Label89.Size = new Size(0x24, 13);
            this.Label89.TabIndex = 0x33;
            this.Label89.Text = "Login:";
            this.TextBox74.BackColor = Color.LightBlue;
            this.TextBox74.Location = new Point(0x53, 0x2a);
            this.TextBox74.Name = "TextBox74";
            this.TextBox74.Size = new Size(0xa9, 20);
            this.TextBox74.TabIndex = 0x2e;
            this.CheckBox5.AutoSize = true;
            this.CheckBox5.Location = new Point(0x105, 0x39);
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Size = new Size(0x9c, 0x11);
            this.CheckBox5.TabIndex = 0x31;
            this.CheckBox5.Text = "Send e-mail on trigger alarm";
            this.CheckBox5.UseVisualStyleBackColor = true;
            this.Label88.AutoSize = true;
            this.Label88.Location = new Point(0x18, 0x49);
            this.Label88.Name = "Label88";
            this.Label88.Size = new Size(0x38, 13);
            this.Label88.TabIndex = 0x30;
            this.Label88.Text = "Password:";
            this.TextBox73.BackColor = Color.LightBlue;
            this.TextBox73.Location = new Point(0x53, 0x44);
            this.TextBox73.Name = "TextBox73";
            this.TextBox73.PasswordChar = '*';
            this.TextBox73.Size = new Size(0xa9, 20);
            this.TextBox73.TabIndex = 0x2f;
            this.TextBox73.UseSystemPasswordChar = true;
            this.Label87.AutoSize = true;
            this.Label87.Location = new Point(6, 0x13);
            this.Label87.Name = "Label87";
            this.Label87.Size = new Size(0x4a, 13);
            this.Label87.TabIndex = 0x2e;
            this.Label87.Text = "SMTP Server:";
            this.TextBox72.BackColor = Color.LightBlue;
            this.TextBox72.Location = new Point(0x53, 0x10);
            this.TextBox72.Name = "TextBox72";
            this.TextBox72.Size = new Size(0xa9, 20);
            this.TextBox72.TabIndex = 0x2d;
            this.Label86.AutoSize = true;
            this.Label86.Location = new Point(0x102, 0x13);
            this.Label86.Name = "Label86";
            this.Label86.Size = new Size(0x4d, 13);
            this.Label86.TabIndex = 0x2c;
            this.Label86.Text = "Send e-mail to:";
            this.TextBox71.BackColor = Color.LightBlue;
            this.TextBox71.Location = new Point(0x155, 0x10);
            this.TextBox71.Name = "TextBox71";
            this.TextBox71.Size = new Size(0x95, 20);
            this.TextBox71.TabIndex = 0x2b;
            this.Button67.Location = new Point(0x1f0, 0x10);
            this.Button67.Name = "Button67";
            this.Button67.Size = new Size(0x5d, 0x15);
            this.Button67.TabIndex = 0x2a;
            this.Button67.Text = "Send test e-mail";
            this.Button67.UseVisualStyleBackColor = true;
            this.GroupBox14.Controls.Add(this.Button54);
            this.GroupBox14.Controls.Add(this.Label78);
            this.GroupBox14.Controls.Add(this.Label75);
            this.GroupBox14.Controls.Add(this.GroupBox15);
            this.GroupBox14.Controls.Add(this.CheckBox4);
            this.GroupBox14.Controls.Add(this.ComboBox3);
            this.GroupBox14.Location = new Point(6, 0x221);
            this.GroupBox14.Name = "GroupBox14";
            this.GroupBox14.Size = new Size(0x1e3, 0x74);
            this.GroupBox14.TabIndex = 0x2e;
            this.GroupBox14.TabStop = false;
            this.GroupBox14.Text = "GPS";
            this.Button54.Location = new Point(0x128, 0x23);
            this.Button54.Name = "Button54";
            this.Button54.Size = new Size(0x69, 0x2b);
            this.Button54.TabIndex = 0x2c;
            this.Button54.Text = "SAVE GPS POSITION";
            this.Button54.UseVisualStyleBackColor = true;
            this.Label78.AutoSize = true;
            this.Label78.Location = new Point(6, 0x59);
            this.Label78.Name = "Label78";
            this.Label78.Size = new Size(0x21, 13);
            this.Label78.TabIndex = 0x2b;
            this.Label78.Text = "RAW";
            this.Label75.BackColor = Color.Black;
            this.Label75.BorderStyle = BorderStyle.FixedSingle;
            this.Label75.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label75.ForeColor = Color.Lime;
            this.Label75.Location = new Point(40, 0x59);
            this.Label75.Name = "Label75";
            this.Label75.Size = new Size(250, 0x10);
            this.Label75.TabIndex = 0x2a;
            this.Label75.Text = "---";
            this.GroupBox15.Controls.Add(this.TextBox70);
            this.GroupBox15.Controls.Add(this.Label77);
            this.GroupBox15.Controls.Add(this.TextBox69);
            this.GroupBox15.Controls.Add(this.Label76);
            this.GroupBox15.Location = new Point(0x7a, 0x13);
            this.GroupBox15.Name = "GroupBox15";
            this.GroupBox15.Size = new Size(0xa8, 0x43);
            this.GroupBox15.TabIndex = 0x2a;
            this.GroupBox15.TabStop = false;
            this.GroupBox15.Text = "GPS Position";
            this.TextBox70.BackColor = Color.LightBlue;
            this.TextBox70.Location = new Point(0x47, 0x27);
            this.TextBox70.Name = "TextBox70";
            this.TextBox70.Size = new Size(0x5b, 20);
            this.TextBox70.TabIndex = 0x2d;
            this.TextBox70.Text = "-8.54763";
            this.TextBox70.TextAlign = HorizontalAlignment.Right;
            this.Label77.AutoSize = true;
            this.Label77.Location = new Point(6, 0x2a);
            this.Label77.Name = "Label77";
            this.Label77.Size = new Size(0x36, 13);
            this.Label77.TabIndex = 3;
            this.Label77.Text = "Longitude";
            this.TextBox69.BackColor = Color.LightBlue;
            this.TextBox69.Location = new Point(0x47, 0x10);
            this.TextBox69.Name = "TextBox69";
            this.TextBox69.Size = new Size(0x5b, 20);
            this.TextBox69.TabIndex = 0x2c;
            this.TextBox69.Text = "41.218088";
            this.TextBox69.TextAlign = HorizontalAlignment.Right;
            this.Label76.AutoSize = true;
            this.Label76.Location = new Point(6, 0x13);
            this.Label76.Name = "Label76";
            this.Label76.Size = new Size(0x2d, 13);
            this.Label76.TabIndex = 2;
            this.Label76.Text = "Latitude";
            this.CheckBox4.AutoSize = true;
            this.CheckBox4.Location = new Point(6, 0x2e);
            this.CheckBox4.Name = "CheckBox4";
            this.CheckBox4.Size = new Size(110, 0x11);
            this.CheckBox4.TabIndex = 0x29;
            this.CheckBox4.Text = "Use GPS location";
            this.CheckBox4.UseVisualStyleBackColor = true;
            this.ComboBox3.BackColor = Color.LightBlue;
            this.ComboBox3.FormattingEnabled = true;
            object[] items = new object[] { "- - - - -" };
            this.ComboBox3.Items.AddRange(items);
            this.ComboBox3.Location = new Point(6, 0x13);
            this.ComboBox3.Name = "ComboBox3";
            this.ComboBox3.Size = new Size(0x44, 0x15);
            this.ComboBox3.TabIndex = 0x19;
            this.ComboBox3.Text = "COM1";
            this.GroupBox19.Controls.Add(this.Button72);
            this.GroupBox19.Controls.Add(this.TextBox77);
            this.GroupBox19.Controls.Add(this.TextBox78);
            this.GroupBox19.Controls.Add(this.Label96);
            this.GroupBox19.Controls.Add(this.Label97);
            this.GroupBox19.Location = new Point(7, 0x1b2);
            this.GroupBox19.Name = "GroupBox19";
            this.GroupBox19.Size = new Size(0x1e2, 0x69);
            this.GroupBox19.TabIndex = 0x2d;
            this.GroupBox19.TabStop = false;
            this.GroupBox19.Text = "Satellite Identificaton";
            this.Button72.Location = new Point(0x110, 30);
            this.Button72.Name = "Button72";
            this.Button72.Size = new Size(0x67, 0x2a);
            this.Button72.TabIndex = 0x1c;
            this.Button72.Text = "SAVE";
            this.Button72.UseVisualStyleBackColor = true;
            this.TextBox77.BackColor = Color.LightBlue;
            this.TextBox77.Location = new Point(0xcc, 0x38);
            this.TextBox77.Name = "TextBox77";
            this.TextBox77.ReadOnly = true;
            this.TextBox77.Size = new Size(0x38, 20);
            this.TextBox77.TabIndex = 8;
            this.TextBox77.Text = "3000";
            this.TextBox77.TextAlign = HorizontalAlignment.Right;
            this.TextBox78.BackColor = Color.LightBlue;
            this.TextBox78.Location = new Point(0xcb, 30);
            this.TextBox78.Name = "TextBox78";
            this.TextBox78.ReadOnly = true;
            this.TextBox78.Size = new Size(0x38, 20);
            this.TextBox78.TabIndex = 7;
            this.TextBox78.Text = "15000";
            this.TextBox78.TextAlign = HorizontalAlignment.Right;
            this.Label96.AutoSize = true;
            this.Label96.Location = new Point(0x1a, 0x3b);
            this.Label96.Name = "Label96";
            this.Label96.Size = new Size(0xac, 13);
            this.Label96.TabIndex = 6;
            this.Label96.Text = "C-Band: Ignore Symbol Rate below";
            this.Label97.AutoSize = true;
            this.Label97.Location = new Point(20, 0x21);
            this.Label97.Name = "Label97";
            this.Label97.Size = new Size(0xb2, 13);
            this.Label97.TabIndex = 5;
            this.Label97.Text = "Ku-Band: Ignore Symbol Rate below";
            this.GroupBox12.Controls.Add(this.PictureBox6);
            this.GroupBox12.Controls.Add(this.TextBox68);
            this.GroupBox12.Location = new Point(0x1ef, 6);
            this.GroupBox12.Name = "GroupBox12";
            this.GroupBox12.Size = new Size(0x254, 0x215);
            this.GroupBox12.TabIndex = 0x29;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "Donation";
            this.PictureBox6.BackgroundImage = (Image) manager.GetObject("PictureBox6.BackgroundImage");
            this.PictureBox6.BackgroundImageLayout = ImageLayout.Center;
            this.PictureBox6.Location = new Point(0x84, 0x1ac);
            this.PictureBox6.Name = "PictureBox6";
            this.PictureBox6.Size = new Size(0x1c9, 0x5e);
            this.PictureBox6.TabIndex = 3;
            this.PictureBox6.TabStop = false;
            this.TextBox68.Enabled = false;
            this.TextBox68.Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox68.Location = new Point(6, 0x13);
            this.TextBox68.Multiline = true;
            this.TextBox68.Name = "TextBox68";
            this.TextBox68.Size = new Size(0x247, 0x193);
            this.TextBox68.TabIndex = 1;
            this.TextBox68.Text = manager.GetString("TextBox68.Text");
            this.GroupBox3.Controls.Add(this.Label63);
            this.GroupBox3.Controls.Add(this.Button48);
            this.GroupBox3.Controls.Add(this.Button49);
            this.GroupBox3.Controls.Add(this.TextBox64);
            this.GroupBox3.Controls.Add(this.TextBox63);
            this.GroupBox3.Controls.Add(this.TextBox62);
            this.GroupBox3.Controls.Add(this.Label62);
            this.GroupBox3.Controls.Add(this.Label61);
            this.GroupBox3.Controls.Add(this.Label60);
            this.GroupBox3.Location = new Point(7, 0x13b);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new Size(0x1e2, 0x71);
            this.GroupBox3.TabIndex = 40;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "License Information";
            this.Label63.AutoSize = true;
            this.Label63.Location = new Point(0x10d, 0x52);
            this.Label63.Name = "Label63";
            this.Label63.Size = new Size(0xca, 13);
            this.Label63.TabIndex = 8;
            this.Label63.Text = "Send license request to: vma@norcam.pt";
            this.Button48.Location = new Point(0x10c, 0x16);
            this.Button48.Name = "Button48";
            this.Button48.Size = new Size(0xcb, 20);
            this.Button48.TabIndex = 7;
            this.Button48.Text = "SELECT MAC ADDRESS";
            this.Button48.UseVisualStyleBackColor = true;
            this.Button49.Location = new Point(0x10c, 0x35);
            this.Button49.Name = "Button49";
            this.Button49.Size = new Size(0xcb, 20);
            this.Button49.TabIndex = 6;
            this.Button49.Text = "UPDATE ACTIVATION CODE";
            this.Button49.UseVisualStyleBackColor = true;
            this.TextBox64.BackColor = Color.PeachPuff;
            this.TextBox64.Enabled = false;
            this.TextBox64.Location = new Point(0x5f, 0x4f);
            this.TextBox64.Name = "TextBox64";
            this.TextBox64.Size = new Size(0xa7, 20);
            this.TextBox64.TabIndex = 5;
            this.TextBox63.BackColor = Color.LightBlue;
            this.TextBox63.Location = new Point(0x5f, 0x35);
            this.TextBox63.Name = "TextBox63";
            this.TextBox63.Size = new Size(0xa7, 20);
            this.TextBox63.TabIndex = 4;
            this.TextBox62.BackColor = Color.PeachPuff;
            this.TextBox62.Enabled = false;
            this.TextBox62.Location = new Point(0x5f, 0x17);
            this.TextBox62.Name = "TextBox62";
            this.TextBox62.Size = new Size(0xa7, 20);
            this.TextBox62.TabIndex = 3;
            this.Label62.AutoSize = true;
            this.Label62.Location = new Point(0x1c, 0x52);
            this.Label62.Name = "Label62";
            this.Label62.Size = new Size(0x3d, 13);
            this.Label62.TabIndex = 2;
            this.Label62.Text = "Expiry Date";
            this.Label61.AutoSize = true;
            this.Label61.Location = new Point(7, 0x38);
            this.Label61.Name = "Label61";
            this.Label61.Size = new Size(0x52, 13);
            this.Label61.TabIndex = 1;
            this.Label61.Text = "Activation Code";
            this.Label60.AutoSize = true;
            this.Label60.Location = new Point(20, 0x1a);
            this.Label60.Name = "Label60";
            this.Label60.Size = new Size(0x45, 13);
            this.Label60.TabIndex = 0;
            this.Label60.Text = "System Code";
            this.GroupBox9.Controls.Add(this.Label7);
            this.GroupBox9.Controls.Add(this.TextBox52);
            this.GroupBox9.Controls.Add(this.TextBox8);
            this.GroupBox9.Controls.Add(this.TextBox51);
            this.GroupBox9.Controls.Add(this.TextBox9);
            this.GroupBox9.Controls.Add(this.TextBox50);
            this.GroupBox9.Controls.Add(this.TextBox47);
            this.GroupBox9.Controls.Add(this.TextBox49);
            this.GroupBox9.Controls.Add(this.TextBox48);
            this.GroupBox9.Controls.Add(this.TextBox7);
            this.GroupBox9.Controls.Add(this.Button43);
            this.GroupBox9.Controls.Add(this.Label26);
            this.GroupBox9.Controls.Add(this.TextBox45);
            this.GroupBox9.Controls.Add(this.Label17);
            this.GroupBox9.Controls.Add(this.Label18);
            this.GroupBox9.Controls.Add(this.TextBox44);
            this.GroupBox9.Controls.Add(this.Label19);
            this.GroupBox9.Controls.Add(this.TextBox43);
            this.GroupBox9.Controls.Add(this.Label20);
            this.GroupBox9.Controls.Add(this.TextBox42);
            this.GroupBox9.Controls.Add(this.Label21);
            this.GroupBox9.Controls.Add(this.TextBox41);
            this.GroupBox9.Controls.Add(this.Label22);
            this.GroupBox9.Controls.Add(this.TextBox40);
            this.GroupBox9.Controls.Add(this.Label23);
            this.GroupBox9.Controls.Add(this.TextBox39);
            this.GroupBox9.Controls.Add(this.Label24);
            this.GroupBox9.Controls.Add(this.TextBox38);
            this.GroupBox9.Controls.Add(this.Label25);
            this.GroupBox9.Controls.Add(this.TextBox37);
            this.GroupBox9.Controls.Add(this.TextBox36);
            this.GroupBox9.Controls.Add(this.TextBox35);
            this.GroupBox9.Controls.Add(this.TextBox34);
            this.GroupBox9.Controls.Add(this.TextBox33);
            this.GroupBox9.Controls.Add(this.TextBox32);
            this.GroupBox9.Controls.Add(this.TextBox31);
            this.GroupBox9.Controls.Add(this.TextBox30);
            this.GroupBox9.Controls.Add(this.TextBox29);
            this.GroupBox9.Controls.Add(this.TextBox28);
            this.GroupBox9.Controls.Add(this.TextBox27);
            this.GroupBox9.Controls.Add(this.TextBox26);
            this.GroupBox9.Controls.Add(this.TextBox25);
            this.GroupBox9.Controls.Add(this.TextBox24);
            this.GroupBox9.Controls.Add(this.TextBox23);
            this.GroupBox9.Controls.Add(this.TextBox22);
            this.GroupBox9.Controls.Add(this.TextBox21);
            this.GroupBox9.Controls.Add(this.TextBox20);
            this.GroupBox9.Controls.Add(this.TextBox19);
            this.GroupBox9.Controls.Add(this.Label28);
            this.GroupBox9.Controls.Add(this.Label27);
            this.GroupBox9.Location = new Point(7, 6);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new Size(0x1e2, 0x12f);
            this.GroupBox9.TabIndex = 3;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Frequency Presets";
            this.Label7.AutoSize = true;
            this.Label7.Location = new Point(0x170, 0x11);
            this.Label7.Name = "Label7";
            this.Label7.Size = new Size(0x1b, 13);
            this.Label7.TabIndex = 50;
            this.Label7.Text = "LOF";
            this.TextBox52.BackColor = Color.LightBlue;
            this.TextBox52.Location = new Point(0x173, 240);
            this.TextBox52.Name = "TextBox52";
            this.TextBox52.ReadOnly = true;
            this.TextBox52.Size = new Size(0x62, 20);
            this.TextBox52.TabIndex = 0x29;
            this.TextBox52.Text = "0 MHz";
            this.TextBox52.TextAlign = HorizontalAlignment.Right;
            this.TextBox8.BackColor = Color.LightBlue;
            this.TextBox8.Location = new Point(0x173, 0x3b);
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.ReadOnly = true;
            this.TextBox8.Size = new Size(0x62, 20);
            this.TextBox8.TabIndex = 0x30;
            this.TextBox8.Text = "0 MHz";
            this.TextBox8.TextAlign = HorizontalAlignment.Right;
            this.TextBox51.BackColor = Color.LightBlue;
            this.TextBox51.Location = new Point(0x173, 0xd6);
            this.TextBox51.Name = "TextBox51";
            this.TextBox51.ReadOnly = true;
            this.TextBox51.Size = new Size(0x62, 20);
            this.TextBox51.TabIndex = 0x2a;
            this.TextBox51.Text = "0 MHz";
            this.TextBox51.TextAlign = HorizontalAlignment.Right;
            this.TextBox9.BackColor = Color.LightBlue;
            this.TextBox9.Location = new Point(0x173, 0x54);
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.ReadOnly = true;
            this.TextBox9.Size = new Size(0x62, 20);
            this.TextBox9.TabIndex = 0x2f;
            this.TextBox9.Text = "0 MHz";
            this.TextBox9.TextAlign = HorizontalAlignment.Right;
            this.TextBox50.BackColor = Color.LightBlue;
            this.TextBox50.Location = new Point(0x173, 0xbd);
            this.TextBox50.Name = "TextBox50";
            this.TextBox50.ReadOnly = true;
            this.TextBox50.Size = new Size(0x62, 20);
            this.TextBox50.TabIndex = 0x2b;
            this.TextBox50.Text = "0 MHz";
            this.TextBox50.TextAlign = HorizontalAlignment.Right;
            this.TextBox47.BackColor = Color.LightBlue;
            this.TextBox47.Location = new Point(0x173, 110);
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.ReadOnly = true;
            this.TextBox47.Size = new Size(0x62, 20);
            this.TextBox47.TabIndex = 0x2e;
            this.TextBox47.Text = "0 MHz";
            this.TextBox47.TextAlign = HorizontalAlignment.Right;
            this.TextBox49.BackColor = Color.LightBlue;
            this.TextBox49.Location = new Point(0x173, 0xa2);
            this.TextBox49.Name = "TextBox49";
            this.TextBox49.ReadOnly = true;
            this.TextBox49.Size = new Size(0x62, 20);
            this.TextBox49.TabIndex = 0x2c;
            this.TextBox49.Text = "0 MHz";
            this.TextBox49.TextAlign = HorizontalAlignment.Right;
            this.TextBox48.BackColor = Color.LightBlue;
            this.TextBox48.Location = new Point(0x173, 0x88);
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.ReadOnly = true;
            this.TextBox48.Size = new Size(0x62, 20);
            this.TextBox48.TabIndex = 0x2d;
            this.TextBox48.Text = "0 MHz";
            this.TextBox48.TextAlign = HorizontalAlignment.Right;
            this.TextBox7.BackColor = Color.LightBlue;
            this.TextBox7.Location = new Point(0x173, 0x21);
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.ReadOnly = true;
            this.TextBox7.Size = new Size(0x62, 20);
            this.TextBox7.TabIndex = 0x31;
            this.TextBox7.Text = "0 MHz";
            this.TextBox7.TextAlign = HorizontalAlignment.Right;
            this.Button43.Location = new Point(0x173, 0x10a);
            this.Button43.Name = "Button43";
            this.Button43.Size = new Size(0x62, 0x19);
            this.Button43.TabIndex = 40;
            this.Button43.Text = "SAVE";
            this.Button43.UseVisualStyleBackColor = true;
            this.Label26.AutoSize = true;
            this.Label26.Location = new Point(0x38, 0x10);
            this.Label26.Name = "Label26";
            this.Label26.Size = new Size(0x21, 13);
            this.Label26.TabIndex = 0x27;
            this.Label26.Text = "Label";
            this.TextBox45.BackColor = Color.LightBlue;
            this.TextBox45.Location = new Point(0x10b, 240);
            this.TextBox45.Name = "TextBox45";
            this.TextBox45.ReadOnly = true;
            this.TextBox45.Size = new Size(0x62, 20);
            this.TextBox45.TabIndex = 0x26;
            this.TextBox45.Text = "2100 KHz";
            this.TextBox45.TextAlign = HorizontalAlignment.Right;
            this.Label17.AutoSize = true;
            this.Label17.Location = new Point(7, 0x24);
            this.Label17.Name = "Label17";
            this.Label17.Size = new Size(0x2e, 13);
            this.Label17.TabIndex = 0;
            this.Label17.Text = "Preset 1";
            this.Label18.AutoSize = true;
            this.Label18.Location = new Point(7, 0x3e);
            this.Label18.Name = "Label18";
            this.Label18.Size = new Size(0x2e, 13);
            this.Label18.TabIndex = 1;
            this.Label18.Text = "Preset 2";
            this.TextBox44.BackColor = Color.LightBlue;
            this.TextBox44.Location = new Point(0xa3, 0xf1);
            this.TextBox44.Name = "TextBox44";
            this.TextBox44.ReadOnly = true;
            this.TextBox44.Size = new Size(0x62, 20);
            this.TextBox44.TabIndex = 0x25;
            this.TextBox44.Text = "9 KHz";
            this.TextBox44.TextAlign = HorizontalAlignment.Right;
            this.Label19.AutoSize = true;
            this.Label19.Location = new Point(7, 0x58);
            this.Label19.Name = "Label19";
            this.Label19.Size = new Size(0x2e, 13);
            this.Label19.TabIndex = 2;
            this.Label19.Text = "Preset 3";
            this.TextBox43.BackColor = Color.White;
            this.TextBox43.Location = new Point(0x3b, 0xf1);
            this.TextBox43.Name = "TextBox43";
            this.TextBox43.Size = new Size(0x62, 20);
            this.TextBox43.TabIndex = 0x24;
            this.TextBox43.Text = "Full Range";
            this.TextBox43.TextAlign = HorizontalAlignment.Right;
            this.Label20.AutoSize = true;
            this.Label20.Location = new Point(7, 0x72);
            this.Label20.Name = "Label20";
            this.Label20.Size = new Size(0x2e, 13);
            this.Label20.TabIndex = 3;
            this.Label20.Text = "Preset 4";
            this.TextBox42.BackColor = Color.LightBlue;
            this.TextBox42.Location = new Point(0x10b, 0xd6);
            this.TextBox42.Name = "TextBox42";
            this.TextBox42.ReadOnly = true;
            this.TextBox42.Size = new Size(0x62, 20);
            this.TextBox42.TabIndex = 0x23;
            this.TextBox42.Text = "2100 KHz";
            this.TextBox42.TextAlign = HorizontalAlignment.Right;
            this.Label21.AutoSize = true;
            this.Label21.Location = new Point(7, 140);
            this.Label21.Name = "Label21";
            this.Label21.Size = new Size(0x2e, 13);
            this.Label21.TabIndex = 4;
            this.Label21.Text = "Preset 5";
            this.TextBox41.BackColor = Color.LightBlue;
            this.TextBox41.Location = new Point(0xa3, 0xd7);
            this.TextBox41.Name = "TextBox41";
            this.TextBox41.ReadOnly = true;
            this.TextBox41.Size = new Size(0x62, 20);
            this.TextBox41.TabIndex = 0x22;
            this.TextBox41.Text = "9 KHz";
            this.TextBox41.TextAlign = HorizontalAlignment.Right;
            this.Label22.AutoSize = true;
            this.Label22.Location = new Point(7, 0xa6);
            this.Label22.Name = "Label22";
            this.Label22.Size = new Size(0x2e, 13);
            this.Label22.TabIndex = 5;
            this.Label22.Text = "Preset 6";
            this.TextBox40.BackColor = Color.White;
            this.TextBox40.Location = new Point(0x3b, 0xd7);
            this.TextBox40.Name = "TextBox40";
            this.TextBox40.Size = new Size(0x62, 20);
            this.TextBox40.TabIndex = 0x21;
            this.TextBox40.Text = "Full Range";
            this.TextBox40.TextAlign = HorizontalAlignment.Right;
            this.Label23.AutoSize = true;
            this.Label23.Location = new Point(7, 0xc0);
            this.Label23.Name = "Label23";
            this.Label23.Size = new Size(0x2e, 13);
            this.Label23.TabIndex = 6;
            this.Label23.Text = "Preset 7";
            this.TextBox39.BackColor = Color.LightBlue;
            this.TextBox39.Location = new Point(0x10b, 0xbc);
            this.TextBox39.Name = "TextBox39";
            this.TextBox39.ReadOnly = true;
            this.TextBox39.Size = new Size(0x62, 20);
            this.TextBox39.TabIndex = 0x20;
            this.TextBox39.Text = "2100 KHz";
            this.TextBox39.TextAlign = HorizontalAlignment.Right;
            this.Label24.AutoSize = true;
            this.Label24.Location = new Point(7, 0xda);
            this.Label24.Name = "Label24";
            this.Label24.Size = new Size(0x2e, 13);
            this.Label24.TabIndex = 7;
            this.Label24.Text = "Preset 8";
            this.TextBox38.BackColor = Color.LightBlue;
            this.TextBox38.Location = new Point(0xa3, 0xbd);
            this.TextBox38.Name = "TextBox38";
            this.TextBox38.ReadOnly = true;
            this.TextBox38.Size = new Size(0x62, 20);
            this.TextBox38.TabIndex = 0x1f;
            this.TextBox38.Text = "9 KHz";
            this.TextBox38.TextAlign = HorizontalAlignment.Right;
            this.Label25.AutoSize = true;
            this.Label25.Location = new Point(7, 0xf4);
            this.Label25.Name = "Label25";
            this.Label25.Size = new Size(0x2e, 13);
            this.Label25.TabIndex = 8;
            this.Label25.Text = "Preset 9";
            this.TextBox37.BackColor = Color.White;
            this.TextBox37.Location = new Point(0x3b, 0xbd);
            this.TextBox37.Name = "TextBox37";
            this.TextBox37.Size = new Size(0x62, 20);
            this.TextBox37.TabIndex = 30;
            this.TextBox37.Text = "Full Range";
            this.TextBox37.TextAlign = HorizontalAlignment.Right;
            this.TextBox36.BackColor = Color.LightBlue;
            this.TextBox36.Location = new Point(0x10b, 0xa2);
            this.TextBox36.Name = "TextBox36";
            this.TextBox36.ReadOnly = true;
            this.TextBox36.Size = new Size(0x62, 20);
            this.TextBox36.TabIndex = 0x1d;
            this.TextBox36.Text = "2100 KHz";
            this.TextBox36.TextAlign = HorizontalAlignment.Right;
            this.TextBox35.BackColor = Color.LightBlue;
            this.TextBox35.Location = new Point(0xa3, 0xa3);
            this.TextBox35.Name = "TextBox35";
            this.TextBox35.ReadOnly = true;
            this.TextBox35.Size = new Size(0x62, 20);
            this.TextBox35.TabIndex = 0x1c;
            this.TextBox35.Text = "9 KHz";
            this.TextBox35.TextAlign = HorizontalAlignment.Right;
            this.TextBox34.BackColor = Color.White;
            this.TextBox34.Location = new Point(0x3b, 0xa3);
            this.TextBox34.Name = "TextBox34";
            this.TextBox34.Size = new Size(0x62, 20);
            this.TextBox34.TabIndex = 0x1b;
            this.TextBox34.Text = "Full Range";
            this.TextBox34.TextAlign = HorizontalAlignment.Right;
            this.TextBox33.BackColor = Color.LightBlue;
            this.TextBox33.Location = new Point(0x10b, 0x88);
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.ReadOnly = true;
            this.TextBox33.Size = new Size(0x62, 20);
            this.TextBox33.TabIndex = 0x1a;
            this.TextBox33.Text = "2100 KHz";
            this.TextBox33.TextAlign = HorizontalAlignment.Right;
            this.TextBox32.BackColor = Color.LightBlue;
            this.TextBox32.Location = new Point(0xa3, 0x89);
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.ReadOnly = true;
            this.TextBox32.Size = new Size(0x62, 20);
            this.TextBox32.TabIndex = 0x19;
            this.TextBox32.Text = "9 KHz";
            this.TextBox32.TextAlign = HorizontalAlignment.Right;
            this.TextBox31.BackColor = Color.White;
            this.TextBox31.Location = new Point(0x3b, 0x89);
            this.TextBox31.Name = "TextBox31";
            this.TextBox31.Size = new Size(0x62, 20);
            this.TextBox31.TabIndex = 0x18;
            this.TextBox31.Text = "Full Range";
            this.TextBox31.TextAlign = HorizontalAlignment.Right;
            this.TextBox30.BackColor = Color.LightBlue;
            this.TextBox30.Location = new Point(0x10b, 110);
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.ReadOnly = true;
            this.TextBox30.Size = new Size(0x62, 20);
            this.TextBox30.TabIndex = 0x17;
            this.TextBox30.Text = "2100 KHz";
            this.TextBox30.TextAlign = HorizontalAlignment.Right;
            this.TextBox29.BackColor = Color.LightBlue;
            this.TextBox29.Location = new Point(0xa3, 0x6f);
            this.TextBox29.Name = "TextBox29";
            this.TextBox29.ReadOnly = true;
            this.TextBox29.Size = new Size(0x62, 20);
            this.TextBox29.TabIndex = 0x16;
            this.TextBox29.Text = "9 KHz";
            this.TextBox29.TextAlign = HorizontalAlignment.Right;
            this.TextBox28.BackColor = Color.White;
            this.TextBox28.Location = new Point(0x3b, 0x6f);
            this.TextBox28.Name = "TextBox28";
            this.TextBox28.Size = new Size(0x62, 20);
            this.TextBox28.TabIndex = 0x15;
            this.TextBox28.Text = "Full Range";
            this.TextBox28.TextAlign = HorizontalAlignment.Right;
            this.TextBox27.BackColor = Color.LightBlue;
            this.TextBox27.Location = new Point(0x10b, 0x54);
            this.TextBox27.Name = "TextBox27";
            this.TextBox27.ReadOnly = true;
            this.TextBox27.Size = new Size(0x62, 20);
            this.TextBox27.TabIndex = 20;
            this.TextBox27.Text = "2100 KHz";
            this.TextBox27.TextAlign = HorizontalAlignment.Right;
            this.TextBox26.BackColor = Color.LightBlue;
            this.TextBox26.Location = new Point(0xa3, 0x55);
            this.TextBox26.Name = "TextBox26";
            this.TextBox26.ReadOnly = true;
            this.TextBox26.Size = new Size(0x62, 20);
            this.TextBox26.TabIndex = 0x13;
            this.TextBox26.Text = "9 KHz";
            this.TextBox26.TextAlign = HorizontalAlignment.Right;
            this.TextBox25.BackColor = Color.White;
            this.TextBox25.Location = new Point(0x3b, 0x55);
            this.TextBox25.Name = "TextBox25";
            this.TextBox25.Size = new Size(0x62, 20);
            this.TextBox25.TabIndex = 0x12;
            this.TextBox25.Text = "Full Range";
            this.TextBox25.TextAlign = HorizontalAlignment.Right;
            this.TextBox24.BackColor = Color.LightBlue;
            this.TextBox24.Location = new Point(0x10b, 0x3a);
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.ReadOnly = true;
            this.TextBox24.Size = new Size(0x62, 20);
            this.TextBox24.TabIndex = 0x11;
            this.TextBox24.Text = "2100 KHz";
            this.TextBox24.TextAlign = HorizontalAlignment.Right;
            this.TextBox23.BackColor = Color.LightBlue;
            this.TextBox23.Location = new Point(0xa3, 0x3b);
            this.TextBox23.Name = "TextBox23";
            this.TextBox23.ReadOnly = true;
            this.TextBox23.Size = new Size(0x62, 20);
            this.TextBox23.TabIndex = 0x10;
            this.TextBox23.Text = "9 KHz";
            this.TextBox23.TextAlign = HorizontalAlignment.Right;
            this.TextBox22.BackColor = Color.White;
            this.TextBox22.Location = new Point(0x3b, 0x3b);
            this.TextBox22.Name = "TextBox22";
            this.TextBox22.Size = new Size(0x62, 20);
            this.TextBox22.TabIndex = 15;
            this.TextBox22.Text = "Full Range";
            this.TextBox22.TextAlign = HorizontalAlignment.Right;
            this.TextBox21.BackColor = Color.LightBlue;
            this.TextBox21.Location = new Point(0x10b, 0x21);
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.ReadOnly = true;
            this.TextBox21.Size = new Size(0x62, 20);
            this.TextBox21.TabIndex = 14;
            this.TextBox21.Text = "2100 KHz";
            this.TextBox21.TextAlign = HorizontalAlignment.Right;
            this.TextBox20.BackColor = Color.LightBlue;
            this.TextBox20.Location = new Point(0xa3, 0x21);
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.ReadOnly = true;
            this.TextBox20.Size = new Size(0x62, 20);
            this.TextBox20.TabIndex = 13;
            this.TextBox20.Text = "9 KHz";
            this.TextBox20.TextAlign = HorizontalAlignment.Right;
            this.TextBox19.BackColor = Color.White;
            this.TextBox19.Location = new Point(0x3b, 0x21);
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Size = new Size(0x62, 20);
            this.TextBox19.TabIndex = 12;
            this.TextBox19.Text = "Full Range";
            this.TextBox19.TextAlign = HorizontalAlignment.Right;
            this.Label28.AutoSize = true;
            this.Label28.Location = new Point(0x108, 0x10);
            this.Label28.Name = "Label28";
            this.Label28.Size = new Size(0x35, 13);
            this.Label28.TabIndex = 11;
            this.Label28.Text = "End Freq.";
            this.Label27.AutoSize = true;
            this.Label27.Location = new Point(160, 0x10);
            this.Label27.Name = "Label27";
            this.Label27.Size = new Size(0x38, 13);
            this.Label27.TabIndex = 10;
            this.Label27.Text = "Start Freq.";
            this.TabPage3.Controls.Add(this.TextBox53);
            this.TabPage3.Controls.Add(this.TextBox54);
            this.TabPage3.Font = new Font("Microsoft Sans Serif", 0x18f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TabPage3.Location = new Point(4, 0x16);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new Size(0x449, 0x2cb);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "About";
            this.TabPage3.UseVisualStyleBackColor = true;
            this.TextBox53.Font = new Font("Courier New", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox53.Location = new Point(7, 0xcb);
            this.TextBox53.Multiline = true;
            this.TextBox53.Name = "TextBox53";
            this.TextBox53.ScrollBars = ScrollBars.Vertical;
            this.TextBox53.Size = new Size(0x43d, 0x1f7);
            this.TextBox53.TabIndex = 3;
            this.TextBox53.Text = manager.GetString("TextBox53.Text");
            this.TextBox54.Enabled = false;
            this.TextBox54.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.TextBox54.Location = new Point(7, 3);
            this.TextBox54.Multiline = true;
            this.TextBox54.Name = "TextBox54";
            this.TextBox54.Size = new Size(0x43d, 0xc2);
            this.TextBox54.TabIndex = 2;
            this.TextBox54.Text = "VMA Simple Spectrum Analyser\r\nfor Rohde & Schwarz CRTU\r\n\r\n\x00a92019 Vitor Martins Augusto\r\n\r\nContact: vma@norcam.pt\r\nVisit my blog: http://vma-satellite.blogspot.pt\r\n";
            this.TextBox54.TextAlign = HorizontalAlignment.Center;
            this.Timer2.Interval = 500;
            this.Timer5.Interval = 0x4_93e0;
            this.SerialPort1.BaudRate = 0x4b00;
            this.SerialPort1.DiscardNull = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x455, 0x2e5);
            base.Controls.Add(this.TabControl1);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "Form1";
            this.Text = "VMA Spectrum Analyser for Rohde & Schwarz CRTU";
            ((ISupportInitialize) this.PictureBox1).EndInit();
            ((ISupportInitialize) this.PictureBox2).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox11.ResumeLayout(false);
            this.GroupBox11.PerformLayout();
            this.GroupBox10.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage4.ResumeLayout(false);
            this.TabPage4.PerformLayout();
            this.TabPage5.ResumeLayout(false);
            this.TabPage5.PerformLayout();
            this.TabPage6.ResumeLayout(false);
            this.TabPage7.ResumeLayout(false);
            this.TabPage7.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabPage8.ResumeLayout(false);
            ((ISupportInitialize) this.PictureBox7).EndInit();
            ((ISupportInitialize) this.PictureBox8).EndInit();
            this.TabPage9.ResumeLayout(false);
            this.TabPage9.PerformLayout();
            ((ISupportInitialize) this.PictureBox5).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.GroupBox13.ResumeLayout(false);
            this.GroupBox13.PerformLayout();
            this.GroupBox18.ResumeLayout(false);
            this.GroupBox18.PerformLayout();
            this.GroupBox14.ResumeLayout(false);
            this.GroupBox14.PerformLayout();
            this.GroupBox15.ResumeLayout(false);
            this.GroupBox15.PerformLayout();
            this.GroupBox19.ResumeLayout(false);
            this.GroupBox19.PerformLayout();
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            ((ISupportInitialize) this.PictureBox6).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            base.ResumeLayout(false);
        }

        public void match_satellite()
        {
            float[] source = new float[0x3e9];
            int index = 0;
            int num2 = 0;
            this.sensitivity = (int) Math.Round(Conversion.Val(this.Label95.Text));
            int num4 = this.trans_count - 1;
            index = 0;
            while (index <= num4)
            {
                num2 = (int) Math.Round((double) this.trace[this.transponder[index], 0]);
                int num5 = this.total_satellite;
                int num6 = 0;
                while (true)
                {
                    if (num6 > num5)
                    {
                        index++;
                        break;
                    }
                    double num7 = Conversion.Val(this.transponder_list[1, num6]);
                    double a = 2.0;
                    while (true)
                    {
                        if (a > num7)
                        {
                            num6++;
                            break;
                        }
                        if (((Conversion.Val(this.transponder_list[(int) Math.Round(a), num6]) - this.sensitivity) <= num2) & (num2 <= (Conversion.Val(this.transponder_list[(int) Math.Round(a), num6]) + this.sensitivity)))
                        {
                            source[num6]++;
                        }
                        a++;
                    }
                }
            }
            int num3 = (int) Math.Round((double) source.Max());
            this.satellite_found = "";
            if (num3 <= 0)
            {
                this.satellite_id = 0;
                this.satellite_found = "No satellite match";
            }
            else
            {
                int num9 = this.total_satellite;
                for (index = 1; index <= num9; index++)
                {
                    if (source[index] == num3)
                    {
                        this.satellite_id = index;
                        string[] textArray1 = new string[] { this.satellite_found, "\r\n", this.transponder_list[0, index], " - ", Strings.Replace(Strings.Format((((double) num3) / ((double) this.trans_count)) * 100.0, "##"), ", ", ".", 1, -1, CompareMethod.Binary), "%" };
                        this.satellite_found = string.Concat(textArray1);
                    }
                }
            }
        }

        private float MHzToHz(string mhz)
        {
            float num = 0f;
            if (Strings.InStr(mhz, " MHz", CompareMethod.Binary) > 1)
            {
                num = (float) (Conversion.Val(mhz) * 0xf_4240);
            }
            if (Strings.InStr(mhz, " KHz", CompareMethod.Binary) > 1)
            {
                num = (float) (Conversion.Val(mhz) * 0x3e8);
            }
            if (Strings.InStr(mhz, " Hz", CompareMethod.Binary) > 1)
            {
                num = (float) Conversion.Val(mhz);
            }
            return num;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.swr_marker[this.swr_count] = Conversions.ToInteger(e.X.ToString());
                this.swr_count = (byte) (this.swr_count + 1);
                if (this.swr_count > 9)
                {
                    this.swr_count = 0;
                }
            }
            else if (this.marker == 0)
            {
                this.marker = 1;
                this.marker1 = e.X;
            }
            else
            {
                this.marker = 0;
                this.marker2 = e.X;
            }
        }

        private void PictureBox1_MouseMove1(object sender, MouseEventArgs e)
        {
            float x = e.X;
            float num = this.MHzToHz(this.TextBox3.Text);
            float num2 = this.MHzToHz(this.TextBox4.Text);
            if (Conversion.Val(this.TextBox55.Text) < 0.0)
            {
                this.TextBox57.Text = this.HzToMHz(Conversions.ToString((double) (((((num2 - num) * (560f - x)) / 560f) + num) + Conversion.Val(this.TextBox55.Text))));
            }
            else
            {
                this.TextBox57.Text = this.HzToMHz(Conversions.ToString((double) (((((num2 - num) * x) / 560f) + num) + Conversion.Val(this.TextBox55.Text))));
            }
        }

        private void PictureBox8_MouseMove1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.mouse_y_up == -1)
                {
                    this.mouse_x_up = e.X;
                    this.mouse_y_up = e.Y;
                }
                this.grafico3.DrawLine(this.cor_trigger_blue, this.mouse_x_up, this.mouse_y_up, e.X, e.Y);
                this.mouse_x_up = e.X;
                this.mouse_y_up = e.Y;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (this.mouse_y_down == -1)
                {
                    this.mouse_x_down = e.X;
                    this.mouse_y_down = e.Y;
                }
                this.grafico3.DrawLine(this.cor_trigger_red, this.mouse_x_down, this.mouse_y_down, e.X, e.Y);
                this.mouse_x_down = e.X;
                this.mouse_y_down = e.Y;
            }
            if (e.Button == MouseButtons.Middle)
            {
                this.mouse_y_down = -1;
                this.mouse_y_up = -1;
            }
            this.PictureBox8.Image = this.bmp3;
        }

        public void preset_buttons()
        {
            string str;
            string str5 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset2", null));
            string str9 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset3", null));
            string str13 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset4", null));
            string str17 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset5", null));
            string str21 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset6", null));
            string str25 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset7", null));
            string str29 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset8", null));
            string str33 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset9", null));
            string str2 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F1S", null));
            string str6 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F2S", null));
            string str10 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F3S", null));
            string str14 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F4S", null));
            string str18 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F5S", null));
            string str22 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F6S", null));
            string str26 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F7S", null));
            string str30 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F8S", null));
            string str34 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F9S", null));
            string str3 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F1E", null));
            string str7 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F2E", null));
            string str11 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F3E", null));
            string str15 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F4E", null));
            string str19 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F5E", null));
            string str23 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F6E", null));
            string str27 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F7E", null));
            string str31 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F8E", null));
            string str35 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "F9E", null));
            string str4 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF1", null));
            string str8 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF2", null));
            string str12 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF3", null));
            string str16 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF4", null));
            string str20 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF5", null));
            string str24 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF6", null));
            string str28 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF7", null));
            string str32 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF8", null));
            string str36 = Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "LOF9", null));
            if (Conversions.ToString(MyProject.Computer.Registry.GetValue(@"HKEY_CURRENT_USER\Software\VMA Simple Spectrum Analyser for CRTU", "preset1", null)) == "")
            {
                str = "Full Range";
            }
            if (str5 == "")
            {
                str5 = "Full Range";
            }
            if (str9 == "")
            {
                str9 = "Full Range";
            }
            if (str13 == "")
            {
                str13 = "Full Range";
            }
            if (str17 == "")
            {
                str17 = "Full Range";
            }
            if (str21 == "")
            {
                str21 = "Full Range";
            }
            if (str25 == "")
            {
                str25 = "Full Range";
            }
            if (str29 == "")
            {
                str29 = "Full Range";
            }
            if (str33 == "")
            {
                str33 = "Full Range";
            }
            if (str2 == "")
            {
                str2 = this.min_freq;
            }
            if (str6 == "")
            {
                str6 = this.min_freq;
            }
            if (str10 == "")
            {
                str10 = this.min_freq;
            }
            if (str14 == "")
            {
                str14 = this.min_freq;
            }
            if (str18 == "")
            {
                str18 = this.min_freq;
            }
            if (str22 == "")
            {
                str22 = this.min_freq;
            }
            if (str26 == "")
            {
                str26 = this.min_freq;
            }
            if (str30 == "")
            {
                str30 = this.min_freq;
            }
            if (str34 == "")
            {
                str34 = this.min_freq;
            }
            if (str3 == "")
            {
                str3 = this.max_freq;
            }
            if (str7 == "")
            {
                str7 = this.max_freq;
            }
            if (str11 == "")
            {
                str11 = this.max_freq;
            }
            if (str15 == "")
            {
                str15 = this.max_freq;
            }
            if (str19 == "")
            {
                str19 = this.max_freq;
            }
            if (str23 == "")
            {
                str23 = this.max_freq;
            }
            if (str27 == "")
            {
                str27 = this.max_freq;
            }
            if (str31 == "")
            {
                str31 = this.max_freq;
            }
            if (str35 == "")
            {
                str35 = this.max_freq;
            }
            if (str4 == "")
            {
                str4 = "0 MHz";
            }
            if (str8 == "")
            {
                str8 = "0 MHz";
            }
            if (str12 == "")
            {
                str12 = "0 MHz";
            }
            if (str16 == "")
            {
                str16 = "0 MHz";
            }
            if (str20 == "")
            {
                str20 = "0 MHz";
            }
            if (str24 == "")
            {
                str24 = "0 MHz";
            }
            if (str28 == "")
            {
                str28 = "0 MHz";
            }
            if (str32 == "")
            {
                str32 = "0 MHz";
            }
            if (str36 == "")
            {
                str36 = "0 MHz";
            }
            this.Button1.Text = str;
            this.Button9.Text = str5;
            this.Button10.Text = str9;
            this.Button11.Text = str13;
            this.Button12.Text = str17;
            this.Button13.Text = str21;
            this.Button14.Text = str25;
            this.Button15.Text = str29;
            this.Button16.Text = str33;
            this.TextBox19.Text = str;
            this.TextBox22.Text = str5;
            this.TextBox25.Text = str9;
            this.TextBox28.Text = str13;
            this.TextBox31.Text = str17;
            this.TextBox34.Text = str21;
            this.TextBox37.Text = str25;
            this.TextBox40.Text = str29;
            this.TextBox43.Text = str33;
            this.TextBox20.Text = str2;
            this.TextBox23.Text = str6;
            this.TextBox26.Text = str10;
            this.TextBox29.Text = str14;
            this.TextBox32.Text = str18;
            this.TextBox35.Text = str22;
            this.TextBox38.Text = str26;
            this.TextBox41.Text = str30;
            this.TextBox44.Text = str34;
            this.TextBox21.Text = str3;
            this.TextBox24.Text = str7;
            this.TextBox27.Text = str11;
            this.TextBox30.Text = str15;
            this.TextBox33.Text = str19;
            this.TextBox36.Text = str23;
            this.TextBox39.Text = str27;
            this.TextBox42.Text = str31;
            this.TextBox45.Text = str35;
            this.TextBox7.Text = str4;
            this.TextBox8.Text = str8;
            this.TextBox9.Text = str12;
            this.TextBox47.Text = str16;
            this.TextBox48.Text = str20;
            this.TextBox49.Text = str24;
            this.TextBox50.Text = str28;
            this.TextBox51.Text = str32;
            this.TextBox52.Text = str36;
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {
            this.rx_changed = true;
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            this.rx_changed = true;
        }

        private void RadioButton3_Click(object sender, EventArgs e)
        {
            this.rx_changed = true;
        }

        private void RadioButton4_Click(object sender, EventArgs e)
        {
            this.tx_changed = true;
        }

        private void RadioButton5_Click(object sender, EventArgs e)
        {
            this.tx_changed = true;
        }

        private void RadioButton6_Click(object sender, EventArgs e)
        {
            this.tx_changed = true;
        }

        public void read_transponder_lists()
        {
            int[] numArray1 = new int[0x3e9];
            string str = "";
            int num = 0;
            string str2 = "";
            float num10 = 0f;
            string str3 = "";
            int num11 = (int) Math.Round(Conversion.Val(this.TextBox78.Text));
            int num12 = (int) Math.Round(Conversion.Val(this.TextBox77.Text));
            FileInfo[] files = new DirectoryInfo(Application.StartupPath + @"\transponder_lists\").GetFiles();
            int index = 0;
            while (index < files.Length)
            {
                FileInfo info = files[index];
                StreamReader reader = new StreamReader(Application.StartupPath + @"\transponder_lists\" + info.ToString());
                while (true)
                {
                    if (str == "[SATTYPE]")
                    {
                        num10 = (float) Conversion.Val(Strings.Mid(reader.ReadLine(), 3));
                        str3 = (num10 >= 0x708f) ? ("(" + Strings.Replace(Strings.Trim(Strings.Format(360f - (num10 / 10f), ".0")), ",", ".", 1, -1, CompareMethod.Binary) + "W) - ") : ("(" + Strings.Replace(Strings.Trim(Strings.Format(num10 / 10f, ".0")), ", ", ".", 1, -1, CompareMethod.Binary) + "E) - ");
                        str = Strings.Mid(reader.ReadLine(), 3);
                        this.transponder_list[0, num] = str + str3 + " VL - Ku Band";
                        this.transponder_list[0, num + 1] = str + str3 + " HL - Ku Band";
                        this.transponder_list[0, num + 2] = str + str3 + " VH - Ku Band";
                        this.transponder_list[0, num + 3] = str + str3 + " HH - Ku Band";
                        this.transponder_list[0, num + 4] = str + str3 + " V - C Band";
                        this.transponder_list[0, num + 5] = str + str3 + " H - C Band";
                        this.transponder_list[0, num + 6] = str + str3 + " R - C Band";
                        this.transponder_list[0, num + 7] = str + str3 + " L - C Band";
                        while (true)
                        {
                            if (str == "[DVB]")
                            {
                                int number = 2;
                                int num3 = 2;
                                int num4 = 2;
                                int num5 = 2;
                                int num6 = 2;
                                int num7 = 2;
                                int num8 = 2;
                                int num9 = 2;
                                int num14 = (int) Math.Round(Conversion.Val(Strings.Mid(reader.ReadLine(), 3)));
                                int num15 = 1;
                                while (true)
                                {
                                    if (num15 > num14)
                                    {
                                        this.transponder_list[1, num] = Conversion.Str(number);
                                        this.transponder_list[1, num + 1] = Conversion.Str(num3);
                                        this.transponder_list[1, num + 2] = Conversion.Str(num4);
                                        this.transponder_list[1, num + 3] = Conversion.Str(num5);
                                        this.transponder_list[1, num + 4] = Conversion.Str(num6);
                                        this.transponder_list[1, num + 5] = Conversion.Str(num7);
                                        this.transponder_list[1, num + 6] = Conversion.Str(num8);
                                        this.transponder_list[1, num + 7] = Conversion.Str(num9);
                                        num += 8;
                                        index++;
                                        break;
                                    }
                                    str = reader.ReadLine();
                                    str2 = Strings.Mid(str, Strings.InStr(str, ",", CompareMethod.Binary) + 1);
                                    if (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) > 0x29cc)
                                    {
                                        if (Conversion.Val(Strings.Mid(str2, Strings.InStr(str2, ",", CompareMethod.Binary) + 1)) >= num11)
                                        {
                                            if ((Strings.InStr(str, ",V,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) < 0x2db4))
                                            {
                                                this.transponder_list[number, num] = Conversion.Str(Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) - 0x2616);
                                                number++;
                                            }
                                            else if ((Strings.InStr(str, ",H,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) < 0x2db4))
                                            {
                                                this.transponder_list[num3, num + 1] = Conversion.Str(Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) - 0x2616);
                                                num3++;
                                            }
                                            else if ((Strings.InStr(str, ",V,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) >= 0x2db4))
                                            {
                                                this.transponder_list[num4, num + 2] = Conversion.Str(Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) - 0x2968);
                                                num4++;
                                            }
                                            else if ((Strings.InStr(str, ",H,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) >= 0x2db4))
                                            {
                                                this.transponder_list[num5, num + 3] = Conversion.Str(Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) - 0x2968);
                                                num5++;
                                            }
                                        }
                                    }
                                    else if (Conversion.Val(Strings.Mid(str2, Strings.InStr(str2, ",", CompareMethod.Binary) + 1)) >= num12)
                                    {
                                        if (Strings.InStr(str, ",V,", CompareMethod.Binary) > 0)
                                        {
                                            this.transponder_list[num6, num + 4] = Conversion.Str(Math.Abs((double) (0x141e - Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)))));
                                            num6++;
                                        }
                                        else if ((Strings.InStr(str, ",H,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) < 0x2db4))
                                        {
                                            this.transponder_list[num7, num + 5] = Conversion.Str(Math.Abs((double) (0x141e - Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)))));
                                            num7++;
                                        }
                                        else if ((Strings.InStr(str, ",R,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) < 0x2db4))
                                        {
                                            this.transponder_list[num8, num + 6] = Conversion.Str(Math.Abs((double) (0x141e - Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)))));
                                            num8++;
                                        }
                                        else if ((Strings.InStr(str, ",L,", CompareMethod.Binary) > 0) & (Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)) < 0x2db4))
                                        {
                                            this.transponder_list[num9, num + 7] = Conversion.Str(Math.Abs((double) (0x141e - Conversion.Val(Strings.Mid(str, Strings.InStr(str, "=", CompareMethod.Binary) + 1)))));
                                            num9++;
                                        }
                                    }
                                    num15++;
                                }
                                break;
                            }
                            str = reader.ReadLine();
                        }
                        break;
                    }
                    str = reader.ReadLine();
                }
            }
            this.total_satellite = num;
        }

        public void reset_traces()
        {
            int num = 0;
            while (true)
            {
                this.trace[num, 2] = float.NegativeInfinity;
                this.trace[num, 3] = float.PositiveInfinity;
                this.trace[num, 4] = 0f;
                num++;
                if (num > 560)
                {
                    this.avg = 0;
                    return;
                }
            }
        }

        public void send_alarm_mail(string alarm_message)
        {
            // Invalid method body.
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Invalid method body.
        }

        public void Spectrum()
        {
            bool flag = false;
            string inputStr = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            if (this.start)
            {
                this.rm = new ResourceManagerClass();
                this.ioobj = new FormattedIO488Class();
                try
                {
                    while (true)
                    {
                        if (!this.start)
                        {
                            this.ioobj.WriteString(this.TextBox6.Text + ";*GTL", true);
                            break;
                        }
                        int index = -1;
                        string str6 = Conversions.ToString(this.MHzToHz(this.TextBox3.Text));
                        string str7 = Conversions.ToString(this.MHzToHz(this.TextBox4.Text));
                        string str8 = Conversions.ToString(this.MHzToHz(this.TextBox5.Text));
                        this.ioobj.set_IO((IMessage) this.rm.Open(this.TextBox56.Text, 0, 0x7d0, ""));
                        if (!this.TG)
                        {
                            if (flag)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";ABORt:RFGenerator:TX", true);
                            }
                            flag = false;
                        }
                        else if (flag)
                        {
                            this.ioobj.WriteString(this.TextBox6.Text + ";SOURce:RFGenerator:TX:FREQuency " + inputStr, true);
                            if (Conversion.Val(Strings.Trim(Conversion.Str(Conversion.Val(inputStr) + Conversion.Val(str2)))) > Conversion.Val(str7))
                            {
                                inputStr = str6;
                            }
                        }
                        else
                        {
                            flag = true;
                            inputStr = str6;
                            str2 = Strings.Trim(Conversion.Str((Conversion.Val(str7) - Conversion.Val(str6)) / 500.0));
                            if (this.RadioButton4.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT RF1", true);
                            }
                            if (this.RadioButton5.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT RF2", true);
                            }
                            if (this.RadioButton6.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT RF3", true);
                            }
                            this.ioobj.WriteString(this.TextBox6.Text + ";SOURce:RFGenerator:TX:FREQuency " + inputStr, true);
                            this.ioobj.WriteString(this.TextBox6.Text + ";INITiate:RFGenerator:TX", true);
                        }
                        if (this.rx_changed)
                        {
                            this.rx_changed = false;
                            if (this.RadioButton1.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";INPUT RF1", true);
                            }
                            if (this.RadioButton2.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";INPUT RF2", true);
                            }
                            if (this.RadioButton3.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";INPUT RF4", true);
                            }
                        }
                        if (this.tx_changed)
                        {
                            this.tx_changed = false;
                            if (this.RadioButton4.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT RF1", true);
                            }
                            if (this.RadioButton5.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT RF2", true);
                            }
                            if (this.RadioButton6.Checked)
                            {
                                this.ioobj.WriteString(this.TextBox6.Text + ";OUTPUT RF3", true);
                            }
                        }
                        if (((str6 != str3) | (str7 != str4)) | (str8 != str5))
                        {
                            this.ioobj.WriteString(this.TextBox6.Text + ";SPECtrum:FREQuency:STARt " + str6, true);
                            this.ioobj.WriteString(this.TextBox6.Text + ";SPECtrum:FREQuency:STOP " + str7, true);
                            this.ioobj.WriteString(this.TextBox6.Text + ";SPECtrum:FREQuency:BANDwidth " + str8, true);
                            this.ioobj.WriteString(this.TextBox6.Text + ";INITIATE:SPECtrum", true);
                        }
                        str3 = str6;
                        str4 = str7;
                        str5 = str8;
                        this.ioobj.WriteString(this.TextBox6.Text + ";READ:ARRAY:SPECTRUM:CURRENT?", true);
                        this.idnItems = (object[]) this.ioobj.ReadList(12, ",");
                        object[] idnItems = this.idnItems;
                        int num2 = 0;
                        while (true)
                        {
                            if (num2 >= idnItems.Length)
                            {
                                Application.DoEvents();
                                this.Draw_Spectrum();
                                break;
                            }
                            this.idnItem = idnItems[num2];
                            index++;
                            this.dump2[index] = this.idnItem.ToString();
                            num2++;
                        }
                    }
                }
                catch (Exception exception1)
                {
                    Exception ex = exception1;
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    Debug.Print("An error occurred: " + exception.Message);
                    ProjectData.ClearProjectError();
                }
                finally
                {
                    try
                    {
                        this.ioobj.get_IO().Close();
                    }
                    catch (Exception exception5)
                    {
                        Exception ex = exception5;
                        ProjectData.SetProjectError(ex);
                        Exception exception2 = ex;
                        ProjectData.ClearProjectError();
                    }
                    goto TR_0008;
                TR_0005:
                    try
                    {
                        Marshal.ReleaseComObject(this.rm);
                    }
                    catch (Exception exception7)
                    {
                        Exception ex = exception7;
                        ProjectData.SetProjectError(ex);
                        Exception exception4 = ex;
                        ProjectData.ClearProjectError();
                    }
                TR_0008:
                    try
                    {
                        Marshal.ReleaseComObject(this.ioobj);
                    }
                    catch (Exception exception6)
                    {
                        Exception ex = exception6;
                        ProjectData.SetProjectError(ex);
                        Exception exception3 = ex;
                        ProjectData.ClearProjectError();
                    }
                    goto TR_0005;
                }
            }
        }

        public void spectrum_playback()
        {
            StreamReader reader = new StreamReader(this.play_filename);
            while (this.play)
            {
                Application.DoEvents();
                Conversions.ToString(Conversion.Val(reader.ReadLine()));
                this.Label71.Text = reader.ReadLine();
                this.Label72.Text = reader.ReadLine();
                this.TextBox3.Text = reader.ReadLine();
                this.TextBox4.Text = reader.ReadLine();
                this.TextBox5.Text = reader.ReadLine();
                this.TextBox11.Text = reader.ReadLine();
                this.TextBox12.Text = reader.ReadLine();
                Application.DoEvents();
                int num = 0;
                while (true)
                {
                    Conversions.ToString(Conversion.Val(reader.ReadLine()));
                    this.trace[num, 0] = (float) Conversion.Val(reader.ReadLine());
                    this.trace[num, 1] = (float) Conversion.Val(reader.ReadLine());
                    num++;
                    if (num > 0x22e)
                    {
                        this.Draw_Spectrum();
                        Thread.Sleep((int) ((100 - this.HScrollBar1.Value) * 2));
                        if (reader.EndOfStream)
                        {
                            reader.Close();
                            this.spectrum_playback();
                        }
                        break;
                    }
                }
            }
        }

        private void TextBox11_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox11.Text = this.convert_freq(text);
                this.TextBox3.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) - (0.5 * this.MHzToHz(this.TextBox12.Text)))));
                if (this.MHzToHz(this.TextBox3.Text) < this.MHzToHz(this.min_freq))
                {
                    this.TextBox3.Text = this.min_freq;
                    this.TextBox4.Text = this.HzToMHz(Conversions.ToString((float) ((2f * this.MHzToHz(this.TextBox11.Text)) - this.MHzToHz(this.TextBox3.Text))));
                    this.TextBox12.Text = this.HzToMHz(Conversions.ToString((float) (this.MHzToHz(this.TextBox4.Text) - this.MHzToHz(this.TextBox3.Text))));
                }
                else
                {
                    this.TextBox4.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) + (0.5 * this.MHzToHz(this.TextBox12.Text)))));
                    if (this.MHzToHz(this.TextBox4.Text) > this.MHzToHz(this.max_freq))
                    {
                        this.TextBox4.Text = this.max_freq;
                    }
                    this.TextBox3.Text = this.HzToMHz(Conversions.ToString((float) (this.MHzToHz(this.TextBox11.Text) - (this.MHzToHz(this.TextBox4.Text) - this.MHzToHz(this.TextBox11.Text)))));
                    this.TextBox12.Text = this.HzToMHz(Conversions.ToString((float) (this.MHzToHz(this.TextBox4.Text) - this.MHzToHz(this.TextBox3.Text))));
                }
            }
        }

        private void TextBox12_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox12.Text = this.convert_freq(text);
                this.TextBox3.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) - (0.5 * this.MHzToHz(this.TextBox12.Text)))));
                if (this.MHzToHz(this.TextBox3.Text) < this.MHzToHz(this.min_freq))
                {
                    this.TextBox3.Text = this.min_freq;
                }
                this.TextBox4.Text = this.HzToMHz(Conversions.ToString((double) (this.MHzToHz(this.TextBox11.Text) + (0.5 * this.MHzToHz(this.TextBox12.Text)))));
                if (this.MHzToHz(this.TextBox4.Text) > this.MHzToHz(this.max_freq))
                {
                    this.TextBox4.Text = this.max_freq;
                }
            }
        }

        private void TextBox20_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox20.Text = this.convert_freq(text);
            }
        }

        private void TextBox21_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox21.Text = this.convert_freq(text);
            }
        }

        private void TextBox23_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox23.Text = this.convert_freq(text);
            }
        }

        private void TextBox24_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox24.Text = this.convert_freq(text);
            }
        }

        private void TextBox26_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox26.Text = this.convert_freq(text);
            }
        }

        private void TextBox27_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox27.Text = this.convert_freq(text);
            }
        }

        private void TextBox29_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox29.Text = this.convert_freq(text);
            }
        }

        private void TextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox3.Text = this.convert_freq(text);
            }
            this.update_centre_frequency();
            this.update_span();
        }

        private void TextBox30_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox30.Text = this.convert_freq(text);
            }
        }

        private void TextBox32_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox32.Text = this.convert_freq(text);
            }
        }

        private void TextBox33_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox33.Text = this.convert_freq(text);
            }
        }

        private void TextBox35_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox35.Text = this.convert_freq(text);
            }
        }

        private void TextBox36_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox36.Text = this.convert_freq(text);
            }
        }

        private void TextBox38_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox38.Text = this.convert_freq(text);
            }
        }

        private void TextBox39_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox39.Text = this.convert_freq(text);
            }
        }

        private void TextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox4.Text = this.convert_freq(text);
            }
            this.update_centre_frequency();
            this.update_span();
        }

        private void TextBox41_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox41.Text = this.convert_freq(text);
            }
        }

        private void TextBox42_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox42.Text = this.convert_freq(text);
            }
        }

        private void TextBox44_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox44.Text = this.convert_freq(text);
            }
        }

        private void TextBox45_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox45.Text = this.convert_freq(text);
            }
        }

        private void TextBox46_TextChanged(object sender, EventArgs e)
        {
            if (Conversion.Val(this.TextBox46.Text) > 0x2710)
            {
                this.TextBox46.Text = "10000";
            }
            if (Conversion.Val(this.TextBox46.Text) < 1.0)
            {
                this.TextBox46.Text = "1";
            }
        }

        private void TextBox47_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox47.Text = this.convert_freq(text);
            }
        }

        private void TextBox48_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox48.Text = this.convert_freq(text);
            }
        }

        private void TextBox49_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox49.Text = this.convert_freq(text);
            }
        }

        private void TextBox5_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox5.Text = this.convert_freq(text);
                this.rm = new ResourceManagerClass();
                this.ioobj = new FormattedIO488Class();
                string str2 = Conversions.ToString(this.MHzToHz(this.TextBox5.Text));
                this.ioobj.set_IO((IMessage) this.rm.Open(this.TextBox56.Text, 0, 0x7d0, ""));
                this.ioobj.WriteString(this.TextBox6.Text + ";SPECtrum:FREQuency:BANDwidth " + str2, true);
                this.ioobj.get_IO().Close();
            }
        }

        private void TextBox50_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox50.Text = this.convert_freq(text);
            }
        }

        private void TextBox51_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox51.Text = this.convert_freq(text);
            }
        }

        private void TextBox52_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox52.Text = this.convert_freq(text);
            }
        }

        private void TextBox55_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox55.Text = this.convert_freq(text);
            }
        }

        private void TextBox7_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox7.Text = this.convert_freq(text);
            }
        }

        private void TextBox8_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox8.Text = this.convert_freq(text);
            }
        }

        private void TextBox82_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.Button15.Visible = true;
            MyProject.Forms.Form3.ShowDialog();
            string text = this.TextBox82.Text;
            string str2 = MyProject.Forms.Form3.Label1.Text;
            if (str2 != "CANCEL")
            {
                if (Strings.InStr(str2, " MHz", CompareMethod.Binary) > 0)
                {
                    this.TextBox82.Text = Strings.Replace(Strings.Format(Conversion.Val(str2), "0.000"), ",", ".", 1, -1, CompareMethod.Binary) + " MHz";
                }
                else if (Strings.InStr(str2, " KHz", CompareMethod.Binary) > 0)
                {
                    this.TextBox82.Text = Strings.Replace(Strings.Format(Conversion.Val(str2) / 0x3e8, "0.000"), ",", ".", 1, -1, CompareMethod.Binary) + " KHz";
                }
                else if (Strings.InStr(str2, " Hz", CompareMethod.Binary) > 0)
                {
                    this.TextBox82.Text = Strings.Replace(Strings.Format(Conversion.Val(str2) / 0xf_4240, "0.000"), ",", ".", 1, -1, CompareMethod.Binary) + " Hz";
                }
            }
            if ((this.MHzToHz(this.TextBox82.Text) == 0f) | (this.MHzToHz(this.TextBox82.Text) > this.MHzToHz(this.TextBox12.Text)))
            {
                this.TextBox82.Text = text;
            }
            MyProject.Forms.Form3.Button15.Visible = false;
        }

        private void TextBox9_MouseClick(object sender, MouseEventArgs e)
        {
            MyProject.Forms.Form3.ShowDialog();
            string text = MyProject.Forms.Form3.Label1.Text;
            if (text != "CANCEL")
            {
                this.TextBox9.Text = this.convert_freq(text);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Timer1.Enabled = false;
            this.Timer1.Enabled = true;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            this.TextBox69.Text = Strings.Replace(Strings.Format(Conversion.Val(this.gps_data[0, 0]), ".00000"), ",", ".", 1, -1, CompareMethod.Binary);
            this.TextBox70.Text = Strings.Replace(Strings.Format(Conversion.Val(this.gps_data[0, 1]), ".00000"), ",", ".", 1, -1, CompareMethod.Binary);
            this.Label71.Text = this.TextBox69.Text;
            this.Label72.Text = this.TextBox70.Text;
            this.Label75.Text = this.gps_debug;
        }

        private void Timer5_Tick(object sender, EventArgs e)
        {
            this.alarm_timeout = false;
            this.Timer5.Enabled = false;
        }

        public void update_centre_frequency()
        {
            this.TextBox11.Text = this.HzToMHz(Conversions.ToString((double) ((Conversions.ToDouble(Conversion.Str(this.MHzToHz(this.TextBox4.Text) - this.MHzToHz(this.TextBox3.Text))) / 2.0) + this.MHzToHz(this.TextBox3.Text))));
        }

        public void update_span()
        {
            this.TextBox12.Text = this.HzToMHz(Conversion.Str(this.MHzToHz(this.TextBox4.Text) - this.MHzToHz(this.TextBox3.Text)));
        }

        [field: AccessedThroughProperty("PictureBox1")]
        internal virtual PictureBox PictureBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("PictureBox2")]
        internal virtual PictureBox PictureBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox1")]
        internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox2")]
        internal virtual TextBox TextBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button3")]
        internal virtual Button Button3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label3")]
        internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox5")]
        internal virtual TextBox TextBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox1")]
        internal virtual CheckBox CheckBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabControl1")]
        internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage1")]
        internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage2")]
        internal virtual TabPage TabPage2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage3")]
        internal virtual TabPage TabPage3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox1")]
        internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label2")]
        internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label1")]
        internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox4")]
        internal virtual TextBox TextBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox3")]
        internal virtual TextBox TextBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button6")]
        internal virtual Button Button6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button5")]
        internal virtual Button Button5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button4")]
        internal virtual Button Button4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button2")]
        internal virtual Button Button2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label5")]
        internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label13")]
        internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox12")]
        internal virtual TextBox TextBox12 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label6")]
        internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox11")]
        internal virtual TextBox TextBox11 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox5")]
        internal virtual GroupBox GroupBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button17")]
        internal virtual Button Button17 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button16")]
        internal virtual Button Button16 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button15")]
        internal virtual Button Button15 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button14")]
        internal virtual Button Button14 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button13")]
        internal virtual Button Button13 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button12")]
        internal virtual Button Button12 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button11")]
        internal virtual Button Button11 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button10")]
        internal virtual Button Button10 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button9")]
        internal virtual Button Button9 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button1")]
        internal virtual Button Button1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox6")]
        internal virtual GroupBox GroupBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label14")]
        internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox13")]
        internal virtual TextBox TextBox13 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label15")]
        internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox14")]
        internal virtual TextBox TextBox14 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox16")]
        internal virtual TextBox TextBox16 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox15")]
        internal virtual TextBox TextBox15 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox17")]
        internal virtual TextBox TextBox17 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label16")]
        internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox18")]
        internal virtual TextBox TextBox18 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox8")]
        internal virtual GroupBox GroupBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button33")]
        internal virtual Button Button33 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button34")]
        internal virtual Button Button34 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button35")]
        internal virtual Button Button35 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox7")]
        internal virtual GroupBox GroupBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button32")]
        internal virtual Button Button32 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button31")]
        internal virtual Button Button31 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button30")]
        internal virtual Button Button30 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button29")]
        internal virtual Button Button29 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button28")]
        internal virtual Button Button28 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button27")]
        internal virtual Button Button27 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button26")]
        internal virtual Button Button26 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button25")]
        internal virtual Button Button25 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button24")]
        internal virtual Button Button24 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button23")]
        internal virtual Button Button23 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button22")]
        internal virtual Button Button22 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button21")]
        internal virtual Button Button21 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button20")]
        internal virtual Button Button20 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button19")]
        internal virtual Button Button19 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button18")]
        internal virtual Button Button18 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox9")]
        internal virtual GroupBox GroupBox9 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label26")]
        internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox45")]
        internal virtual TextBox TextBox45 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label17")]
        internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label18")]
        internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox44")]
        internal virtual TextBox TextBox44 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label19")]
        internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox43")]
        internal virtual TextBox TextBox43 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label20")]
        internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox42")]
        internal virtual TextBox TextBox42 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label21")]
        internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox41")]
        internal virtual TextBox TextBox41 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label22")]
        internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox40")]
        internal virtual TextBox TextBox40 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label23")]
        internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox39")]
        internal virtual TextBox TextBox39 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label24")]
        internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox38")]
        internal virtual TextBox TextBox38 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label25")]
        internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox37")]
        internal virtual TextBox TextBox37 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox36")]
        internal virtual TextBox TextBox36 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox35")]
        internal virtual TextBox TextBox35 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox34")]
        internal virtual TextBox TextBox34 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox33")]
        internal virtual TextBox TextBox33 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox32")]
        internal virtual TextBox TextBox32 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox31")]
        internal virtual TextBox TextBox31 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox30")]
        internal virtual TextBox TextBox30 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox29")]
        internal virtual TextBox TextBox29 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox28")]
        internal virtual TextBox TextBox28 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox27")]
        internal virtual TextBox TextBox27 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox26")]
        internal virtual TextBox TextBox26 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox25")]
        internal virtual TextBox TextBox25 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox24")]
        internal virtual TextBox TextBox24 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox23")]
        internal virtual TextBox TextBox23 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox22")]
        internal virtual TextBox TextBox22 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox21")]
        internal virtual TextBox TextBox21 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox20")]
        internal virtual TextBox TextBox20 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox19")]
        internal virtual TextBox TextBox19 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label28")]
        internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label27")]
        internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label29")]
        internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox46")]
        internal virtual TextBox TextBox46 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox11")]
        internal virtual GroupBox GroupBox11 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label32")]
        internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label31")]
        internal virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label30")]
        internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("HScrollBar1")]
        internal virtual HScrollBar HScrollBar1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button37")]
        internal virtual Button Button37 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button36")]
        internal virtual Button Button36 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox10")]
        internal virtual GroupBox GroupBox10 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabControl2")]
        internal virtual TabControl TabControl2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage4")]
        internal virtual TabPage TabPage4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage5")]
        internal virtual TabPage TabPage5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage6")]
        internal virtual TabPage TabPage6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage7")]
        internal virtual TabPage TabPage7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button41")]
        internal virtual Button Button41 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button40")]
        internal virtual Button Button40 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button42")]
        internal virtual Button Button42 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button43")]
        internal virtual Button Button43 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button45")]
        internal virtual Button Button45 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button44")]
        internal virtual Button Button44 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button47")]
        internal virtual Button Button47 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button46")]
        internal virtual Button Button46 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button39")]
        internal virtual Button Button39 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button38")]
        internal virtual Button Button38 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label7")]
        internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox52")]
        internal virtual TextBox TextBox52 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox8")]
        internal virtual TextBox TextBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox51")]
        internal virtual TextBox TextBox51 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox9")]
        internal virtual TextBox TextBox9 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox50")]
        internal virtual TextBox TextBox50 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox47")]
        internal virtual TextBox TextBox47 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox49")]
        internal virtual TextBox TextBox49 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox48")]
        internal virtual TextBox TextBox48 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox7")]
        internal virtual TextBox TextBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox3")]
        internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label63")]
        internal virtual Label Label63 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button48")]
        internal virtual Button Button48 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button49")]
        internal virtual Button Button49 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox64")]
        internal virtual TextBox TextBox64 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox63")]
        internal virtual TextBox TextBox63 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox62")]
        internal virtual TextBox TextBox62 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label62")]
        internal virtual Label Label62 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label61")]
        internal virtual Label Label61 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label60")]
        internal virtual Label Label60 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox12")]
        internal virtual GroupBox GroupBox12 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("PictureBox6")]
        internal virtual PictureBox PictureBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox68")]
        internal virtual TextBox TextBox68 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox18")]
        internal virtual GroupBox GroupBox18 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button68")]
        internal virtual Button Button68 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label89")]
        internal virtual Label Label89 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox74")]
        internal virtual TextBox TextBox74 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox5")]
        internal virtual CheckBox CheckBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label88")]
        internal virtual Label Label88 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox73")]
        internal virtual TextBox TextBox73 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label87")]
        internal virtual Label Label87 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox72")]
        internal virtual TextBox TextBox72 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label86")]
        internal virtual Label Label86 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox71")]
        internal virtual TextBox TextBox71 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button67")]
        internal virtual Button Button67 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox14")]
        internal virtual GroupBox GroupBox14 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button54")]
        internal virtual Button Button54 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label78")]
        internal virtual Label Label78 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label75")]
        internal virtual Label Label75 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox15")]
        internal virtual GroupBox GroupBox15 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox70")]
        internal virtual TextBox TextBox70 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label77")]
        internal virtual Label Label77 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox69")]
        internal virtual TextBox TextBox69 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label76")]
        internal virtual Label Label76 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox4")]
        internal virtual CheckBox CheckBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("ComboBox3")]
        internal virtual ComboBox ComboBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox19")]
        internal virtual GroupBox GroupBox19 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button72")]
        internal virtual Button Button72 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox77")]
        internal virtual TextBox TextBox77 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox78")]
        internal virtual TextBox TextBox78 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label96")]
        internal virtual Label Label96 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label97")]
        internal virtual Label Label97 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox53")]
        internal virtual TextBox TextBox53 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox54")]
        internal virtual TextBox TextBox54 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label69")]
        internal virtual Label Label69 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label68")]
        internal virtual Label Label68 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label67")]
        internal virtual Label Label67 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label66")]
        internal virtual Label Label66 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label65")]
        internal virtual Label Label65 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label64")]
        internal virtual Label Label64 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox67")]
        internal virtual TextBox TextBox67 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox66")]
        internal virtual TextBox TextBox66 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox65")]
        internal virtual TextBox TextBox65 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox3")]
        internal virtual CheckBox CheckBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label103")]
        internal virtual Label Label103 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox82")]
        internal virtual TextBox TextBox82 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox81")]
        internal virtual TextBox TextBox81 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox80")]
        internal virtual TextBox TextBox80 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox79")]
        internal virtual TextBox TextBox79 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox11")]
        internal virtual CheckBox CheckBox11 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox10")]
        internal virtual CheckBox CheckBox10 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox9")]
        internal virtual CheckBox CheckBox9 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label85")]
        internal virtual Label Label85 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button61")]
        internal virtual Button Button61 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button60")]
        internal virtual Button Button60 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label95")]
        internal virtual Label Label95 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button71")]
        internal virtual Button Button71 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button70")]
        internal virtual Button Button70 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label94")]
        internal virtual Label Label94 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox7")]
        internal virtual CheckBox CheckBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button69")]
        internal virtual Button Button69 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label92")]
        internal virtual Label Label92 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label93")]
        internal virtual Label Label93 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox76")]
        internal virtual TextBox TextBox76 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label90")]
        internal virtual Label Label90 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox6")]
        internal virtual CheckBox CheckBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox55")]
        internal virtual TextBox TextBox55 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label8")]
        internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox13")]
        internal virtual GroupBox GroupBox13 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox56")]
        internal virtual TextBox TextBox56 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label11")]
        internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button50")]
        internal virtual Button Button50 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button51")]
        internal virtual Button Button51 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox2")]
        internal virtual CheckBox CheckBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox8")]
        internal virtual CheckBox CheckBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage8")]
        internal virtual TabPage TabPage8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("ListBox2")]
        internal virtual ListBox ListBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button66")]
        internal virtual Button Button66 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button65")]
        internal virtual Button Button65 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button64")]
        internal virtual Button Button64 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button63")]
        internal virtual Button Button63 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button62")]
        internal virtual Button Button62 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("PictureBox7")]
        internal virtual PictureBox PictureBox7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("PictureBox8")]
        internal virtual PictureBox PictureBox8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TabPage9")]
        internal virtual TabPage TabPage9 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button55")]
        internal virtual Button Button55 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button53")]
        internal virtual Button Button53 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button56")]
        internal virtual Button Button56 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label84")]
        internal virtual Label Label84 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label83")]
        internal virtual Label Label83 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label82")]
        internal virtual Label Label82 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label81")]
        internal virtual Label Label81 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label74")]
        internal virtual Label Label74 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label73")]
        internal virtual Label Label73 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("ListBox1")]
        internal virtual ListBox ListBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button57")]
        internal virtual Button Button57 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("WebBrowser1")]
        internal virtual WebBrowser WebBrowser1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("PictureBox5")]
        internal virtual PictureBox PictureBox5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button58")]
        internal virtual Button Button58 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label79")]
        internal virtual Label Label79 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label80")]
        internal virtual Label Label80 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label72")]
        internal virtual Label Label72 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label71")]
        internal virtual Label Label71 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label56")]
        internal virtual Label Label56 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox57")]
        internal virtual TextBox TextBox57 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("SerialPort1")]
        internal virtual SerialPort SerialPort1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("SerialPort2")]
        internal virtual SerialPort SerialPort2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Timer5")]
        internal virtual Timer Timer5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Timer2")]
        internal virtual Timer Timer2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Timer1")]
        internal virtual Timer Timer1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label4")]
        internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("TextBox6")]
        internal virtual TextBox TextBox6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Label9")]
        internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button7")]
        internal virtual Button Button7 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox2")]
        internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("RadioButton3")]
        internal virtual RadioButton RadioButton3 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("RadioButton2")]
        internal virtual RadioButton RadioButton2 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("RadioButton1")]
        internal virtual RadioButton RadioButton1 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("GroupBox4")]
        internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button8")]
        internal virtual Button Button8 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("RadioButton6")]
        internal virtual RadioButton RadioButton6 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("RadioButton5")]
        internal virtual RadioButton RadioButton5 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("RadioButton4")]
        internal virtual RadioButton RadioButton4 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button52")]
        internal virtual Button Button52 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("Button59")]
        internal virtual Button Button59 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }

        [field: AccessedThroughProperty("CheckBox12")]
        internal virtual CheckBox CheckBox12 { get; [MethodImpl(MethodImplOptions.Synchronized)]
        set; }
    }
}
