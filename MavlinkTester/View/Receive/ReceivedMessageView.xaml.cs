using MavlinkTester.ViewModel;
using System.Windows.Controls;

namespace MavlinkTester.View
{
    /// <summary>
    /// ReceivedMessageView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReceivedMessageView : UserControl
    {
        public ReceivedMessageView()
        {
            DataContext = new ReceivedMessageViewModel();
            InitializeComponent();
        }
    }
}
