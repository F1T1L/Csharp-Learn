using Newtonsoft.Json;
using System.Diagnostics;


namespace REST_API_client
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtURL.PlaceholderText = "Paste URL here!";
            DebugOutput("Results will appear here...");
            DoubleBuffered = true;
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
                ErrorWithUrlOutput("\nPlease enter the link above in the field.");
                return;
            }

            if (!Uri.IsWellFormedUriString(txtURL.Text, UriKind.Absolute)) //check URL, problems with HTTTPS. =(
            {
                //Uri uriResult;
                //bool result = Uri.TryCreate(endPoint, UriKind.Absolute, out uriResult)
                //      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                ErrorWithUrlOutput("\nWrong URL format!");
                return;
            }

            txtResponse.Font = new Font(Font.FontFamily, 12f, FontStyle.Regular); //kolhoz :D
            txtResponse.BackColor = SystemColors.Control;
            // txtResponse.SelectAll();  wtf?
            txtResponse.SelectionAlignment = HorizontalAlignment.Left;

            string response = string.Empty;
            RestClient restClient = new RestClient();
            restClient.endPoint = txtURL.Text;

            var tokenSource = new CancellationTokenSource();
            var ct = tokenSource.Token;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Color color = TurnOffButtonGO();

            DoAnimationTask(); //do animation while parse.

            await Task.Run(StartJob);

            tokenSource.Cancel(); //cancel DoAnimationTask

            new Thread(() =>
            this.Invoke(new MethodInvoker(delegate () { SendResponce(); }
            ))).Start();

            #region local functions
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

            void SendResponce()
            {
                txtResponse.Text = string.Empty;
                if (IsJson(response))  // maybe, not need, anyway json will throw exception, if its not Json.
                {
                    try
                    {
                        txtResponse.AppendText(JsonConvert.DeserializeObject(response, typeof(object)).ToString());
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
                    }
                }
                else
                {
                    int i = 0,
                        maxChars = 10000;
                    // txtResponse.SuspendLayout();
                    for (i = 0; i < response.Length - maxChars; i += maxChars)
                    {
                        txtResponse.AppendText(response.Substring(i, maxChars));
                    }
                    txtResponse.AppendText(response.Substring(i));
                }

                EndOfResponsePlusStats();
                TurnOnButtonGO();

                void EndOfResponsePlusStats()
                {
                    txtResponse.AppendText(Environment.NewLine + new string('_', 32) +
                                            Environment.NewLine + "Response time: " + stopWatch.Elapsed.TotalSeconds +
                                            Environment.NewLine + "Number of symbols: " + txtResponse.TextLength.ToString() +
                                            Environment.NewLine);
                    txtResponse.SelectionStart = txtResponse.TextLength;
                    txtResponse.ScrollToCaret();
                   // txtResponse.HideSelection = false; /// WTF FREEZE AFTER ALL WORK DONE!!!                   
                    txtResponse.ResumeLayout(true);
                }
                bool IsJson(string input)
                {
                    input = input.Trim();
                    return input.StartsWith("{") && input.EndsWith("}")
                           || input.StartsWith("[") && input.EndsWith("]");
                }
            }

            void TurnOnButtonGO()
            {
                cmdGO.BackColor = color;
                cmdGO.Enabled = true;
            }

            Color TurnOffButtonGO()
            {
                Color color = cmdGO.BackColor;
                cmdGO.Enabled = false;          //turn off button (clicks and "Enter").
                cmdGO.BackColor = Color.DarkGray;
                return color;
            }

            #endregion
        }

        private void ErrorWithUrlOutput(string strDebugText)
        {
            try
            {
                txtResponse.Font = new Font(Font.FontFamily, 22f, FontStyle.Bold);
                txtResponse.BackColor = Color.Red;
                txtResponse.SelectionAlignment = HorizontalAlignment.Center;
                txtURL.Text = string.Empty;

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