using System.Diagnostics;


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
            txtResponse.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                txtResponse.Font = new Font(Font.FontFamily, 22f, FontStyle.Bold);
                txtResponse.BackColor = Color.Red;
                DebugOutput("URL must be NOT EMPTY");
                txtURL.Text = string.Empty;
                return;
            }

            if (!Uri.IsWellFormedUriString(txtURL.Text, UriKind.Absolute))
            {
                //Uri uriResult;
                //bool result = Uri.TryCreate(endPoint, UriKind.Absolute, out uriResult)
                //      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                txtResponse.Font = new Font(Font.FontFamily, 22f, FontStyle.Bold);
                txtResponse.BackColor = Color.Red;
                DebugOutput("Wrong URL format!");
                txtURL.Text = string.Empty;
                return;
            }
            txtResponse.Font = new Font(Font.FontFamily, 12f, FontStyle.Regular);
            txtResponse.BackColor = SystemColors.Control;
            
            string response = string.Empty;
            RestClient restClient = new RestClient();
            restClient.endPoint = txtURL.Text;

            var tokenSource = new CancellationTokenSource();
            var ct = tokenSource.Token;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            DoAnimationTask();

            Color color = cmdGO.BackColor;
            cmdGO.Enabled = false;
            cmdGO.BackColor = Color.DarkGray;

            await Task.Run(StartJob);
            tokenSource.Cancel(); //cancel DoAnimationTask

            new Thread(() =>
            this.Invoke(new MethodInvoker(async delegate () { await SendResponce(); }
            ))).Start();
            
            cmdGO.Enabled = true;
            cmdGO.BackColor = color;

            void DoAnimationTask()
            {
                var task = Task.Factory.StartNew(() =>
                          {
                              //animation code
                              WaitingAnimation();
                          }, tokenSource.Token);
            }

            void WaitingAnimation()
            {
                while (true)
                {
                    this.Invoke(new MethodInvoker(delegate () { txtResponse.Text = "Lets try parse it, waiting: " + stopWatch.Elapsed.TotalSeconds; }));
                    Task.Delay(10).Wait();

                    if (ct.IsCancellationRequested)
                    {
                        stopWatch.Stop();
                        return;
                    }
                }
            }

            async Task StartJob()
            {
                //Thread.Sleep(3000);
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
                int i = 0,
                    maxChars = 10000;
                txtResponse.Text = string.Empty;
                txtResponse.SuspendLayout();
                for (i = 0; i < response.Length - maxChars; i += maxChars)
                {
                    txtResponse.AppendText(response.Substring(i, maxChars));
                }
                txtResponse.AppendText(response.Substring(i));
                txtResponse.AppendText(Environment.NewLine + new string('_', 32) +
                    Environment.NewLine + "Response time: " + stopWatch.Elapsed.TotalSeconds +
                    Environment.NewLine + "Number of symbols: " + txtResponse.TextLength.ToString());
                txtResponse.HideSelection = false;
                txtResponse.SelectionStart = txtResponse.TextLength;
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