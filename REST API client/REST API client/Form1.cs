namespace REST_API_client
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtURL.PlaceholderText = "Paste URL there!";
            txtResponse.Text = "Results will be here...";
        }

        private async void MySuspendLayout(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }
        private async void MyResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout(true);
        }
        private async void cmdGO_Click(object sender, EventArgs e)
        {
            txtResponse.Text = "";

            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                DebugOutput("URL must be NOT EMPTY");
                return;
            }

            if (!Uri.IsWellFormedUriString(txtURL.Text, UriKind.Absolute))
            {
                //Uri uriResult;
                //bool result = Uri.TryCreate(endPoint, UriKind.Absolute, out uriResult)
                //      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                DebugOutput("Wrong URL format!");
                return;
            }

            DebugOutput("Lets try parse it...");

            string response = string.Empty;
            RestClient restClient = new RestClient();
            restClient.endPoint = txtURL.Text;

            await Task.Run(StartJob);

            txtResponse.Text = "";

            new Thread(() =>
            this.Invoke(new MethodInvoker(async delegate () { await SendResponce(); }
            ))).Start();

            async Task StartJob()
            {
                try
                {
                    response = restClient.makeRequest();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
                }
            }

            async Task SendResponce()
            {
                int maxChars = 10000;
                int i = 0;
                txtResponse.SuspendLayout();
                for (i = 0; i < response.Length - maxChars; i += maxChars)
                {
                    txtResponse.AppendText(response.Substring(i, maxChars));
                }
                txtResponse.AppendText(response.Substring(i));
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.AppendText(Environment.NewLine + new string('_', 32) +
                    Environment.NewLine + "Number of symbols: " + txtResponse.TextLength.ToString());
                txtResponse.ScrollToCaret();
                txtResponse.ResumeLayout(true);
            }
        }

        private void DebugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.SuspendLayout();
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
                txtResponse.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }


    }
}