using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace YouGift_Draw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + V 키를 감지
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                // 클립보드에 텍스트가 있는지 확인
                if (Clipboard.ContainsText())
                {
                    // 클립보드에서 텍스트 가져오기
                    string clipboardText = Clipboard.GetText();
                    // 제어 문자를 제거 (\u200b 제거)
                    clipboardText = clipboardText.Replace("\u200b", "");

                    // 정규 표현식을 사용해 "손" 앞에 있는 텍스트를 추출
                    MatchCollection matches = Regex.Matches(clipboardText, @"([^\r\n]+)\s*손");
                    // 추출된 결과 출력
                    foreach (Match match in matches)
                    {
                       NickNameList.Items.Add(match.Groups[1].Value);
                    }
                }
            }
        }
    }
}
