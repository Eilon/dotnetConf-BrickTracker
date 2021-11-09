using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace BrickInfoWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddBlazorWebView();

            var blazorWebView = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = @"wwwroot\index.html",
                Services = services.BuildServiceProvider(),
            };
            blazorWebView.RootComponents.Add<BrickAnalysis>("#app");

            tabPage2.Controls.Add(blazorWebView);
        }
    }
}