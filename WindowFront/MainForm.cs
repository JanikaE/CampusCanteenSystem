using Common;

namespace WindowFront
{
    public partial class MainForm : Form
    {
        private HttpClient _httpClient;

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Config.Uri)
            };
            CheckWeb();
        }

        private async void CheckWeb()
        {
            var result = await _httpClient.GetAsync("/Home/GetTime");
            string response = await result.Content.ReadAsStringAsync();
            if (result != null) { 
                LableTips.Text = response.ToString();
            }
            else
            {
                LableTips.Text = "null";
            }
        }
    }
}
