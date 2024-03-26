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
                    LableWebTips.Text = "网络正常";
                }
                else
                {
                    LableWebTips.Text = "网络未连接";
                }
            }
            catch
            {
                LableWebTips.Text = "网络未连接";
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
                    LabelPortTips.Text = "端口正常";
                    TimerPort.Start();
                }
                catch (Exception ex)
                {
                    LabelPortTips.Text = "端口打开失败 " + ex.Message;
                }
            }
            else
            {
                LabelPortTips.Text = "找不到端口";
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
                    //读缓冲区中数据长度
                    revbuflen = port.BytesToRead;
                    revflag = false;
                    //判断是否有数据
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
                    //从串口缓冲区把数据读入到RevDataBufferCount数组中
                    while (revflag)
                    {
                        RevDataBuffer[RevDataBufferCount] = (byte)port.ReadByte();
                        RevDataBufferCount++;
                        //防止缓冲区溢出
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
                    //判断是否接收到一帧数据
                    if ((RevDataBuffer[1] <= RevDataBufferCount) && (RevDataBufferCount != 0x0))
                    {
                        RevDataBufferCount = 0x0;
                        //计算校验和
                        if (!CheckSumIn(RevDataBuffer, RevDataBuffer[1]))
                        {
                            ChangeCard(string.Empty);
                            return;
                        }
                        //获取包类型
                        pkttype = RevDataBuffer[0];
                        //获取包长度
                        pktlength = RevDataBuffer[1];
                        //获取命令
                        cmd = RevDataBuffer[2];
                        //获取状态
                        err = RevDataBuffer[4];

                        if (err != 0)
                        {
                            ChangeCard(string.Empty);
                            return;
                        }
                        //获取数据
                        for (int i = 0; i < pktlength - 5; i++)
                        {
                            RevDataBuffer[i] = RevDataBuffer[i + 5];
                        }
                        if (pkttype == 0x04)
                        {
                            switch (cmd)
                            {
                                case 0x02:
                                    //获取卡号
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
                LabelPortTips.Text = "串口通信异常 " + ex.Message;
                if (port.IsOpen)
                {
                    port.Close();
                }
            }
        }

        /// <summary>
        /// 数组转十六进制字符显示
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
