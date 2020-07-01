using MavlinkTester.ViewModel;
using System.Windows.Controls;

namespace MavlinkTester.View
{
    /// <summary>
    /// SendCommandView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SendCommandView : UserControl
    {
        public SendCommandView()
        {
            DataContext = new SendCommandViewModel();
            InitializeComponent();
        }
    }
}
