namespace FEWindowEventSample
{
    public partial class MainWindow : System.Windows.Window
    {
        /// <summary>
        /// ウィンドウイベント
        /// </summary>
        private FreeEcho.FEWindowEvent.WindowEvent WindowEvent = new();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                WindowEvent.WindowEventOccurrence += WindowEvent_WindowEventOccurrence;
                WindowEvent.Hook(
                    FreeEcho.FEWindowEvent.HookWindowEventType.Create
                    | FreeEcho.FEWindowEvent.HookWindowEventType.Destroy
                    | FreeEcho.FEWindowEvent.HookWindowEventType.Foreground
                    | FreeEcho.FEWindowEvent.HookWindowEventType.Hide
                    | FreeEcho.FEWindowEvent.HookWindowEventType.LocationChange
                    | FreeEcho.FEWindowEvent.HookWindowEventType.MinimizeEnd
                    | FreeEcho.FEWindowEvent.HookWindowEventType.MinimizeStart
                    | FreeEcho.FEWindowEvent.HookWindowEventType.MoveSizeEnd
                    | FreeEcho.FEWindowEvent.HookWindowEventType.MoveSizeStart
                    | FreeEcho.FEWindowEvent.HookWindowEventType.NameChange
                    | FreeEcho.FEWindowEvent.HookWindowEventType.Show
                    );

                Closed += MainWindow_Closed;
            }
            catch
            {
            }
        }

        /// <summary>
        /// ウィンドウの「Closed」イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closed(
            object sender,
            System.EventArgs e
            )
        {
            try
            {
                if (WindowEvent != null)
                {
                    WindowEvent.Unhook();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 「WindowEventOccurrence」イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowEvent_WindowEventOccurrence(
            object sender,
            FreeEcho.FEWindowEvent.WindowEventArgs e
            )
        {
            try
            {
                switch (e.WindowEventType)
                {
                    case FreeEcho.FEWindowEvent.WindowEventType.Foreground:
                        System.Diagnostics.Debug.WriteLine("Foreground - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.MoveSizeStart:
                        System.Diagnostics.Debug.WriteLine("MoveSizeStart - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.MoveSizeEnd:
                        System.Diagnostics.Debug.WriteLine("MoveSizeEnd - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.MinimizeStart:
                        System.Diagnostics.Debug.WriteLine("MinimizeStart - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.MinimizeEnd:
                        System.Diagnostics.Debug.WriteLine("MinimizeEnd - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.Create:
                        System.Diagnostics.Debug.WriteLine("Create - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.Destroy:
                        System.Diagnostics.Debug.WriteLine("Destroy - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.Show:
                        System.Diagnostics.Debug.WriteLine("Show - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.Hide:
                        System.Diagnostics.Debug.WriteLine("Hide - " + e.Hwnd);
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.LocationChange:
                        System.Diagnostics.Debug.WriteLine("LocationChange");
                        break;
                    case FreeEcho.FEWindowEvent.WindowEventType.NameChange:
                        System.Diagnostics.Debug.WriteLine("NameChange");
                        break;
                }
            }
            catch
            {
            }
        }
    }
}
