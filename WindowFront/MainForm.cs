using Common.Entity;
using Common.Utils;
using System.IO.Ports;

namespace WindowFront
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri(Config.Uri)
        };

        public string CardID { get; set; } = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            InitPort();
        }

        #region Web

        private async void TimerNet_Tick(object sender, EventArgs e)
        {
            try
            {
                string result = await HttpUtils.GetAsyncString(_httpClient, "/Home/Test");
                if (result != null)
                {
                    LableWebTips.Text = "��������";
                }
                else
                {
                    LableWebTips.Text = "����δ����";
                }
            }
            catch
            {
                LableWebTips.Text = "����δ����";
            }
        }

        #endregion

        #region Port

        private readonly SerialPort port = new();
        public byte[] RevDataBuffer = new byte[30];
        public uint RevDataBufferCount;

        private void InitPort()
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                try
                {
                    port.PortName = ports[0];
                    port.BaudRate = 9600;
                    port.Open();
                    LabelPortTips.Text = "�˿�����";
                    TimerPort.Start();
                }
                catch (Exception ex)
                {
                    LabelPortTips.Text = "�˿ڴ�ʧ�� " + ex.Message;
                }
            }
            else
            {
                LabelPortTips.Text = "�Ҳ����˿�";
            }
        }

        private void TimerPort_Tick(object sender, EventArgs e)
        {
            int revbuflen;

            byte pkttype;
            byte pktlength;
            byte cmd;
            byte err;

            byte[] cardId = new byte[4];

            bool revflag;

            try
            {
                if (port.IsOpen)
                {
                    //�������������ݳ���
                    revbuflen = port.BytesToRead;
                    revflag = false;
                    //�ж��Ƿ�������
                    if (revbuflen > 0)
                    {
                        revflag = true;
                        Thread.Sleep(50);
                    }
                    else
                    {
                        ChangeCard(string.Empty);
                    }
                    RevDataBufferCount = 0;
                    //�Ӵ��ڻ����������ݶ��뵽RevDataBufferCount������
                    while (revflag)
                    {
                        RevDataBuffer[RevDataBufferCount] = (byte)port.ReadByte();
                        RevDataBufferCount++;
                        //��ֹ���������
                        if (RevDataBufferCount >= 30)
                        {
                            RevDataBufferCount = 0;
                        }
                        Thread.Sleep(2);
                        revbuflen = port.BytesToRead;
                        if (revbuflen > 0)
                        {
                            revflag = true;
                        }
                        else
                        {
                            revflag = false;
                        }
                    }
                    //�ж��Ƿ���յ�һ֡����
                    if ((RevDataBuffer[1] <= RevDataBufferCount) && (RevDataBufferCount != 0x0))
                    {
                        RevDataBufferCount = 0x0;
                        //����У���
                        if (!CheckSumIn(RevDataBuffer, RevDataBuffer[1]))
                        {
                            ChangeCard(string.Empty);
                            return;
                        }
                        //��ȡ������
                        pkttype = RevDataBuffer[0];
                        //��ȡ������
                        pktlength = RevDataBuffer[1];
                        //��ȡ����
                        cmd = RevDataBuffer[2];
                        //��ȡ״̬
                        err = RevDataBuffer[4];

                        if (err != 0)
                        {
                            ChangeCard(string.Empty);
                            return;
                        }
                        //��ȡ����
                        for (int i = 0; i < pktlength - 5; i++)
                        {
                            RevDataBuffer[i] = RevDataBuffer[i + 5];
                        }
                        if (pkttype == 0x04)
                        {
                            switch (cmd)
                            {
                                case 0x02:
                                    //��ȡ����
                                    for (int i = 0; i < 4; i++)
                                    {
                                        cardId[i] = RevDataBuffer[i + 2];
                                    }
                                    string strString = ByteToHexStr(cardId, 4);
                                    ChangeCard(strString);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LabelPortTips.Text = "����ͨ���쳣 " + ex.Message;
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        /// <summary>
        /// ����תʮ�������ַ���ʾ
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes, int len)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < len; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public static bool CheckSumIn(byte[] buf, byte len)
        {
            byte i;
            byte checksum;
            checksum = 0;
            for (i = 0; i < (len - 1); i++)
            {
                checksum ^= buf[i];
            }
            if (buf[len - 1] == (byte)~checksum)
            {
                return true;
            }
            return false;
        }

        #endregion

        private async void ChangeCard(string cardId)
        {
            if (cardId != string.Empty)
            {
                Student student = await HttpUtils.GetAsync<Student>(_httpClient, $"/Student/GetStudentByCardID?cardId={cardId}");
                if (student != null)
                {
                    TextBoxName.Text = student.Name;
                    TextBoxName.Text = student.Money.ToString();
                }
                else
                {

                }
            }
            else
            {
                CardID = string.Empty;
                TextBoxName.Text = string.Empty;
            }
        }
    }
}
