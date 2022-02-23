namespace REST_API_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdGO_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Length == 0)
            {
                debugOutput("URL must be NOT EMPTY");
                txtURL.Text = "";
                txtURL.PlaceholderText = "Paste URL there!";
                return;
            }     
            
            debugOutput("Lets try parse it...");

            RestClient restClient = new RestClient();
            restClient.endPoint = txtURL.Text;

            string response = string.Empty;
            response = restClient.makeRequest();
            txtResponse.Text = "";
            debugOutput(response);
        }
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}